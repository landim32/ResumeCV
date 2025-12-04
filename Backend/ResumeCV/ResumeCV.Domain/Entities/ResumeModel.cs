using ResumeCV.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeCV.Domain.Entities
{

    public class ResumeModel : IResumeModel
    {
        private IList<IResumeCourseModel> _courses = new List<IResumeCourseModel>();
        private IList<IResumeInfoModel> _infos = new List<IResumeInfoModel>();
        private IList<IResumeJobModel> _jobs = new List<IResumeJobModel>();
        private IList<IResumeProjectModel> _projects = new List<IResumeProjectModel>();
        private IList<IResumeLanguageModel> _languages = new List<IResumeLanguageModel>();

        // Propriedades (espelhando Resume do contexto de infraestrutura)
        public long ResumeId { get; private set; }
        public long UserId { get; private set; }
        public string Title { get; private set; } = null!;
        public string JobDescription { get; set; }
        public string Name { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public int Status { get; private set; }
        public string? PhotoUrl { get; set; }
        public string? Address { get; private set; }
        public string? Resume { get; private set; }

        public IList<IResumeCourseModel> Courses
        {
            get
            {
                return _courses;
            }
        }

        public IList<IResumeInfoModel> Infos
        {
            get
            {
                return _infos;
            }
        }

        public IList<IResumeJobModel> Jobs
        {
            get
            {
                return _jobs;
            }
        }

        public IList<IResumeProjectModel> Projects
        {
            get
            {
                return _projects;
            }
        }

        public IList<IResumeLanguageModel> Languages
        {
            get
            {
                return _languages;
            }
        }

        // Construtor de criação com validações de domínio
        public ResumeModel(
            long resumeId,
            long userId,
            string name,
            string phone,
            string email,
            int status,
            string title,
            string jobDescription,
            string? photoUrl = null,
            string? address = null,
            string? resume = null)
        {
            //if (resumeId <= 0) throw new ArgumentException("ResumeId deve ser maior que zero.", nameof(resumeId));
            if (userId <= 0) throw new ArgumentException("UserId deve ser maior que zero.", nameof(userId));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name é obrigatório.", nameof(name));
            if (name.Length > 200) throw new ArgumentException("Name excede o tamanho máximo (200).", nameof(name));
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Phone é obrigatório.", nameof(phone));
            if (phone.Length > 50) throw new ArgumentException("Phone excede o tamanho máximo (50).", nameof(phone));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email é obrigatório.", nameof(email));
            if (email.Length > 320) throw new ArgumentException("Email excede o tamanho máximo (320).", nameof(email));
            if (!email.Contains("@")) throw new ArgumentException("Email inválido.", nameof(email));
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            if (string.IsNullOrWhiteSpace(jobDescription)) throw new ArgumentException("Job description is empty.", nameof(jobDescription));
            if (jobDescription.Length > 300) throw new ArgumentException("Job description max size is 300.", nameof(jobDescription));
            if (photoUrl?.Length > 520) throw new ArgumentException("Photo url max size is 520.", nameof(photoUrl));
            if (address is not null && address.Length > 1000) throw new ArgumentException("Address excede o tamanho máximo (1000).", nameof(address));
            if (resume is not null && resume.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(resume));

            ResumeId = resumeId;
            UserId = userId;
            Name = name.Trim();
            Phone = phone.Trim();
            Email = email.Trim();
            Status = status;
            Title = title.Trim();
            JobDescription = jobDescription.Trim();
            PhotoUrl = photoUrl?.Trim();
            Address = string.IsNullOrWhiteSpace(address) ? null : address.Trim();
            Resume = resume;
        }

        // Operações de domínio — updates com validações
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name é obrigatório.", nameof(name));
            if (name.Length > 200) throw new ArgumentException("Name excede o tamanho máximo (200).", nameof(name));
            Name = name.Trim();
        }

        public void UpdatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Phone é obrigatório.", nameof(phone));
            if (phone.Length > 50) throw new ArgumentException("Phone excede o tamanho máximo (50).", nameof(phone));
            Phone = phone.Trim();
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email é obrigatório.", nameof(email));
            if (email.Length > 320) throw new ArgumentException("Email excede o tamanho máximo (320).", nameof(email));
            if (!email.Contains("@")) throw new ArgumentException("Email inválido.", nameof(email));
            Email = email.Trim();
        }

        public void UpdateStatus(int status)
        {
            // Regra simples: status não negativo. Ajuste conforme enum ou regras de negócio.
            if (status < 0) throw new ArgumentException("Status inválido.", nameof(status));
            Status = status;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title é obrigatório.", nameof(title));
            if (title.Length > 500) throw new ArgumentException("Title excede o tamanho máximo (500).", nameof(title));
            Title = title.Trim();
        }

        public void UpdateJobDescription(string jobDescription)
        {
            if (string.IsNullOrWhiteSpace(jobDescription)) throw new ArgumentException("Job description is empty.", nameof(jobDescription));
            if (jobDescription.Length > 300) throw new ArgumentException("Job description max size is 300.", nameof(jobDescription));
            JobDescription = jobDescription.Trim();
        }

        public void UpdatePhotoUrl(string? photoUrl)
        {
            if (photoUrl?.Length > 520) throw new ArgumentException("Photo url max size is 520.", nameof(photoUrl));
            PhotoUrl = photoUrl?.Trim();
        }

        public void UpdateAddress(string? address)
        {
            if (address is not null && address.Length > 1000) throw new ArgumentException("Address excede o tamanho máximo (1000).", nameof(address));
            Address = string.IsNullOrWhiteSpace(address) ? null : address.Trim();
        }

        public void UpdateResume(string? resume)
        {
            if (resume is not null && resume.Length > 4000) throw new ArgumentException("Resume (descrição) excede o tamanho máximo (4000).", nameof(resume));
            Resume = resume;
        }

        public void ClearCourses()
        {
            _courses.Clear();
        }

        public void AddCourse(IResumeCourseModel course)
        {
            _courses.Add(course);
        }

        public void ClearInfos()
        {
            _infos.Clear();
        }

        public void AddInfo(IResumeInfoModel info)
        {
            _infos.Add(info);
        }

        public void ClearJobs()
        {
            _jobs.Clear();
        }

        public void AddJob(IResumeJobModel job)
        {
            _jobs.Add(job);
        }

        public void ClearProjects()
        {
            _projects.Clear();
        }

        public void AddProject(IResumeProjectModel project)
        {
            _projects.Add(project);
        }

        public void ClearLanguages()
        {
            _languages.Clear();
        }

        public void AddLanguage(IResumeLanguageModel language)
        {
            _languages.Add(language);
        }
    }
}
