using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class Resume
{
    public long ResumeId { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Status { get; set; }

    public string? Address { get; set; }

    public string? Resume1 { get; set; }

    public string Title { get; set; } = null!;

    public string JobDescription { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public virtual ICollection<ResumeCourse> ResumeCourses { get; set; } = new List<ResumeCourse>();

    public virtual ICollection<ResumeInfo> ResumeInfos { get; set; } = new List<ResumeInfo>();

    public virtual ICollection<ResumeJob> ResumeJobs { get; set; } = new List<ResumeJob>();

    public virtual ICollection<ResumeLanguage> ResumeLanguages { get; set; } = new List<ResumeLanguage>();
}
