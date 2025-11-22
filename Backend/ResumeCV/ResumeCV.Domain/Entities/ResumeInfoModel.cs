using ResumeCV.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeCV.Domain.Entities
{
    public class ResumeInfoModel: IResumeInfoModel
    {
        private IList<IResumeSkillModel> _skills = new List<IResumeSkillModel>();

        public long InfoId { get; private set; }
        public long ResumeId { get; private set; }
        public string Title { get; private set; } = null!;
        public string? Resume { get; private set; }
        public string? Url { get; private set; }
        public IList<IResumeSkillModel> Skills { 
            get
            {
                return _skills;
            }
        }

        public ResumeInfoModel(long infoId, long resumeId, string title, string? description = null, string? url = null)
        {
            //if (infoId <= 0) throw new ArgumentException("InfoId deve ser maior que zero.", nameof(infoId));
            //if (resumeId <= 0) throw new ArgumentException("ResumeId deve ser maior que zero.", nameof(resumeId));
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            if (url is not null && url.Length > 2000) throw new ArgumentException("Url excede o tamanho máximo (2000).", nameof(url));

            InfoId = infoId;
            ResumeId = resumeId;
            Title = title.Trim();
            Resume = description;
            Url = string.IsNullOrWhiteSpace(url) ? null : url.Trim();
        }

        // Operações de domínio
        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            Title = title.Trim();
        }

        public void UpdateDescription(string? description)
        {
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            Resume = description;
        }

        public void UpdateUrl(string? url)
        {
            if (url is not null)
            {
                if (url.Length > 2000) throw new ArgumentException("Url excede o tamanho máximo (2000).", nameof(url));
                Url = string.IsNullOrWhiteSpace(url) ? null : url.Trim();
            }
            else
            {
                Url = null;
            }
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
