using AutoMapper;
using ResumeCV.Infra.Context;
using ResumeCV.Infra.Interfaces.Repositories;
using ResumeCV.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResumeCV.Infra.Repositories
{
    public class ResumeSkillRepository : IResumeSkillRepository<IResumeSkillModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeSkillRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IResumeSkillModel Add(IResumeSkillModel resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            // Domain (IResumeSkillModel) -> Infra (ResumeSkill)
            var entity = _mapper.Map<ResumeSkill>(resume);

            _context.ResumeSkills.Add(entity);
            _context.SaveChanges();

            var loaded = _context.ResumeSkills.FirstOrDefault(s => s.SkillId == entity.SkillId);
            if (loaded == null) throw new InvalidOperationException("Erro ao carregar a entidade criada.");

            // Infra -> Domain (IResumeSkillModel)
            var model = _mapper.Map<IResumeSkillModel>(loaded);
            return model;
        }

        public void Delete(long resumeId)
        {
            var entity = _context.ResumeSkills.Find(resumeId);
            if (entity == null) return;

            _context.ResumeSkills.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeSkillModel? GetById(long resumeId)
        {
            var entity = _context.ResumeSkills.Find(resumeId);
            if (entity == null) return null;

            var model = _mapper.Map<IResumeSkillModel>(entity);
            return model;
        }

        public IEnumerable<IResumeSkillModel> List()
        {
            return _context
                .ResumeSkills
                .Select(e => _mapper.Map<IResumeSkillModel>(e))
                .ToList();
        }

        public IResumeSkillModel Update(IResumeSkillModel resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            var existing = _context.ResumeSkills.FirstOrDefault(s => s.SkillId == resume.SkillId);
            if (existing == null) throw new KeyNotFoundException($"ResumeSkill with id {resume.SkillId} not found.");

            // Mapear propriedades da interface para a entidade existente usando AutoMapper
            _mapper.Map(resume, existing);

            _context.SaveChanges();

            var reloaded = _context.ResumeSkills.First(s => s.SkillId == existing.SkillId);
            var model = _mapper.Map<IResumeSkillModel>(reloaded);
            return model;
        }
    }
}
