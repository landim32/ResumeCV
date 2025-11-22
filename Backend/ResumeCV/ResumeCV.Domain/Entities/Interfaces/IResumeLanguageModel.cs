using System;

namespace ResumeCV.Domain.Entities.Interfaces
{
    /// <summary>
    /// Contrato para a entidade ResumeLanguageModel contendo propriedades e operações de domínio.
    /// </summary>
    public interface IResumeLanguageModel
    {
        long LanguageId { get; }
        long ResumeId { get; }
        string Language { get; }
        int Level { get; }

        void UpdateLanguage(string language);
        void UpdateLevel(int level);
    }
}
