using Newtonsoft.Json;
using System.Collections.Generic;

namespace ResumeCV.DTOs
{
    public class ResumeDTO
    {
        [JsonProperty("resumeId")]
        public long ResumeId { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("jobDescription")]
        public string JobDescription { get; set; } = string.Empty;

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; } = string.Empty;

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address { get; set; }

        [JsonProperty("resume", NullValueHandling = NullValueHandling.Ignore)]
        public string? Resume { get; set; }

        [JsonProperty("courses", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeCourseDTO>? Courses { get; set; } = new List<ResumeCourseDTO>();

        [JsonProperty("infos", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeInfoDTO>? Infos { get; set; } = new List<ResumeInfoDTO>();

        [JsonProperty("jobs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeJobDTO>? Jobs { get; set; } = new List<ResumeJobDTO>();

        [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeProjectDTO>? Projects { get; set; } = new List<ResumeProjectDTO>();

        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResumeLanguageDTO>? Languages { get; set; } = new List<ResumeLanguageDTO>();
    }
}
