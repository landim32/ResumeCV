using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Repositories
{
    public interface IResumeJobRepository<TModel>
    {
        IEnumerable<TModel> ListByResume(long resumeId);
        TModel? GetById(long jobId);
        TModel Add(TModel job);
        TModel Update(TModel job);
        void Delete(long jobId);
    }
}
