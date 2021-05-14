using Boozewasher.Application.Features.Products.Commands.Create;
using Boozewasher.Application.Features.Products.Queries.GetAllCached;
using Boozewasher.Application.Features.Products.Queries.GetAllPaged;
using Boozewasher.Application.Features.Products.Queries.GetById;
using Boozewasher.Domain.Entities.Catalog;
using AutoMapper;

namespace Boozewasher.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}