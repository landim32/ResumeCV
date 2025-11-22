using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Repositories
{
    public interface IResumeLanguageRepository<TModel>
    {
        IEnumerable<TModel> ListByResume(long resumeId);
        TModel? GetById(long languageId);
        TModel Add(TModel language);
        TModel Update(TModel language);
        void Delete(long languageId);
    }
}
