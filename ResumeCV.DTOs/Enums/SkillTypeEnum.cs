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
        Database = 2,
        Methodology = 3,
        Tools = 4,
        Infraestruture = 5,
        ArquitetureDesign = 6,
        DevOps = 7,
        Security = 8,
        Cloud = 9,
        Tests = 10,
        Agile = 11,
        OperatingSystem = 12,
        Library = 13,
        Observability = 14,
        SoftSkill = 15
    }
}
