using Boozewasher.Application.Features.Brands.Commands.Create;
using Boozewasher.Application.Features.Brands.Queries.GetAllCached;
using Boozewasher.Application.Features.Brands.Queries.GetById;
using Boozewasher.Domain.Entities.Catalog;
using AutoMapper;

namespace Boozewasher.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}