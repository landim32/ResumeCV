using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.DTOs
{
    public class ResumeSkillDTO
    {
        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string? Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("skillType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SkillTypeEnum SkillType { get; set; }
    }
}
