using System.Collections.Generic;

namespace ResumeCV.Domain.Entities.Interfaces
{
    public interface IResumeSkillModel
    {
        long SkillId { get; }
        //long UserId { get; }
        string Slug { get; }
        string Name { get; }

        void UpdateName(string name);
        void SetCustomSlug(string slug);
    }
}
