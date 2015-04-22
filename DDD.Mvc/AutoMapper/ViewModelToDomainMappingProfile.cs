using AutoMapper;
using DDD.Domain.Entities;
using DDD.Mvc.ViewModels;

namespace DDD.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Offer, OfferViewModel>();
        }
    }
}