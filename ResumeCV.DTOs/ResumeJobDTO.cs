using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ResumeCV.DTOs
{
    public class ResumeJobDTO
    {
        [JsonProperty("jobId")]
        public long JobId { get; set; }
        /*
        [JsonProperty("resumeId")]
        public long ResumeId { get; set; }
        */
        [JsonProperty("position")]
        public string Position { get; set; } = string.Empty;

        [JsonProperty("business1")]
        public string Business1 { get; set; } = string.Empty;

        [JsonProperty("business2", NullValueHandling = NullValueHandling.Ignore)]
        public string? Business2 { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndDate { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string? Location { get; set; }

        [JsonProperty("resume", NullValueHandling = NullValueHandling.Ignore)]
        public string? Resume { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeSkillDTO>? Skills { get; set; } = new List<ResumeSkillDTO>();
    }
}
