using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Repositories
{
    public interface IResumeInfoRepository<TModel>
    {
        IEnumerable<TModel> ListByResumeId(long resumeId);
        TModel? GetById(long courseId);
        TModel Add(TModel course);
        TModel Update(TModel course);
        void Delete(long courseId);
    }
}
