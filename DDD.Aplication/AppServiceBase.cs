using DDD.Application.Interface;
using DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _IServiceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _IServiceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _IServiceBase.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _IServiceBase.Delete(obj);
        }

        public void Dispose()
        {
            _IServiceBase.Dispose();
        }

        public TEntity GetById(int id)
        {
            return _IServiceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetList()
        {
            return _IServiceBase.GetList();
        }

        public void Update(TEntity obj)
        {
            _IServiceBase.Update(obj);
        }
    }
}
