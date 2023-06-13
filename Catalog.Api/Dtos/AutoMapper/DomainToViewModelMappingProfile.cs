using AutoMapper;
using Catalog.Api.Dtos.ViewModels;
using Catalog.Api.Entities;

namespace Catalog.Api.Dtos.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, InsertProductViewModel>();
        }
    }
}
