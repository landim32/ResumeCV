using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ResumeCV.Infra.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.UnitOfWork
{
    public class TransactionDisposable : ITransaction
    {
        private readonly ILogger<IUnitOfWork> _log;
        private readonly IDbContextTransaction _transaction;

        public TransactionDisposable(ILogger<IUnitOfWork> log, IDbContextTransaction transaction)
        {
            _log = log;
            _transaction = transaction;
        }

        public void Commit()
        {
            //_log.Log("Finalizando bloco de transação.", Levels.Trace);
            _transaction.Commit();
        }

        public void Dispose()
        {
            //_log.Log("Liberando transação da memória.", Levels.Trace);
            _transaction.Dispose();
        }

        public void Rollback()
        {
            //_log.Log("Rollback do bloco de transação.", Levels.Trace);
            _transaction.Rollback();

        }
    }
}
