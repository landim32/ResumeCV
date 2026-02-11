using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    public interface IResumeCourseModel
    {
        // Propriedades de leitura correspondentes ao agregado de domínio
        long CourseId { get; }
        long ResumeId { get; }
        CourseTypeEnum CourseType { get; }
        string Title { get; }
        string? Location { get; }
        string? Institute { get; }
        string? Resume { get; }
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
        int? Workload { get; }
        IList<IResumeSkillModel> Skills { get; }

        // Operações de domínio (métodos públicos expostos pela entidade)
        void UpdateTitle(string title);
        void UpdateLocation(string? location);
        void UpdateInstitute(string? institute);
        void UpdateDescription(string? description);

        void SetCourseType(CourseTypeEnum courseType);

        void SetStartDate(DateTime? start);
        void SetEndDate(DateTime? end);
        void SetDates(DateTime? start, DateTime? end);
        void SetWorkload(int? workload);

        void ClearSkills();
        public void AddSkill(IResumeSkillModel skill);
    }
}
