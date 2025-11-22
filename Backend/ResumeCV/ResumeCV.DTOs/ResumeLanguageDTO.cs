using Newtonsoft.Json;
using System;

namespace ResumeCV.DTOs
{
    public class ResumeLanguageDTO
    {
        [JsonProperty("languageId")]
        public long LanguageId { get; set; }
        /*
        [JsonProperty("resumeId")]
        public long ResumeId { get; set; }
        */
        [JsonProperty("language")]
        public string Language { get; set; } = string.Empty;

        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
