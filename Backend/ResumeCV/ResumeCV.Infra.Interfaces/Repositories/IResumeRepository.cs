using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Repositories
{
    public interface IResumeRepository<TModel>
    {
        IEnumerable<TModel> ListByUserId(long userId);
        TModel? GetById(long resumeId);
        long Add(TModel resume);
        void Update(TModel resume);
        void Delete(long resumeId);
    }
}
