using AutoMapper;
using ResumeCV.Domain.Entities;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Infra.Context;
using ResumeCV.DTOs;
using System;
using System.Linq;
using ResumeCV.Domain.Enums;

namespace ResumeCV.Infra.Mapping.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            // Infra -> Domain (interfaces)
            CreateMap<Resume, IResumeModel>()
                .ConstructUsing(src =>
                    new ResumeModel(
                        src.ResumeId,
                        src.UserId,
                        src.Name,
                        src.Phone,
                        src.Email,
                        src.Status,
                        src.Title,
                        src.JobDescription ?? string.Empty,
                        src.PhotoUrl ?? string.Empty,
                        src.Address,
                        src.Resume1
                    ))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearCourses();
                    foreach (var c in src.ResumeCourses ?? Enumerable.Empty<ResumeCourse>())
                    {
                        var cm = ctx.Mapper.Map<IResumeCourseModel>(c);
                        dest.AddCourse(cm);
                    }

                    dest.ClearInfos();
                    foreach (var i in src.ResumeInfos ?? Enumerable.Empty<ResumeInfo>())
                    {
                        var im = ctx.Mapper.Map<IResumeInfoModel>(i);
                        dest.AddInfo(im);
                    }

                    dest.ClearJobs();
                    foreach (var j in src.ResumeJobs ?? Enumerable.Empty<ResumeJob>())
                    {
                        var jm = ctx.Mapper.Map<IResumeJobModel>(j);
                        dest.AddJob(jm);
                    }

                    dest.ClearLanguages();
                    foreach (var l in src.ResumeLanguages ?? Enumerable.Empty<ResumeLanguage>())
                    {
                        var lm = ctx.Mapper.Map<IResumeLanguageModel>(l);
                        dest.AddLanguage(lm);
                    }
                });

            CreateMap<ResumeCourse, IResumeCourseModel>()
                .ConstructUsing(src => new ResumeCourseModel(src.CourseId, src.ResumeId, src.Title, src.CourseType))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.UpdateLocation(src.Location);
                    dest.UpdateInstitute(src.Institute);
                    dest.UpdateDescription(src.Resume);
                    dest.SetDates(ToUnspecified(src.StartDate) ?? default, ToUnspecified(src.EndDate) ?? default);

                    dest.ClearSkills();
                    foreach (var cs in src.ResumeCourseSkills ?? Enumerable.Empty<ResumeCourseSkill>())
                    {
                        if (cs.Skill is not null)
                            dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(cs.Skill));
                    }
                });

            CreateMap<ResumeInfo, IResumeInfoModel>()
                .ConstructUsing(src => new ResumeInfoModel(
                    src.InfoId, 
                    src.ResumeId, 
                    (InfoTypeEnum)src.InfoType, 
                    src.Title, 
                    src.Resume, 
                    src.Url
                ))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearSkills();
                    foreach (var iskill in src.ResumeInfoSkills ?? Enumerable.Empty<ResumeInfoSkill>())
                    {
                        if (iskill.Skill is not null)
                            dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(iskill.Skill));
                    }
                });

            CreateMap<ResumeJob, IResumeJobModel>()
                .ConstructUsing(src => new ResumeJobModel(
                    src.JobId,
                    src.ResumeId,
                    src.Position,
                    src.Business1,
                    ToUnspecified(src.StartDate) ?? default,
                    ToUnspecified(src.EndDate) ?? default,
                    src.Business2,
                    src.Location,
                    src.Resume))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearSkills();
                    foreach (var jskill in src.ResumeJobSkills ?? Enumerable.Empty<ResumeJobSkill>())
                    {
                        if (jskill.Skill is not null)
                            dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(jskill.Skill));
                    }
                });

            CreateMap<ResumeLanguage, IResumeLanguageModel>()
                .ConstructUsing(src => new ResumeLanguageModel(src.LanguageId, src.ResumeId, src.Language, src.Level));

            CreateMap<ResumeSkill, IResumeSkillModel>()
                .ConstructUsing(src => new ResumeSkillModel(src.SkillId, src.Name, src.Slug));

            // Domain -> Infra
            CreateMap<IResumeModel, Resume>()
                .ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Resume1, o => o.MapFrom(s => s.Resume))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.JobDescription, o => o.MapFrom(s => s.JobDescription))
                .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.PhotoUrl))
                .ForMember(d => d.ResumeCourses, o => o.MapFrom(s => s.Courses))
                .ForMember(d => d.ResumeInfos, o => o.MapFrom(s => s.Infos))
                .ForMember(d => d.ResumeJobs, o => o.MapFrom(s => s.Jobs))
                .ForMember(d => d.ResumeLanguages, o => o.MapFrom(s => s.Languages));

            CreateMap<IResumeCourseModel, ResumeCourse>()
                .ConstructUsing(src => new ResumeCourse
                {
                    CourseId = src.CourseId,
                    ResumeId = src.ResumeId,
                    CourseType = src.CourseType,
                    Title = src.Title,
                    Location = src.Location,
                    Institute = src.Institute,
                    Resume = src.Resume,
                    StartDate = ToUnspecified(src.StartDate),
                    EndDate = ToUnspecified(src.EndDate)
                })
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ResumeCourseSkills = (src.Skills ?? Enumerable.Empty<IResumeSkillModel>())
                        .Select(s => new ResumeCourseSkill
                        {
                            CourseId = dest.CourseId,
                            SkillId = s.SkillId,
                            Skill = ctx.Mapper.Map<ResumeSkill>(s)
                        })
                        .ToList();
                });

            CreateMap<IResumeInfoModel, ResumeInfo>()
                .ConstructUsing(src => new ResumeInfo
                {
                    InfoId = src.InfoId,
                    ResumeId = src.ResumeId,
                    InfoType = (int)src.InfoType,
                    Title = src.Title,
                    Resume = src.Resume,
                    Url = src.Url
                })
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ResumeInfoSkills = (src.Skills ?? Enumerable.Empty<IResumeSkillModel>())
                        .Select(s => new ResumeInfoSkill
                        {
                            InfoId = dest.InfoId,
                            SkillId = s.SkillId,
                            Skill = ctx.Mapper.Map<ResumeSkill>(s)
                        })
                        .ToList();
                });

            CreateMap<IResumeJobModel, ResumeJob>()
                .ConstructUsing(src => new ResumeJob
                {
                    JobId = src.JobId,
                    ResumeId = src.ResumeId,
                    Position = src.Position,
                    Business1 = src.Business1,
                    Business2 = src.Business2,
                    StartDate = ToUnspecified(src.StartDate) ?? default,
                    EndDate = ToUnspecified(src.EndDate),
                    Location = src.Location,
                    Resume = src.Resume
                })
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ResumeJobSkills = (src.Skills ?? Enumerable.Empty<IResumeSkillModel>())
                        .Select(s => new ResumeJobSkill
                        {
                            JobId = dest.JobId,
                            SkillId = s.SkillId,
                            Skill = ctx.Mapper.Map<ResumeSkill>(s)
                        })
                        .ToList();
                });

            CreateMap<IResumeLanguageModel, ResumeLanguage>()
                .ConstructUsing(src => new ResumeLanguage
                {
                    LanguageId = src.LanguageId,
                    ResumeId = src.ResumeId,
                    Language = src.Language,
                    Level = src.Level
                });

            CreateMap<IResumeSkillModel, ResumeSkill>()
                .ConstructUsing(src => new ResumeSkill
                {
                    SkillId = src.SkillId,
                    //UserId = src.UserId,
                    Slug = src.Slug,
                    Name = src.Name
                });

            // Domain -> DTO
            CreateMap<IResumeSkillModel, ResumeSkillDTO>()
                //.ForMember(d => d.SkillId, o => o.MapFrom(s => s.SkillId))
                //.ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Slug, o => o.MapFrom(s => s.Slug))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            CreateMap<IResumeCourseModel, ResumeCourseDTO>()
                .ForMember(d => d.CourseId, o => o.MapFrom(s => s.CourseId))
                //.ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.CourseType, o => o.MapFrom(s => s.CourseType))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Location, o => o.MapFrom(s => s.Location))
                .ForMember(d => d.Institute, o => o.MapFrom(s => s.Institute))
                .ForMember(d => d.Resume, o => o.MapFrom(s => s.Resume))
                .ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate))
                .ForMember(d => d.EndDate, o => o.MapFrom(s => s.EndDate))
                .ForMember(d => d.Skills, o => o.MapFrom(s => s.Skills));

            CreateMap<IResumeInfoModel, ResumeInfoDTO>()
                .ForMember(d => d.InfoId, o => o.MapFrom(s => s.InfoId))
                //.ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.InfoType, o => o.MapFrom(s => (int)s.InfoType))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Resume, o => o.MapFrom(s => s.Resume))
                .ForMember(d => d.Url, o => o.MapFrom(s => s.Url))
                .ForMember(d => d.Skills, o => o.MapFrom(s => s.Skills));

            CreateMap<IResumeJobModel, ResumeJobDTO>()
                .ForMember(d => d.JobId, o => o.MapFrom(s => s.JobId))
                //.ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
                .ForMember(d => d.Business1, o => o.MapFrom(s => s.Business1))
                .ForMember(d => d.Business2, o => o.MapFrom(s => s.Business2))
                .ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate))
                .ForMember(d => d.EndDate, o => o.MapFrom(s => s.EndDate))
                .ForMember(d => d.Location, o => o.MapFrom(s => s.Location))
                .ForMember(d => d.Resume, o => o.MapFrom(s => s.Resume))
                .ForMember(d => d.Skills, o => o.MapFrom(s => s.Skills));

            CreateMap<IResumeLanguageModel, ResumeLanguageDTO>()
                .ForMember(d => d.LanguageId, o => o.MapFrom(s => s.LanguageId))
                //.ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.Level, o => o.MapFrom(s => s.Level));

            CreateMap<IResumeModel, ResumeDTO>()
                .ForMember(d => d.ResumeId, o => o.MapFrom(s => s.ResumeId))
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.JobDescription, o => o.MapFrom(s => s.JobDescription))
                .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.PhotoUrl))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Resume, o => o.MapFrom(s => s.Resume))
                .ForMember(d => d.Courses, o => o.MapFrom(s => s.Courses))
                .ForMember(d => d.Infos, o => o.MapFrom(s => s.Infos))
                .ForMember(d => d.Jobs, o => o.MapFrom(s => s.Jobs))
                .ForMember(d => d.Languages, o => o.MapFrom(s => s.Languages));

            // DTO -> Domain (interfaces)
            CreateMap<ResumeSkillDTO, IResumeSkillModel>()
                //.ConstructUsing(src => new ResumeSkillModel(src.SkillId, src.UserId, src.Name, src.Slug));
                //.ConstructUsing(src => new ResumeSkillModel(0, 0, src.Name, src.Slug));
                .ConstructUsing(src => new ResumeSkillModel(0, src.Name, src.Slug));

            CreateMap<ResumeCourseDTO, IResumeCourseModel>()
                //.ConstructUsing(src => new ResumeCourseModel(src.CourseId, src.ResumeId, src.Title, src.CourseType))
                .ConstructUsing(src => new ResumeCourseModel(src.CourseId, 0, src.Title, src.CourseType))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.UpdateLocation(src.Location);
                    dest.UpdateInstitute(src.Institute);
                    dest.UpdateDescription(src.Resume);
                    dest.SetDates(ToUnspecified(src.StartDate) ?? default, ToUnspecified(src.EndDate) ?? default);

                    dest.ClearSkills();
                    foreach (var s in src.Skills ?? Enumerable.Empty<ResumeSkillDTO>())
                    {
                        dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(s));
                    }
                });

            CreateMap<ResumeInfoDTO, IResumeInfoModel>()
                //.ConstructUsing(src => new ResumeInfoModel(src.InfoId, src.ResumeId, src.Title, src.Resume, src.Url))
                .ConstructUsing(src => new ResumeInfoModel(
                    src.InfoId, 
                    0, 
                    (InfoTypeEnum) src.InfoType,
                    src.Title, 
                    src.Resume, 
                    src.Url
                ))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearSkills();
                    foreach (var s in src.Skills ?? Enumerable.Empty<ResumeSkillDTO>())
                    {
                        dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(s));
                    }
                });

            CreateMap<ResumeJobDTO, IResumeJobModel>()
                .ConstructUsing(src => new ResumeJobModel(
                    src.JobId,
                    0,
                    src.Position,
                    src.Business1,
                    ToUnspecified(src.StartDate) ?? default,
                    ToUnspecified(src.EndDate) ?? default,
                    src.Business2,
                    src.Location,
                    src.Resume))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearSkills();
                    foreach (var s in src.Skills ?? Enumerable.Empty<ResumeSkillDTO>())
                    {
                        dest.AddSkill(ctx.Mapper.Map<IResumeSkillModel>(s));
                    }
                });

            CreateMap<ResumeLanguageDTO, IResumeLanguageModel>()
                //.ConstructUsing(src => new ResumeLanguageModel(src.LanguageId, src.ResumeId, src.Language, src.Level));
                .ConstructUsing(src => new ResumeLanguageModel(src.LanguageId, 0, src.Language, src.Level));

            CreateMap<ResumeDTO, IResumeModel>()
                .ConstructUsing(src => new ResumeModel(
                    src.ResumeId,
                    src.UserId,
                    src.Name,
                    src.Phone,
                    src.Email,
                    src.Status,
                    src.Title,
                    src.JobDescription,
                    src.PhotoUrl,
                    src.Address,
                    src.Resume))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ClearCourses();
                    foreach (var c in src.Courses ?? Enumerable.Empty<ResumeCourseDTO>())
                    {
                        var cm = ctx.Mapper.Map<IResumeCourseModel>(c);
                        dest.AddCourse(cm);
                    }

                    dest.ClearInfos();
                    foreach (var i in src.Infos ?? Enumerable.Empty<ResumeInfoDTO>())
                    {
                        var im = ctx.Mapper.Map<IResumeInfoModel>(i);
                        dest.AddInfo(im);
                    }

                    dest.ClearJobs();
                    foreach (var j in src.Jobs ?? Enumerable.Empty<ResumeJobDTO>())
                    {
                        var jm = ctx.Mapper.Map<IResumeJobModel>(j);
                        dest.AddJob(jm);
                    }

                    dest.ClearLanguages();
                    foreach (var l in src.Languages ?? Enumerable.Empty<ResumeLanguageDTO>())
                    {
                        var lm = ctx.Mapper.Map<IResumeLanguageModel>(l);
                        dest.AddLanguage(lm);
                    }
                });
        }

        private static DateTime? ToUnspecified(DateTime? d)
        {
            if (!d.HasValue) return null;
            return DateTime.SpecifyKind(d.Value, DateTimeKind.Unspecified);
        }
    }
}
