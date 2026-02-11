using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.DTOs.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InfoTypeEnum
    {
        Links = 1,
        Conquests = 2,
        Certifications = 3,
        Projects = 4
    }
}
