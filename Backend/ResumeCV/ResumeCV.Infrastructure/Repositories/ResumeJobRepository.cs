using AutoMapper;
using ResumeCV.Domain.Entities;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ResumeCV.Infra.Interfaces.Repositories;

namespace ResumeCV.Infra.Repositories
{
    public class ResumeJobRepository : IResumeJobRepository<IResumeJobModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeJobRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IResumeJobModel Add(IResumeJobModel job)
        {
            if (job is null) throw new ArgumentNullException(nameof(job));

            // Domain (IResumeJobModel) -> Infra (ResumeJob)
            var entity = _mapper.Map<ResumeJob>(job);

            _context.ResumeJobs.Add(entity);
            _context.SaveChanges();

            // Persistir skills associados (tabela de junção)
            if (job.Skills != null && job.Skills.Count > 0)
            {
                var joinEntries = job.Skills.Select(s => new ResumeJobSkill
                {
                    JobId = entity.JobId,
                    SkillId = s.SkillId
                }).ToList();

                _context.ResumeJobSkills.AddRange(joinEntries);
                _context.SaveChanges();
            }

            // Recarrega com relacionamentos e mapear para IResumeJobModel usando AutoMapper
            var loaded = _context.ResumeJobs
                                 .Include(j => j.ResumeJobSkills)
                                     .ThenInclude(js => js.Skill)
                                 .Include(j => j.ResumeNavigation)
                                 .FirstOrDefault(j => j.JobId == entity.JobId);

            if (loaded == null) throw new InvalidOperationException("Erro ao carregar a entidade criada.");

            var model = _mapper.Map<IResumeJobModel>(loaded);
            return model;
        }

        public void Delete(long jobId)
        {
            var entity = _context.ResumeJobs.Find(jobId);
            if (entity == null) return;

            // Remove join entries primeiro (segurança)
            var joins = _context.ResumeJobSkills.Where(j => j.JobId == jobId).ToList();
            if (joins.Count > 0)
            {
                _context.ResumeJobSkills.RemoveRange(joins);
            }

            _context.ResumeJobs.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeJobModel? GetById(long jobId)
        {
            var entity = _context.ResumeJobs
                                 .AsNoTracking()
                                 .Include(j => j.ResumeJobSkills)
                                     .ThenInclude(js => js.Skill)
                                 .Include(j => j.ResumeNavigation)
                                 .FirstOrDefault(j => j.JobId == jobId);

            if (entity == null) return null;

            var model = _mapper.Map<IResumeJobModel>(entity);
            return model;
        }

        public IEnumerable<IResumeJobModel> ListByResume(long resumeId)
        {
            var entities = _context.ResumeJobs
                                   .AsNoTracking()
                                   .Where(j => j.ResumeId == resumeId)
                                   .Include(j => j.ResumeJobSkills)
                                       .ThenInclude(js => js.Skill)
                                   .Include(j => j.ResumeNavigation)
                                   .ToList();

            return entities.Select(e => _mapper.Map<IResumeJobModel>(e)).ToList();
        }

        public IResumeJobModel Update(IResumeJobModel job)
        {
            if (job is null) throw new ArgumentNullException(nameof(job));

            var existing = _context.ResumeJobs
                                   .Include(j => j.ResumeJobSkills)
                                   .FirstOrDefault(j => j.JobId == job.JobId);

            if (existing == null) throw new KeyNotFoundException($"ResumeJob with id {job.JobId} not found.");

            // Mapear propriedades do modelo para a entidade existente usando AutoMapper.
            _mapper.Map(job, existing);

            // Atualiza skills: remover todos e re-adicionar conforme modelo de domínio
            var currentJoins = existing.ResumeJobSkills.ToList();
            if (currentJoins.Count > 0)
            {
                _context.ResumeJobSkills.RemoveRange(currentJoins);
            }

            if (job.Skills != null && job.Skills.Count > 0)
            {
                var newJoins = job.Skills.Select(s => new ResumeJobSkill
                {
                    JobId = existing.JobId,
                    SkillId = s.SkillId
                });
                _context.ResumeJobSkills.AddRange(newJoins);
            }

            _context.SaveChanges();

            // Recarrega e mapeia para IResumeJobModel atualizado
            var reloaded = _context.ResumeJobs
                                   .Include(j => j.ResumeJobSkills)
                                       .ThenInclude(js => js.Skill)
                                   .Include(j => j.ResumeNavigation)
                                   .First(j => j.JobId == existing.JobId);

            var model = _mapper.Map<IResumeJobModel>(reloaded);
            return model;
        }
    }
}
