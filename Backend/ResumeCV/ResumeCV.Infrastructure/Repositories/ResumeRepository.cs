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

            foreach (var project in entity.ResumeProjects)
            {
                project.ResumeId = entity.ResumeId;
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

            // Carregar a entidade existente com todos os relacionamentos
            var existing = _context.Resumes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.Skills)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.Skills)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.Skills)
                .Include(r => r.ResumeProjects)
                    .ThenInclude(p => p.Skills)
                .Include(r => r.ResumeLanguages)
                .FirstOrDefault(r => r.ResumeId == resume.ResumeId);

            if (existing == null) throw new KeyNotFoundException($"Resume with id {resume.ResumeId} not found.");

            // Remover todos os filhos antigos ANTES do mapeamento
            _context.ResumeCourses.RemoveRange(existing.ResumeCourses);
            _context.ResumeInfos.RemoveRange(existing.ResumeInfos);
            _context.ResumeJobs.RemoveRange(existing.ResumeJobs);
            _context.ResumeProjects.RemoveRange(existing.ResumeProjects);
            _context.ResumeLanguages.RemoveRange(existing.ResumeLanguages);

            // Limpar as coleções
            existing.ResumeCourses.Clear();
            existing.ResumeInfos.Clear();
            existing.ResumeJobs.Clear();
            existing.ResumeProjects.Clear();
            existing.ResumeLanguages.Clear();

            // Agora faz o mapeamento
            _mapper.Map(resume, existing);

            // Processar skills para reutilizar existentes
            foreach (var course in existing.ResumeCourses) 
            {
                course.ResumeId = existing.ResumeId;
                var updatedSkills = new List<ResumeSkill>();
                
                foreach (var skill in course.Skills)
                {
                    var existingSkill = _context.ResumeSkills
                        .FirstOrDefault(x => x.Slug == skill.Slug);
                    
                    if (existingSkill != null) 
                    {
                        existingSkill.SkillType = skill.SkillType;
                        existingSkill.Name = skill.Name;
                        updatedSkills.Add(existingSkill);
                    }
                    else
                    {
                        updatedSkills.Add(skill);
                    }
                }
                
                course.Skills = updatedSkills;
            }

            foreach (var info in existing.ResumeInfos)
            {
                info.ResumeId = existing.ResumeId;
                var updatedSkills = new List<ResumeSkill>();
                
                foreach (var skill in info.Skills)
                {
                    var existingSkill = _context.ResumeSkills
                        .FirstOrDefault(x => x.Slug == skill.Slug);
                    
                    if (existingSkill != null)
                    {
                        existingSkill.SkillType = skill.SkillType;
                        existingSkill.Name = skill.Name;
                        updatedSkills.Add(existingSkill);
                    }
                    else
                    {
                        updatedSkills.Add(skill);
                    }
                }
                
                info.Skills = updatedSkills;
            }

            foreach (var job in existing.ResumeJobs)
            {
                job.ResumeId = existing.ResumeId;
                var updatedSkills = new List<ResumeSkill>();
                
                foreach (var skill in job.Skills)
                {
                    var existingSkill = _context.ResumeSkills
                        .FirstOrDefault(x => x.Slug == skill.Slug);
                    
                    if (existingSkill != null)
                    {
                        existingSkill.SkillType = skill.SkillType;
                        existingSkill.Name = skill.Name;
                        updatedSkills.Add(existingSkill);
                    }
                    else
                    {
                        updatedSkills.Add(skill);
                    }
                }
                
                job.Skills = updatedSkills;
            }

            foreach (var project in existing.ResumeProjects)
            {
                project.ResumeId = existing.ResumeId;
                var updatedSkills = new List<ResumeSkill>();
                
                foreach (var skill in project.Skills)
                {
                    var existingSkill = _context.ResumeSkills
                        .FirstOrDefault(x => x.Slug == skill.Slug);
                    
                    if (existingSkill != null)
                    {
                        existingSkill.SkillType = skill.SkillType;
                        existingSkill.Name = skill.Name;
                        updatedSkills.Add(existingSkill);
                    }
                    else
                    {
                        updatedSkills.Add(skill);
                    }
                }
                
                project.Skills = updatedSkills;
            }

            foreach (var language in existing.ResumeLanguages)
            {
                language.ResumeId = existing.ResumeId;
            }

            _context.SaveChanges();
        }

        public void Delete(long resumeId)
        {
            var entity = _context.Resumes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.Skills)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.Skills)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.Skills)
                .Include(r => r.ResumeProjects)
                    .ThenInclude(p => p.Skills)
                .Include(r => r.ResumeLanguages)
                .FirstOrDefault(r => r.ResumeId == resumeId);

            if (entity == null) return;

            // Remover entidades filhas
            if (entity.ResumeCourses.Any()) _context.ResumeCourses.RemoveRange(entity.ResumeCourses);
            if (entity.ResumeInfos.Any()) _context.ResumeInfos.RemoveRange(entity.ResumeInfos);
            if (entity.ResumeJobs.Any()) _context.ResumeJobs.RemoveRange(entity.ResumeJobs);
            if (entity.ResumeProjects.Any()) _context.ResumeProjects.RemoveRange(entity.ResumeProjects);
            if (entity.ResumeLanguages.Any()) _context.ResumeLanguages.RemoveRange(entity.ResumeLanguages);

            _context.Resumes.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeModel? GetById(long resumeId)
        {
            var entity = _context.Resumes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.Skills)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.Skills)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.Skills)
                .Include(r => r.ResumeProjects)
                    .ThenInclude(p => p.Skills)
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
                .AsSplitQuery()
                .Include(r => r.ResumeCourses)
                    .ThenInclude(c => c.Skills)
                .Include(r => r.ResumeInfos)
                    .ThenInclude(i => i.Skills)
                .Include(r => r.ResumeJobs)
                    .ThenInclude(j => j.Skills)
                .Include(r => r.ResumeProjects)
                    .ThenInclude(p => p.Skills)
                .Include(r => r.ResumeLanguages)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.ResumeId)
                .ToList();

            return entities.Select(e => _mapper.Map<IResumeModel>(e)).ToList();
        }
    }
}
