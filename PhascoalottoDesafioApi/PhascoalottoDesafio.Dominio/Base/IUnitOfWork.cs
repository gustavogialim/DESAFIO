using System;

namespace PhascoalottoDesafio.Dominio.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void CommitAndRefreshChanges();

        void RollbackChanges();

        void ChangeDatabase(string database);

        string GetDatabase();

        string GetConnectionString();
    }
}
