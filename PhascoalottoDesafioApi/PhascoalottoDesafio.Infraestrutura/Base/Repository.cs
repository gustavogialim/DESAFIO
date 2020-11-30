using PhascoalottoDesafio.Dominio.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhascoalottoDesafio.Infraestrutura.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        IQueryableUnitOfWork _UnitOfWork;

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            if (item != null)
            {
                GetSet().Add(item);
            }
        }

        public virtual void AddRange(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                var newSet = _UnitOfWork.CreateSet<TEntity>();
                newSet.AddRange(items);
            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.Attach(item);
                GetSet().Remove(item);
            }
        }

        public virtual void RemoveRange(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                GetSet().RemoveRange(items);
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.Attach<TEntity>(item);
            }
        }

        public virtual void Modify(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.SetModified(item);
            }
        }

        public virtual TEntity Get(int id)
        {
            return GetSet().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsEnumerable();
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual void Merge(object persisted, object current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual void Commit()
        {
            _UnitOfWork.Commit();
        }

        public virtual void Rollback()
        {
            _UnitOfWork.RollbackChanges();
        }

        public void Dispose()
        {
            if (_UnitOfWork != null)
            {
                _UnitOfWork.Dispose();
            }
        }

        private DbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
    }
}
