using Boozewasher.Application.Interfaces.CacheRepositories;
using Boozewasher.Application.Interfaces.Repositories;
using Boozewasher.Domain.Entities.Catalog;
using Boozewasher.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boozewasher.Domain.Entities;

namespace Boozewasher.Infrastructure.CacheRepositories
{
    public class BranchCacheRepository : IBranchCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IBranchRepository _branchRepository;

        public BranchCacheRepository(IDistributedCache distributedCache, IBranchRepository branchRepository)
        {
            _distributedCache = distributedCache;
            _branchRepository = branchRepository;
        }

        public async Task<Branch> GetByIdAsync(int branchId)
        {
            string cacheKey = BranchCacheKeys.GetKey(branchId);
            var branch = await _distributedCache.GetAsync<Branch>(cacheKey);
            if (branch == null)
            {
                branch = await _branchRepository.GetByIdAsync(branchId);
                Throw.Exception.IfNull(branch, "Branch", "No Branch Found");
                await _distributedCache.SetAsync(cacheKey, branch);
            }
            return branch;
        }

        public async Task<List<Branch>> GetCachedListAsync()
        {
            string cacheKey = BranchCacheKeys.ListKey;
            var branchList = await _distributedCache.GetAsync<List<Branch>>(cacheKey);
            if (branchList == null)
            {
                branchList = await _branchRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, branchList);
            }
            return branchList;
        }
    }
}
