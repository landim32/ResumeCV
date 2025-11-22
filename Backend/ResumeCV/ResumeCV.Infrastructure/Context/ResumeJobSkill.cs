using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeJobSkill
{
    public long JobSkillId { get; set; }

    public long JobId { get; set; }

    public long SkillId { get; set; }

    public virtual ResumeJob Job { get; set; } = null!;

    public virtual ResumeSkill Skill { get; set; } = null!;
}
