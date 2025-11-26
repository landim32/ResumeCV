using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Domain.Services.Interfaces
{
    public interface IResumeService
    {
        IList<ResumeDTO> ListByUser(long userId);
        ResumeDTO? GetById(long resumeId);
        long Add(ResumeDTO resume);
        void Update(ResumeDTO resume);
        void Delete(long resumeId);
        Stream GeneratePdf(long resumeId);
    }
}
