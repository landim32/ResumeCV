using ResumeCV.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeCV.Domain.Entities
{
    public class ResumeJobModel: IResumeJobModel
    {
        private IList<IResumeSkillModel> _skills = new List<IResumeSkillModel>();

        public long JobId { get; private set; }
        public long ResumeId { get; private set; }
        public string Position { get; private set; } = null!;
        public string Business1 { get; private set; } = null!;
        public string? Business2 { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string? Location { get; private set; }
        public string? Resume { get; private set; }
        public IList<IResumeSkillModel> Skills
        {
            get
            {
                return _skills;
            }
        }   

        // Construtor de criação com validações de domínio
        public ResumeJobModel(
            long jobId,
            long resumeId,
            string position,
            string business1,
            DateTime startDate,
            DateTime? endDate = null,
            string? business2 = null,
            string? location = null,
            string? description = null)
        {
            //if (jobId <= 0) throw new ArgumentException("JobId deve ser maior que zero.", nameof(jobId));
            //if (resumeId <= 0) throw new ArgumentException("ResumeId deve ser maior que zero.", nameof(resumeId));
            if (string.IsNullOrWhiteSpace(position)) throw new ArgumentException("Position é obrigatório.", nameof(position));
            if (string.IsNullOrWhiteSpace(business1)) throw new ArgumentException("Business1 é obrigatório.", nameof(business1));
            if (position.Length > 500) throw new ArgumentException("Position excede o tamanho máximo (500).", nameof(position));
            if (business1.Length > 500) throw new ArgumentException("Business1 excede o tamanho máximo (500).", nameof(business1));
            if (business2 is not null && business2.Length > 500) throw new ArgumentException("Business2 excede o tamanho máximo (500).", nameof(business2));
            if (location is not null && location.Length > 200) throw new ArgumentException("Location excede o tamanho máximo (200).", nameof(location));
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            if (endDate is not null && endDate < startDate) throw new ArgumentException("EndDate não pode ser anterior a StartDate.", nameof(endDate));

            JobId = jobId;
            ResumeId = resumeId;
            Position = position.Trim();
            Business1 = business1.Trim();
            Business2 = string.IsNullOrWhiteSpace(business2) ? null : business2.Trim();
            StartDate = startDate;
            EndDate = endDate;
            Location = string.IsNullOrWhiteSpace(location) ? null : location.Trim();
            Resume = description;
        }

        // Operações de domínio
        public void UpdatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position)) throw new ArgumentException("Position é obrigatório.", nameof(position));
            if (position.Length > 500) throw new ArgumentException("Position excede o tamanho máximo (500).", nameof(position));
            Position = position.Trim();
        }

        public void UpdateBusiness1(string business1)
        {
            if (string.IsNullOrWhiteSpace(business1)) throw new ArgumentException("Business1 é obrigatório.", nameof(business1));
            if (business1.Length > 500) throw new ArgumentException("Business1 excede o tamanho máximo (500).", nameof(business1));
            Business1 = business1.Trim();
        }

        public void UpdateBusiness2(string? business2)
        {
            if (business2 is not null && business2.Length > 500) throw new ArgumentException("Business2 excede o tamanho máximo (500).", nameof(business2));
            Business2 = string.IsNullOrWhiteSpace(business2) ? null : business2.Trim();
        }

        public void UpdateLocation(string? location)
        {
            if (location is not null && location.Length > 200) throw new ArgumentException("Location excede o tamanho máximo (200).", nameof(location));
            Location = string.IsNullOrWhiteSpace(location) ? null : location.Trim();
        }

        public void UpdateDescription(string? description)
        {
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            Resume = description;
        }

        public void UpdateStartDate(DateTime startDate)
        {
            if (EndDate is not null && startDate > EndDate) throw new ArgumentException("StartDate não pode ser posterior a EndDate.", nameof(startDate));
            StartDate = startDate;
        }

        public void UpdateEndDate(DateTime? endDate)
        {
            if (endDate is not null && endDate < StartDate) throw new ArgumentException("EndDate não pode ser anterior a StartDate.", nameof(endDate));
            EndDate = endDate;
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
