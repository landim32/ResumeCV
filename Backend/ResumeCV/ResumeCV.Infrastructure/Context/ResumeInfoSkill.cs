using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeInfoSkill
{
    public long InfoSkillId { get; set; }

    public long InfoId { get; set; }

    public long SkillId { get; set; }

    public virtual ResumeInfo Info { get; set; } = null!;

    public virtual ResumeSkill Skill { get; set; } = null!;
}
