using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace ResumeCV.Domain.Entities.Interfaces
{
    /// <summary>
    /// Contrato para a entidade `ResumeModel` contendo propriedades e operações de domínio.
    /// </summary>
    public interface IResumeModel
    {
        long ResumeId { get; }
        long UserId { get; }
        string Name { get; }
        string Phone { get; }
        string Email { get; }
        int Status { get; }
        string? Address { get; }
        string? Resume { get; }
        string Title { get; }

        IList<IResumeCourseModel> Courses { get; }
        IList<IResumeInfoModel> Infos { get; }
        IList<IResumeJobModel> Jobs { get; }
        IList<IResumeLanguageModel> Languages { get; }

        void UpdateName(string name);
        void UpdatePhone(string phone);
        void UpdateEmail(string email);
        void UpdateStatus(int status);
        void UpdateTitle(string title);
        void UpdateAddress(string? address);
        void UpdateResume(string? resume);

        void ClearCourses();
        void AddCourse(IResumeCourseModel course);
        void ClearInfos();
        void AddInfo(IResumeInfoModel info);
        void ClearJobs();
        void AddJob(IResumeJobModel job);
        void ClearLanguages();
        void AddLanguage(IResumeLanguageModel language);
    }
}
