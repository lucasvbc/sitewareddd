using System;
using Ninject.Modules;
using DDD.Application.Interface;
using DDD.Application;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Services;
using DDD.Domain.Interfaces.Repositories;
using DDD.Data.Repositories;

namespace DDD.IoC
{
    public class DDDWebModules : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IProductAppService>().To<ProductAppService>();
            Bind<IOfferAppService>().To<OfferAppService>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IProductService>().To<ProductService>();
            Bind<IOfferService>().To<OfferService>();

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOfferRepository>().To<OfferRepository>();
        }
    }
}
