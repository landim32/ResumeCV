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
    public enum SkillTypeEnum
    {
        Programming = 1,
        Database = 4,
        Infraestruture = 5,
        ArquitetureDesign = 6,
        Tools = 7,
        DevOps = 8,
        Methodology = 9,
        Security = 11,
        Cloud = 12,
        Tests = 13,
        Agile = 14,
        OperatingSystem = 15,
        Library = 16,
        Observability = 17,
        SoftSkill = 18
    }
}
