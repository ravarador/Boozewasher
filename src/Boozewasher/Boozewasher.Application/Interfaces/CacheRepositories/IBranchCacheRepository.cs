using Boozewasher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Application.Interfaces.CacheRepositories
{
    public interface IBranchCacheRepository
    {
        Task<List<Branch>> GetCachedListAsync();

        Task<Branch> GetByIdAsync(int branchId);
    }
}
