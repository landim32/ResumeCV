using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeProject
{
    public long ProjectId { get; set; }

    public long ResumeId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public string? Resume { get; set; }

    public string? Url { get; set; }

    public int Status { get; set; }

    public virtual Resume ResumeNavigation { get; set; } = null!;

    public virtual ICollection<ResumeSkill> Skills { get; set; } = new List<ResumeSkill>();
}
