using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.DTOs
{
    public class ResumeSkillDTO
    {
        /*
        [JsonProperty("skillId")]
        public long SkillId { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }
        */

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string? Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}
