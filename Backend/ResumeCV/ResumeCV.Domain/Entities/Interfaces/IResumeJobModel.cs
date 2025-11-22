using System;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    /// <summary>
    /// Contrato para a entidade ResumeJobModel contendo propriedades e operações de domínio.
    /// </summary>
    public interface IResumeJobModel
    {
        long JobId { get; }
        long ResumeId { get; }
        string Position { get; }
        string Business1 { get; }
        string? Business2 { get; }
        DateTime StartDate { get; }
        DateTime? EndDate { get; }
        string? Location { get; }
        string? Resume { get; }
        IList<IResumeSkillModel> Skills { get; }

        void UpdatePosition(string position);
        void UpdateBusiness1(string business1);
        void UpdateBusiness2(string? business2);
        void UpdateLocation(string? location);
        void UpdateDescription(string? description);
        void UpdateStartDate(DateTime startDate);
        void UpdateEndDate(DateTime? endDate);

        void ClearSkills();
        public void AddSkill(IResumeSkillModel skill);
    }
}
