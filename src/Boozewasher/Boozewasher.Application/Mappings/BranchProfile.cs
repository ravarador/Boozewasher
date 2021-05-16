using AutoMapper;
using Boozewasher.Application.Features.Branches.Commands.Create;
using Boozewasher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Application.Mappings
{
    internal class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<CreateBranchCommand, Branch>().ReverseMap();
            //CreateMap<GetBranchByIdResponse, Branch>().ReverseMap();
            //CreateMap<GetAllBranchsCachedResponse, Branch>().ReverseMap();
        }
    }
}
