using AutoMapper;
using Boozewasher.Application.Features.Branches.Commands.Create;
using Boozewasher.Application.Features.Branches.Queries;
using Boozewasher.Application.Features.Branches.Queries.GetAllCached;
using Boozewasher.Application.Features.Branches.Queries.GetById;
using Boozewasher.Web.Areas.Branch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boozewasher.Web.Areas.Branch.Mappings
{
    internal class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<GetAllBranchesCachedResponse, BranchViewModel>().ReverseMap();
            CreateMap<GetBranchByIdResponse, BranchViewModel>().ReverseMap();
            CreateMap<CreateBranchCommand, BranchViewModel>().ReverseMap();
            //CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}
