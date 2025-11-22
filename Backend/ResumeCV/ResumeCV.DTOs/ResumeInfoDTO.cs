using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ResumeCV.DTOs
{
    public class ResumeInfoDTO
    {
        [JsonProperty("infoId")]
        public long InfoId { get; set; }
        /*
        [JsonProperty("resumeId")]
        public long ResumeId { get; set; }
        */

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("resume", NullValueHandling = NullValueHandling.Ignore)]
        public string? Resume { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string? Url { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeSkillDTO>? Skills { get; set; } = new List<ResumeSkillDTO>();
    }
}
