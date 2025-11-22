using System;
using System.Collections.Generic;

namespace ResumeCV.Infra.Context;

public partial class ResumeLanguage
{
    public long LanguageId { get; set; }

    public long ResumeId { get; set; }

    public string Language { get; set; } = null!;

    public int Level { get; set; }

    public virtual Resume Resume { get; set; } = null!;
}
