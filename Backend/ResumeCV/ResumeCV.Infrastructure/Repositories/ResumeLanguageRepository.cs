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
    public class ResumeLanguageRepository : IResumeLanguageRepository<IResumeLanguageModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeLanguageRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IResumeLanguageModel Add(IResumeLanguageModel language)
        {
            if (language is null) throw new ArgumentNullException(nameof(language));

            // Domain (IResumeLanguageModel) -> Infra (ResumeLanguage)
            var entity = _mapper.Map<ResumeLanguage>(language);

            _context.ResumeLanguages.Add(entity);
            _context.SaveChanges();

            // Recarrega com navegações e retorna como interface via AutoMapper
            var loaded = _context.ResumeLanguages
                                 .Include(l => l.Resume)
                                 .FirstOrDefault(l => l.LanguageId == entity.LanguageId);

            if (loaded == null) throw new InvalidOperationException("Erro ao carregar a entidade criada.");

            var model = _mapper.Map<IResumeLanguageModel>(loaded);
            return model;
        }

        public void Delete(long languageId)
        {
            var entity = _context.ResumeLanguages.Find(languageId);
            if (entity == null) return;

            _context.ResumeLanguages.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeLanguageModel? GetById(long languageId)
        {
            var entity = _context.ResumeLanguages
                                 .AsNoTracking()
                                 .Include(l => l.Resume)
                                 .FirstOrDefault(l => l.LanguageId == languageId);

            if (entity == null) return null;

            var model = _mapper.Map<IResumeLanguageModel>(entity);
            return model;
        }

        public IEnumerable<IResumeLanguageModel> ListByResume(long resumeId)
        {
            var entities = _context.ResumeLanguages
                                   .AsNoTracking()
                                   .Where(l => l.ResumeId == resumeId)
                                   .Include(l => l.Resume)
                                   .ToList();

            return entities.Select(e => _mapper.Map<IResumeLanguageModel>(e)).ToList();
        }

        public IResumeLanguageModel Update(IResumeLanguageModel language)
        {
            if (language is null) throw new ArgumentNullException(nameof(language));

            var existing = _context.ResumeLanguages.FirstOrDefault(l => l.LanguageId == language.LanguageId);
            if (existing == null) throw new KeyNotFoundException($"ResumeLanguage with id {language.LanguageId} not found.");

            // Mapear propriedades do modelo (interface) para a entidade existente
            _mapper.Map(language, existing);

            _context.SaveChanges();

            var reloaded = _context.ResumeLanguages
                                   .Include(l => l.Resume)
                                   .First(l => l.LanguageId == existing.LanguageId);

            var model = _mapper.Map<IResumeLanguageModel>(reloaded);
            return model;
        }
    }
}
