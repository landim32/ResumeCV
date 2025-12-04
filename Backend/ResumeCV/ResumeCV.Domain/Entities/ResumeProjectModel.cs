using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities
{
    public class ResumeProjectModel : IResumeProjectModel
    {
        private IList<IResumeSkillModel> _skills = new List<IResumeSkillModel>();

        public long ProjectId { get; private set; }
        public long ResumeId { get; private set; }
        public string Title { get; private set; } = null!;
        public DateTime? StartDate { get; private set; }
        public string? Resume { get; private set; }
        public string? Url { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public IList<IResumeSkillModel> Skills
        {
            get
            {
                return _skills;
            }
        }

        // Construtor de criação com validações de domínio
        public ResumeProjectModel(
            long projectId,
            long resumeId,
            string title,
            DateTime? startDate = null,
            string? description = null,
            string? url = null,
            ProjectStatusEnum status = ProjectStatusEnum.Completed)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            if (url is not null && url.Length > 1000) throw new ArgumentException("Url excede o tamanho máximo (1000).", nameof(url));
            if (status < 0) throw new ArgumentException("Status deve ser maior ou igual a zero.", nameof(status));

            ProjectId = projectId;
            ResumeId = resumeId;
            Title = title.Trim();
            StartDate = startDate;
            Resume = description;
            Url = string.IsNullOrWhiteSpace(url) ? null : url.Trim();
            Status = status;
        }

        // Operações de domínio
        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            Title = title.Trim();
        }

        public void UpdateStartDate(DateTime? startDate)
        {
            StartDate = startDate;
        }

        public void UpdateDescription(string? description)
        {
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            Resume = description;
        }

        public void UpdateUrl(string? url)
        {
            if (url is not null && url.Length > 1000) throw new ArgumentException("Url excede o tamanho máximo (1000).", nameof(url));
            Url = string.IsNullOrWhiteSpace(url) ? null : url.Trim();
        }

        public void UpdateStatus(ProjectStatusEnum status)
        {
            //if (status < 0) throw new ArgumentException("Status deve ser maior ou igual a zero.", nameof(status));
            Status = status;
        }

        public void ClearSkills()
        {
            _skills.Clear();
        }

        public void AddSkill(IResumeSkillModel skill)
        {
            if (skill is null) throw new ArgumentNullException(nameof(skill), "Skill não pode ser nulo.");
            if (_skills.Contains(skill)) throw new InvalidOperationException("Skill já adicionada.");
            _skills.Add(skill);
        }
    }
}
