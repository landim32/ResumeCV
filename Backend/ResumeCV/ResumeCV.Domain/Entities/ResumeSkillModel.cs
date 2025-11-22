using ResumeCV.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ResumeCV.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio representando uma skill (habilidade).
    /// Implementada como Aggregate Root leve: mantém identidade, validações e operações de negócio.
    /// </summary>
    public class ResumeSkillModel: IResumeSkillModel
    {
        // Propriedades (seguindo os nomes do modelo de infraestrutura)
        public long SkillId { get; private set; }
        //public long UserId { get; private set; }
        public string Slug { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        //public ResumeSkillModel(long skillId, long userId, string name, string? slug = null)
        public ResumeSkillModel(long skillId, string name, string? slug = null)
        {
            //if (skillId <= 0) throw new ArgumentException("SkillId deve ser maior que zero.", nameof(skillId));
            //if (userId <= 0) throw new ArgumentException("UserId deve ser maior que zero.", nameof(userId));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name é obrigatório.", nameof(name));
            if (name.Length > 200) throw new ArgumentException("Name excede o tamanho máximo (200).", nameof(name));

            SkillId = skillId;
            //UserId = userId;
            Name = name.Trim();
            Slug = string.IsNullOrWhiteSpace(slug) ? GenerateSlug(Name) : GenerateSlug(slug);
        }

        // Operações de domínio
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name é obrigatório.", nameof(name));
            if (name.Length > 200) throw new ArgumentException("Name excede o tamanho máximo (200).", nameof(name));

            Name = name.Trim();
            // Quando o nome muda, atualizamos o slug por padrão para manter consistência
            Slug = GenerateSlug(Name);
        }

        public void SetCustomSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) throw new ArgumentException("Slug não pode ser vazio.", nameof(slug));
            Slug = GenerateSlug(slug);
        }

        // Utilitário para gerar slugs simples e previsíveis
        private static string GenerateSlug(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;

            // Normalizar acentos
            var normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            var withoutDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);

            // Converter para minúsculas, substituir não-alfa-numéricos por '-'
            var lower = withoutDiacritics.ToLowerInvariant();
            lower = Regex.Replace(lower, @"[^a-z0-9]+", "-");

            // Remover '-' duplicados e trim
            lower = Regex.Replace(lower, @"-+", "-").Trim('-');

            return lower;
        }
    }
}
