using Microsoft.Extensions.Logging;
using ResumeCV.Infra.Context;
using ResumeCV.Infra.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ResumeCVContext _context;
        private readonly ILogger<IUnitOfWork> _log;

        public UnitOfWork(ILogger<IUnitOfWork> log, ResumeCVContext context)
        {
            this._context = context;
            _log = log;
        }

        public ITransaction BeginTransaction()
        {
            try
            {
                //_log.Log("Iniciando bloco de transação.", Levels.Trace);
                return new TransactionDisposable(_log, _context.Database.BeginTransaction());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
