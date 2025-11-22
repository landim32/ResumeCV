using System;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    public interface IResumeCourseModel
    {
        // Propriedades de leitura correspondentes ao agregado de domínio
        long CourseId { get; }
        long ResumeId { get; }
        int? CourseType { get; }
        string Title { get; }
        string? Location { get; }
        string? Institute { get; }
        string? Resume { get; }
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
        IList<IResumeSkillModel> Skills { get; }

        // Operações de domínio (métodos públicos expostos pela entidade)
        void UpdateTitle(string title);
        void UpdateLocation(string? location);
        void UpdateInstitute(string? institute);
        void UpdateDescription(string? description);

        void SetCourseType(int? courseType);

        void SetStartDate(DateTime? start);
        void SetEndDate(DateTime? end);
        void SetDates(DateTime? start, DateTime? end);

        void ClearSkills();
        public void AddSkill(IResumeSkillModel skill);
    }
}
