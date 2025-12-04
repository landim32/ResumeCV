using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace ResumeCV.DTOs
{
    public class ResumeProjectDTO
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartDate { get; set; }

        [JsonProperty("resume", NullValueHandling = NullValueHandling.Ignore)]
        public string? Resume { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string? Url { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatusEnum Status { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeSkillDTO>? Skills { get; set; } = new List<ResumeSkillDTO>();
    }
}
