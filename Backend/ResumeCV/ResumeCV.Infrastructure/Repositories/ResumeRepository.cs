using AutoMapper;
using ResumeCV.Infra.Context;
using ResumeCV.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ResumeCV.Infra.Interfaces.Repositories;

namespace ResumeCV.Infra.Repositories
{
    public class ResumeRepository : IResumeRepository<IResumeModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public long Add(IResumeModel resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            // Domain (IResumeModel) -> Infra (Resume)
            var entity = _mapper.Map<Resume>(resume);

            foreach (var course in entity.ResumeCourses)
            {
                course.ResumeId = entity.ResumeId;
            }

            foreach (var info in entity.ResumeInfos)
            {
                info.ResumeId = entity.ResumeId;
            }

            foreach (var job in entity.ResumeJobs)
            {
                job.ResumeId = entity.ResumeId;
            }

            foreach (var language in entity.ResumeLanguages)
            {
                language.ResumeId = entity.ResumeId;
            }

            _context.Resumes.Add(entity);
            _context.SaveChanges();

            return entity.ResumeId;
        }

        public void Update(IResumeModel resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            var existing = _context.Resumes.FirstOrDefault(r => r.ResumeId == resume.ResumeId);
            if (existing == null) throw new KeyNotFoundException($"Resume with id {resume.ResumeId} not found.");

            _context.ResumeCourseSkills.RemoveRange(_context.ResumeCourseSkills.Where(x => x.Course.ResumeId == existing.ResumeId));
            _context.ResumeCourses.RemoveRange(_context.ResumeCourses.Where(x => x.ResumeId == existing.ResumeId));
            _context.ResumeInfoSkills.RemoveRange(_context.ResumeInfoSkills.Where(x => x.Info.ResumeId == existing.ResumeId));
            _context.ResumeInfos.RemoveRange(_context.ResumeInfos.Where(x => x.ResumeId == existing.ResumeId));
            _context.ResumeJobSkills.RemoveRange(_context.ResumeJobSkills.Where(x => x.Job.ResumeId == existing.ResumeId));
            _context.ResumeJobs.RemoveRange(_context.ResumeJobs.Where(x => x.ResumeId == existing.ResumeId));
            _context.ResumeLanguages.RemoveRange(_context.ResumeLanguages.Where(x => x.ResumeId == existing.ResumeId));
            _context.SaveChanges();

            _mapper.Map(resume, existing);

            foreach (var course in existing.ResumeCourses) {
                course.CourseId = 0;
                course.ResumeId = existing.ResumeId;
                foreach (var skill in course.ResumeCourseSkills)
                {
                    skill.CourseSkillId = 0;
                    var existingSkill = _context
                        .ResumeSkills
                        .Where(x => x.Slug == skill.Skill.Slug)
                        .FirstOrDefault();
                    if (existingSkill != null) {
                        existingSkill.SkillType = skill.Skill.SkillType;
                        skill.SkillId = existingSkill.SkillId;
                    }
                }
            }

            foreach (var info in existing.ResumeInfos)
            {
                info.InfoId = 0;
                info.ResumeId = existing.ResumeId;
                foreach (var skill in info.ResumeInfoSkills)
                {
                    skill.InfoSkillId = 0;
                    var existingSkill = _context
                        .ResumeSkills
                        .Where(x => x.Slug == skill.Skill.Slug)
                        .FirstOrDefault();
                    if (existingSkill != null)
                    {
                        existingSkill.SkillType = skill.Skill.SkillType;
                        skill.SkillId = existingSkill.SkillId;
                    }
                }
            }

            foreach (var job in existing.ResumeJobs)
            {
                job.JobId = 0;
                job.ResumeId = existing.ResumeId;
                foreach (var skill in job.ResumeJobSkills)
                {
                    skill.JobSkillId = 0;
                    var existingSkill = _context
                        .ResumeSkills
                        .Where(x => x.Slug == skill.Skill.Slug)
                        .FirstOrDefault();
                    if (existingSkill != null)
                    {
                        existingSkill.SkillType = skill.Skill.SkillType;
                        skill.SkillId = existingSkill.SkillId;
                    }
                }
            }

            foreach (var language in existing.ResumeLanguages)
            {
                language.LanguageId = 0;
                language.ResumeId = existing.ResumeId;
            }

            _context.SaveChanges();
        }

        public void Delete(long resumeId)
        {
            var entity = _context.Resumes
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.ResumeCourseSkills)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.ResumeInfoSkills)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.ResumeJobSkills)
                .Include(r => r.ResumeLanguages)
                .FirstOrDefault(r => r.ResumeId == resumeId);

            if (entity == null) return;

            // Remover entradas de junção (segurança caso não exista cascade)
            var courseSkillJoins = entity.ResumeCourses.SelectMany(c => c.ResumeCourseSkills).ToList();
            if (courseSkillJoins.Count > 0) _context.ResumeCourseSkills.RemoveRange(courseSkillJoins);

            var infoSkillJoins = entity.ResumeInfos.SelectMany(i => i.ResumeInfoSkills).ToList();
            if (infoSkillJoins.Count > 0) _context.ResumeInfoSkills.RemoveRange(infoSkillJoins);

            var jobSkillJoins = entity.ResumeJobs.SelectMany(j => j.ResumeJobSkills).ToList();
            if (jobSkillJoins.Count > 0) _context.ResumeJobSkills.RemoveRange(jobSkillJoins);

            // Remover entidades filhas
            if (entity.ResumeCourses.Any()) _context.ResumeCourses.RemoveRange(entity.ResumeCourses);
            if (entity.ResumeInfos.Any()) _context.ResumeInfos.RemoveRange(entity.ResumeInfos);
            if (entity.ResumeJobs.Any()) _context.ResumeJobs.RemoveRange(entity.ResumeJobs);
            if (entity.ResumeLanguages.Any()) _context.ResumeLanguages.RemoveRange(entity.ResumeLanguages);

            _context.Resumes.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeModel? GetById(long resumeId)
        {
            var entity = _context.Resumes
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.ResumeCourseSkills)
                        .ThenInclude(cs => cs.Skill)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.ResumeInfoSkills)
                        .ThenInclude(ip => ip.Skill)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.ResumeJobSkills)
                        .ThenInclude(js => js.Skill)
                .Include(r => r.ResumeLanguages)
                .FirstOrDefault(r => r.ResumeId == resumeId);

            if (entity == null) return null;

            var model = _mapper.Map<IResumeModel>(entity);
            return model;
        }

        public IEnumerable<IResumeModel> ListByUserId(long userId)
        {
            var entities = _context.Resumes
                .AsNoTracking()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.ResumeId)
                .ToList();

            return entities.Select(e => _mapper.Map<IResumeModel>(e)).ToList();
        }
    }
}
