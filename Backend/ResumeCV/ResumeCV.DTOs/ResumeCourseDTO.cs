using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ResumeCV.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace ResumeCV.DTOs
{
    public class ResumeCourseDTO
    {
        [JsonProperty("courseId")]
        public long CourseId { get; set; }

        [JsonProperty("courseType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CourseTypeEnum CourseType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string? Location { get; set; }

        [JsonProperty("institute", NullValueHandling = NullValueHandling.Ignore)]
        public string? Institute { get; set; }

        [JsonProperty("resume", NullValueHandling = NullValueHandling.Ignore)]
        public string? Resume { get; set; }

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndDate { get; set; }
        [JsonProperty("workload")]
        public int Workload { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeSkillDTO>? Skills { get; set; } = new List<ResumeSkillDTO>();
    }
}
