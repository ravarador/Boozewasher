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

namespace Boozewasher.Application.Features.Branches.Queries.GetById
{
    public class GetBranchByIdQuery : IRequest<Result<GetBranchByIdResponse>>
    {
        public int Id { get; set; }

        public class GetBranchByIdQueryQueryHandler : IRequestHandler<GetBranchByIdQuery, Result<GetBranchByIdResponse>>
        {
            private readonly IBranchCacheRepository _branchCache;
            private readonly IMapper _mapper;

            public GetBranchByIdQueryQueryHandler(IBranchCacheRepository productCache, IMapper mapper)
            {
                _branchCache = productCache;
                _mapper = mapper;
            }

            public async Task<Result<GetBranchByIdResponse>> Handle(GetBranchByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _branchCache.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetBranchByIdResponse>(product);
                return Result<GetBranchByIdResponse>.Success(mappedProduct);
            }
        }
    }
}
