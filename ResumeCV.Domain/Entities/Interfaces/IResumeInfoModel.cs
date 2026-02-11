using ResumeCV.DTOs.Enums;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    /// <summary>
    /// Contrato para a entidade ResumeInfoModel contendo propriedades e operações de domínio.
    /// </summary>
    public interface IResumeInfoModel
    {
        long InfoId { get; }
        long ResumeId { get; }
        public InfoTypeEnum InfoType { get; set; }
        string Title { get; }
        string? Resume { get; }
        string? Url { get; }
        IList<IResumeSkillModel> Skills { get;  }

        void UpdateInfoType(InfoTypeEnum infoType);
        void UpdateTitle(string title);
        void UpdateDescription(string? description);
        void UpdateUrl(string? url);

        void ClearSkills();
        public void AddSkill(IResumeSkillModel skill);
    }
}
