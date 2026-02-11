using ResumeCV.Domain.Entities.Interfaces;
using System;

namespace ResumeCV.Domain.Entities
{
    public class ResumeLanguageModel : IResumeLanguageModel
    {
        public long LanguageId { get; private set; }
        public long ResumeId { get; private set; }
        public string Language { get; private set; } = null!;
        public int Level { get; private set; }

        // Construtor de criação com validações de domínio
        public ResumeLanguageModel(long languageId, long resumeId, string language, int level)
        {
            //if (languageId <= 0) throw new ArgumentException("LanguageId deve ser maior que zero.", nameof(languageId));
            //if (resumeId <= 0) throw new ArgumentException("ResumeId deve ser maior que zero.", nameof(resumeId));
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentException("Language é obrigatório.", nameof(language));
            if (language.Length > 200) throw new ArgumentException("Language excede o tamanho máximo (200).", nameof(language));
            if (level < 0 || level > 5) throw new ArgumentException("Level deve estar entre 0 e 5.", nameof(level));

            LanguageId = languageId;
            ResumeId = resumeId;
            Language = language.Trim();
            Level = level;
        }

        // Operações de domínio
        public void UpdateLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentException("Language é obrigatório.", nameof(language));
            if (language.Length > 200) throw new ArgumentException("Language excede o tamanho máximo (200).", nameof(language));
            Language = language.Trim();
        }

        public void UpdateLevel(int level)
        {
            if (level < 0 || level > 5) throw new ArgumentException("Level deve estar entre 0 e 5.", nameof(level));
            Level = level;
        }
    }
}
