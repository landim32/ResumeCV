using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeJob
{
    public long JobId { get; set; }

    public long ResumeId { get; set; }

    public string Position { get; set; } = null!;

    public string Business1 { get; set; } = null!;

    public string? Business2 { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Location { get; set; }

    public string? Resume { get; set; }

    public virtual ICollection<ResumeJobSkill> ResumeJobSkills { get; set; } = new List<ResumeJobSkill>();

    public virtual Resume ResumeNavigation { get; set; } = null!;
}
