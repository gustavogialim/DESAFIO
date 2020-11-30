using System;
using System.Collections.Generic;

namespace PhascoalottoDesafio.Dominio.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);

        void RemoveRange(IEnumerable<TEntity> items);

        void Modify(TEntity item);

        void TrackItem(TEntity item);

        void Merge(TEntity persisted, TEntity current);

        void Merge(object persisted, object current);

        void Commit();

        void Rollback();

        TEntity Get(Int32 id);

        IEnumerable<TEntity> GetAll();
    }
}
