using AutoMapper;
using DDD.Domain.Entities;
using DDD.Mvc.ViewModels;

namespace DDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<OfferViewModel, Offer>();
        }
    }
}