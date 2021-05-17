using AspNetCoreHero.Results;
using AutoMapper;
using Boozewasher.Application.Interfaces.CacheRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boozewasher.Application.Features.Branches.Queries.GetAllCached
{
    public class GetAllBranchesCachedQuery : IRequest<Result<List<GetAllBranchesCachedResponse>>>
    {
        public GetAllBranchesCachedQuery()
        {
        }
    }

    public class GetAllBranchesCachedQueryHandler : IRequestHandler<GetAllBranchesCachedQuery, Result<List<GetAllBranchesCachedResponse>>>
    {
        private readonly IBranchCacheRepository _productCache;
        private readonly IMapper _mapper;

        public GetAllBranchesCachedQueryHandler(IBranchCacheRepository productCache, IMapper mapper)
        {
            _productCache = productCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllBranchesCachedResponse>>> Handle(GetAllBranchesCachedQuery request, CancellationToken cancellationToken)
        {
            var branchList = await _productCache.GetCachedListAsync();
            var mappedBranches = _mapper.Map<List<GetAllBranchesCachedResponse>>(branchList);
            var test = Result<List<GetAllBranchesCachedResponse>>.Success(mappedBranches);
            return test;
        }
    }
}
