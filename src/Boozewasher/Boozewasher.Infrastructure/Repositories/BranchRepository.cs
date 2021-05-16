using Boozewasher.Application.Interfaces.Repositories;
using Boozewasher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IRepositoryAsync<Branch> _repository;
        private readonly IDistributedCache _distributedCache;

        public BranchRepository(IDistributedCache distributedCache, IRepositoryAsync<Branch> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Branch> Branches => _repository.Entities;

        public async Task DeleteAsync(Branch branch)
        {
            await _repository.DeleteAsync(branch);
            await _distributedCache.RemoveAsync(CacheKeys.BranchCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.BranchCacheKeys.GetKey(branch.Id));
        }

        public async Task<Branch> GetByIdAsync(int branchId)
        {
            return await _repository.Entities.Where(p => p.Id == branchId).FirstOrDefaultAsync();
        }

        public async Task<List<Branch>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Branch branch)
        {
            await _repository.AddAsync(branch);
            await _distributedCache.RemoveAsync(CacheKeys.BranchCacheKeys.ListKey);
            return branch.Id;
        }

        public async Task UpdateAsync(Branch branch)
        {
            await _repository.UpdateAsync(branch);
            await _distributedCache.RemoveAsync(CacheKeys.BranchCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.BranchCacheKeys.GetKey(branch.Id));
        }
    }
}
