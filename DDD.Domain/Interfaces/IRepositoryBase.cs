using System;
using System.Collections.Generic;

namespace DDD.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> GetList();
        TEntity GetById(Guid id);
        void Dispose();
    }
}
