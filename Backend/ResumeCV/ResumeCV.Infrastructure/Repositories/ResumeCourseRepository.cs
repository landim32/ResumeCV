using AutoMapper;
using ResumeCV.Domain.Entities;
using ResumeCV.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ResumeCV.Infra.Interfaces.Repositories;
using ResumeCV.Domain.Entities.Interfaces;

namespace ResumeCV.Infra.Repositories
{
    public class ResumeCourseRepository : IResumeCourseRepository<IResumeCourseModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeCourseRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IResumeCourseModel Add(IResumeCourseModel course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            var entity = _mapper.Map<ResumeCourse>(course);

            _context.ResumeCourses.Add(entity);
            _context.SaveChanges(); // garante CourseId gerado

            // Persistir skills associados (tabela de junção)
            if (course.Skills != null && course.Skills.Count > 0)
            {
                var joinEntries = course.Skills.Select(s => new ResumeCourseSkill
                {
                    CourseId = entity.CourseId,
                    SkillId = s.SkillId
                }).ToList();

                _context.ResumeCourseSkills.AddRange(joinEntries);
                _context.SaveChanges();
            }

            // Recarrega com relacionamentos e mapear para IResumeCourseModel usando AutoMapper
            var loaded = _context.ResumeCourses
                                 .Include(c => c.ResumeCourseSkills)
                                     .ThenInclude(cs => cs.Skill)
                                 .FirstOrDefault(c => c.CourseId == entity.CourseId);

            if (loaded == null) throw new InvalidOperationException("Erro ao carregar a entidade criada.");

            IResumeCourseModel model = _mapper.Map<IResumeCourseModel>(loaded);
            return model;
        }

        public void Delete(long courseId)
        {
            var entity = _context.ResumeCourses.Find(courseId);
            if (entity == null) return;

            // Remove join entries primeiro (segurança)
            var joins = _context.ResumeCourseSkills.Where(j => j.CourseId == courseId).ToList();
            if (joins.Count > 0)
            {
                _context.ResumeCourseSkills.RemoveRange(joins);
            }

            _context.ResumeCourses.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeCourseModel? GetById(long courseId)
        {
            var entity = _context.ResumeCourses
                                 .AsNoTracking()
                                 .Include(c => c.ResumeCourseSkills)
                                     .ThenInclude(cs => cs.Skill)
                                 .FirstOrDefault(c => c.CourseId == courseId);

            if (entity == null) return null;

            var model = _mapper.Map<IResumeCourseModel>(entity);
            return model;
        }

        public IEnumerable<IResumeCourseModel> ListByResumeId(long resumeId)
        {
            var entities = _context.ResumeCourses
                                   .AsNoTracking()
                                   .Where(c => c.ResumeId == resumeId)
                                   .Include(c => c.ResumeCourseSkills)
                                       .ThenInclude(cs => cs.Skill)
                                   .ToList();

            return entities.Select(e => _mapper.Map<IResumeCourseModel>(e)).ToList();
        }

        public IResumeCourseModel Update(IResumeCourseModel course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            var existing = _context.ResumeCourses
                                   .Include(c => c.ResumeCourseSkills)
                                   .FirstOrDefault(c => c.CourseId == course.CourseId);

            if (existing == null) throw new KeyNotFoundException($"ResumeCourse with id {course.CourseId} not found.");

            // Mapear propriedades do modelo para a entidade existente usando AutoMapper.
            // Requer configuração de mapeamento de IResumeCourseModel -> ResumeCourse.
            _mapper.Map(course, existing);

            // Atualiza skills: remover todos e re-adicionar conforme modelo de domínio
            var currentJoins = existing.ResumeCourseSkills.ToList();
            if (currentJoins.Count > 0)
            {
                _context.ResumeCourseSkills.RemoveRange(currentJoins);
            }

            if (course.Skills != null && course.Skills.Count > 0)
            {
                var newJoins = course.Skills.Select(s => new ResumeCourseSkill
                {
                    CourseId = existing.CourseId,
                    SkillId = s.SkillId
                });
                _context.ResumeCourseSkills.AddRange(newJoins);
            }

            _context.SaveChanges();

            // Recarrega e mapeia para IResumeCourseModel atualizado
            var reloaded = _context.ResumeCourses
                                   .Include(c => c.ResumeCourseSkills)
                                       .ThenInclude(cs => cs.Skill)
                                   .First(c => c.CourseId == existing.CourseId);

            var model = _mapper.Map<IResumeCourseModel>(reloaded);
            return model;
        }
    }
}
