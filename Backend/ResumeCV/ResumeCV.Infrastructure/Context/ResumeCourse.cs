using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeCourse
{
    public long CourseId { get; set; }

    public long ResumeId { get; set; }

    public int? CourseType { get; set; }

    public string Title { get; set; } = null!;

    public string? Location { get; set; }

    public string? Institute { get; set; }

    public string? Resume { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<ResumeCourseSkill> ResumeCourseSkills { get; set; } = new List<ResumeCourseSkill>();

    public virtual Resume ResumeNavigation { get; set; } = null!;
}
