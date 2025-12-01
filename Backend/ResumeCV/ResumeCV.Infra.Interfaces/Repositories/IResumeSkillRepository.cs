using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Repositories
{
    public interface IResumeSkillRepository<TModel>
    {
        IEnumerable<TModel> List();
        TModel? GetById(long resumeId);
        TModel Add(TModel resume);
        TModel Update(TModel resume);
        void Delete(long resumeId);
    }
}
