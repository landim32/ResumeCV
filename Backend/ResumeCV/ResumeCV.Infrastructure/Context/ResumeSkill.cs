using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeSkill
{
    public long SkillId { get; set; }

    public long UserId { get; set; }

    public string Slug { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ResumeCourseSkill> ResumeCourseSkills { get; set; } = new List<ResumeCourseSkill>();

    public virtual ICollection<ResumeInfoSkill> ResumeInfoSkills { get; set; } = new List<ResumeInfoSkill>();

    public virtual ICollection<ResumeJobSkill> ResumeJobSkills { get; set; } = new List<ResumeJobSkill>();
}
