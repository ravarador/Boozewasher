using Boozewasher.Application.Features.Brands.Commands.Create;
using Boozewasher.Application.Features.Brands.Commands.Update;
using Boozewasher.Application.Features.Brands.Queries.GetAllCached;
using Boozewasher.Application.Features.Brands.Queries.GetById;
using Boozewasher.Web.Areas.Catalog.Models;
using AutoMapper;

namespace Boozewasher.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}