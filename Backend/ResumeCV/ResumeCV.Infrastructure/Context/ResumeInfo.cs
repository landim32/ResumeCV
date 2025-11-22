using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeInfo
{
    public long InfoId { get; set; }

    public long ResumeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Resume { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<ResumeInfoSkill> ResumeInfoSkills { get; set; } = new List<ResumeInfoSkill>();

    public virtual Resume ResumeNavigation { get; set; } = null!;
}
