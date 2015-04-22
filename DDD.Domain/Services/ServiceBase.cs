using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetList()
        {
            return _repository.GetList();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
