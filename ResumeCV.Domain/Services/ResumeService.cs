using AutoMapper;
using ResumeCV.Domain.Services.Interfaces;
using ResumeCV.DTOs;
using ResumeCV.Infra.Interfaces.Repositories;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Infra.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using ResumeCV.Domain.Templates;
using ResumeCV.Domain.Templates.Factories.Interfaces;

namespace ResumeCV.Domain.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository<IResumeModel> _resumeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPdfTemplateFactory _templateFactory;

        public ResumeService(
            IResumeRepository<IResumeModel> resumeRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IPdfTemplateFactory templateFactory
        )
        {
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _templateFactory = templateFactory ?? throw new ArgumentNullException(nameof(templateFactory));
        }

        public long Add(ResumeDTO resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            // DTO -> Domain (ResumeModel implementing IResumeModel)
            var model = _mapper.Map<Domain.Entities.ResumeModel>(resume);

            using var tx = _unitOfWork.BeginTransaction();
            try
            {
                var resumeId = _resumeRepository.Add(model);
                tx.Commit();
                return resumeId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public void Delete(long resumeId)
        {
            if (resumeId <= 0) throw new ArgumentException("resumeId deve ser maior que zero.", nameof(resumeId));

            using var tx = _unitOfWork.BeginTransaction();
            try
            {
                _resumeRepository.Delete(resumeId);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public ResumeDTO? GetById(long resumeId)
        {
            if (resumeId <= 0) throw new ArgumentException("resumeId deve ser maior que zero.", nameof(resumeId));

            var model = _resumeRepository.GetById(resumeId);
            if (model == null) return null;

            var dto = _mapper.Map<ResumeDTO>(model);
            return dto;
        }

        public IList<ResumeDTO> ListByUser(long userId)
        {
            if (userId <= 0) throw new ArgumentException("userId deve ser maior que zero.", nameof(userId));

            var models = _resumeRepository.ListByUserId(userId);
            var list = models
                .Select(m => _mapper.Map<ResumeDTO>(m))
                .ToList();

            return list;
        }

        public void Update(ResumeDTO resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            // DTO -> Domain (ResumeModel implementing IResumeModel)
            var model = _mapper.Map<Domain.Entities.ResumeModel>(resume);

            using var tx = _unitOfWork.BeginTransaction();
            try
            {
                _resumeRepository.Update(model);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public Stream GeneratePdf(long resumeId)
        {
            if (resumeId <= 0) throw new ArgumentException("resumeId deve ser maior que zero.", nameof(resumeId));

            var model = _resumeRepository.GetById(resumeId);
            if (model == null) throw new Exception("Resume not found.");

            // Lógica para gerar o PDF a partir do modelo
            var pdfModel = _templateFactory.Create();
            return pdfModel.GeneratePdf(model);
        }
    }
}
