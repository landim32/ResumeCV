using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeCV.Domain.Entities
{
    public class ResumeCourseModel: IResumeCourseModel
    {
        private IList<IResumeSkillModel> _skills = new List<IResumeSkillModel>();

        public long CourseId { get; private set; }
        public long ResumeId { get; private set; }
        public CourseTypeEnum CourseType { get; private set; }
        public string Title { get; private set; } = null!;
        public string? Location { get; private set; }
        public string? Institute { get; private set; }
        public string? Resume { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public int? Workload { get; private set; }
        public IList<IResumeSkillModel> Skills { get => _skills; }

        public ResumeCourseModel(long courseId, long resumeId, string title, CourseTypeEnum courseType, int? workload)
        {
            //if (courseId <= 0) throw new ArgumentException("CourseId deve ser maior que zero.", nameof(courseId));
            //if (resumeId <= 0) throw new ArgumentException("ResumeId deve ser maior que zero.", nameof(resumeId));
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));

            CourseId = courseId;
            ResumeId = resumeId;
            Title = title.Trim();
            CourseType = courseType;
            Workload = workload;
        }

        // Operações de domínio
        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            Title = title.Trim();
        }

        public void UpdateLocation(string? location)
        {
            if (location is not null && location.Length > 250) throw new ArgumentException("Location excede o tamanho máximo (250).", nameof(location));
            Location = location?.Trim();
        }

        public void UpdateInstitute(string? institute)
        {
            if (institute is not null && institute.Length > 250) throw new ArgumentException("Institute excede o tamanho máximo (250).", nameof(institute));
            Institute = institute?.Trim();
        }

        public void UpdateDescription(string? description)
        {
            if (description is not null && description.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(description));
            Resume = description;
        }

        public void SetCourseType(CourseTypeEnum courseType)
        {
            CourseType = courseType;
        }

        public void SetStartDate(DateTime? start)
        {
            if (start.HasValue && EndDate.HasValue && start > EndDate)
                throw new ArgumentException("StartDate não pode ser posterior à EndDate.", nameof(start));
            StartDate = start;
        }

        public void SetEndDate(DateTime? end)
        {
            if (StartDate.HasValue && end.HasValue && end < StartDate)
                throw new ArgumentException("EndDate não pode ser anterior à StartDate.", nameof(end));
            EndDate = end;
        }

        public void SetDates(DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue && start > end)
                throw new ArgumentException("StartDate não pode ser posterior à EndDate.");
            StartDate = start;
            EndDate = end;
        }

        public void SetWorkload(int? workload)
        {
            Workload = workload;
        }

        public void ClearSkills()
        {
            _skills.Clear();
        }   

        public void AddSkill(IResumeSkillModel skill)
        {
            _skills.Add(skill);
        }
    }
}
