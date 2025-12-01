using ResumeCV.DTOs.Enums;
using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    public interface IResumeSkillModel
    {
        long SkillId { get; }
        string Slug { get; }
        string Name { get; }
        SkillTypeEnum SkillType { get; }

        void UpdateName(string name);
        void UpdateSkillType(SkillTypeEnum skillType);
        void SetCustomSlug(string slug);
    }
}
