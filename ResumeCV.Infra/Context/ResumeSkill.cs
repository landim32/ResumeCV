using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeSkill
{
    public long SkillId { get; set; }

    public int SkillType { get; set; }

    public string Slug { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ResumeCourse> Courses { get; set; } = new List<ResumeCourse>();

    public virtual ICollection<ResumeInfo> Infos { get; set; } = new List<ResumeInfo>();

    public virtual ICollection<ResumeJob> Jobs { get; set; } = new List<ResumeJob>();

    public virtual ICollection<ResumeProject> Projects { get; set; } = new List<ResumeProject>();
}
