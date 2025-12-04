using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    /// <summary>
    /// Contrato para a entidade ResumeProjectModel contendo propriedades e operações de domínio.
    /// </summary>
    public interface IResumeProjectModel
    {
        long ProjectId { get; }
        long ResumeId { get; }
        string Title { get; }
        DateTime? StartDate { get; }
        string? Resume { get; }
        string? Url { get; }
        ProjectStatusEnum Status { get; }
        IList<IResumeSkillModel> Skills { get; }

        void UpdateTitle(string title);
        void UpdateStartDate(DateTime? startDate);
        void UpdateDescription(string? description);
        void UpdateUrl(string? url);
        void UpdateStatus(ProjectStatusEnum status);

        void ClearSkills();
        void AddSkill(IResumeSkillModel skill);
    }
}
