using System;
using System.Collections.Generic;

namespace DDD.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> GetList();
        TEntity GetById(int id);
        void Dispose();
    }
}
