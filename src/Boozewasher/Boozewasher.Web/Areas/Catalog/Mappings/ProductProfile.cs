using Boozewasher.Application.Features.Products.Commands.Create;
using Boozewasher.Application.Features.Products.Commands.Update;
using Boozewasher.Application.Features.Products.Queries.GetAllCached;
using Boozewasher.Application.Features.Products.Queries.GetById;
using Boozewasher.Web.Areas.Catalog.Models;
using AutoMapper;

namespace Boozewasher.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}