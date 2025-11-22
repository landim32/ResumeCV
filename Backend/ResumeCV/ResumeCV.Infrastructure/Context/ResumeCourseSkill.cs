using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeCourseSkill
{
    public long CourseSkillId { get; set; }

    public long CourseId { get; set; }

    public long SkillId { get; set; }

    public virtual ResumeCourse Course { get; set; } = null!;

    public virtual ResumeSkill Skill { get; set; } = null!;
}
