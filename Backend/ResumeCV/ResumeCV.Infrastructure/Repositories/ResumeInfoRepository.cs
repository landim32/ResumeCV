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
    public class ResumeInfoRepository : IResumeInfoRepository<IResumeInfoModel>
    {
        private readonly ResumeCVContext _context;
        private readonly IMapper _mapper;

        public ResumeInfoRepository(ResumeCVContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IResumeInfoModel Add(IResumeInfoModel info)
        {
            if (info is null) throw new ArgumentNullException(nameof(info));

            // DTO/Domain (IResumeInfoModel) -> Infra (ResumeInfo) via AutoMapper
            var entity = _mapper.Map<ResumeInfo>(info);

            _context.ResumeInfos.Add(entity);
            _context.SaveChanges();

            // Recarrega com relacionamentos para garantir navegações preenchidas
            var loaded = _context.ResumeInfos
                                 .Include(i => i.ResumeInfoSkills)
                                     .ThenInclude(isk => isk.Skill)
                                 .Include(i => i.ResumeNavigation)
                                 .FirstOrDefault(i => i.InfoId == entity.InfoId);

            if (loaded == null) throw new InvalidOperationException("Não foi possível recarregar ResumeInfo criado.");

            // Infra -> Domain (interface IResumeInfoModel) via AutoMapper
            var model = _mapper.Map<IResumeInfoModel>(loaded);
            return model;
        }

        public void Delete(long courseId)
        {
            var entity = _context.ResumeInfos.Find(courseId);
            if (entity == null) return;

            // Remove join entries primeiro (segurança)
            var joins = _context.ResumeInfoSkills.Where(j => j.InfoId == courseId).ToList();
            if (joins.Count > 0)
            {
                _context.ResumeInfoSkills.RemoveRange(joins);
            }

            _context.ResumeInfos.Remove(entity);
            _context.SaveChanges();
        }

        public IResumeInfoModel? GetById(long courseId)
        {
            var entity = _context.ResumeInfos
                                 .AsNoTracking()
                                 .Include(i => i.ResumeInfoSkills)
                                     .ThenInclude(isk => isk.Skill)
                                 .Include(i => i.ResumeNavigation)
                                 .FirstOrDefault(i => i.InfoId == courseId);

            if (entity == null) return null;

            var model = _mapper.Map<IResumeInfoModel>(entity);
            return model;
        }

        public IEnumerable<IResumeInfoModel> ListByResumeId(long resumeId)
        {
            var entities = _context.ResumeInfos
                                   .AsNoTracking()
                                   .Where(i => i.ResumeId == resumeId)
                                   .Include(i => i.ResumeInfoSkills)
                                       .ThenInclude(isk => isk.Skill)
                                   .Include(i => i.ResumeNavigation)
                                   .ToList();

            return entities.Select(e => _mapper.Map<IResumeInfoModel>(e)).ToList();
        }

        public IResumeInfoModel Update(IResumeInfoModel info)
        {
            if (info is null) throw new ArgumentNullException(nameof(info));

            var existing = _context.ResumeInfos
                                   .Include(i => i.ResumeInfoSkills)
                                   .FirstOrDefault(i => i.InfoId == info.InfoId);

            if (existing == null) throw new KeyNotFoundException($"ResumeInfo with id {info.InfoId} not found.");

            // Atualiza campos mutáveis usando a interface
            existing.Title = info.Title;
            existing.Resume = info.Resume;
            existing.Url = info.Url;
            existing.ResumeId = info.ResumeId;

            // Atualiza skills: remover todos e re-adicionar conforme modelo de domínio
            var currentJoins = existing.ResumeInfoSkills.ToList();
            if (currentJoins.Count > 0)
            {
                _context.ResumeInfoSkills.RemoveRange(currentJoins);
            }

            if (info.Skills != null && info.Skills.Count > 0)
            {
                var newJoins = info.Skills.Select(s => new ResumeInfoSkill
                {
                    InfoId = existing.InfoId,
                    SkillId = s.SkillId
                });
                _context.ResumeInfoSkills.AddRange(newJoins);
            }

            _context.SaveChanges();

            // Recarrega e mapeia para IResumeInfoModel atualizado
            var reloaded = _context.ResumeInfos
                                   .Include(i => i.ResumeInfoSkills)
                                       .ThenInclude(isk => isk.Skill)
                                   .Include(i => i.ResumeNavigation)
                                   .First(i => i.InfoId == existing.InfoId);

            var model = _mapper.Map<IResumeInfoModel>(reloaded);
            return model;
        }
    }
}
