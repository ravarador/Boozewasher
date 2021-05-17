using AutoMapper;
using Boozewasher.Application.Features.Branches.Commands.Create;
using Boozewasher.Application.Features.Branches.Queries.GetAllCached;
using Boozewasher.Application.Features.Branches.Queries.GetById;
using Boozewasher.Domain.Entities;

namespace Boozewasher.Application.Mappings
{
    internal class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<CreateBranchCommand, Branch>().ReverseMap();
            CreateMap<GetBranchByIdResponse, Branch>().ReverseMap();
            CreateMap<GetAllBranchesCachedResponse, Branch>().ReverseMap();
        }
    }
}
