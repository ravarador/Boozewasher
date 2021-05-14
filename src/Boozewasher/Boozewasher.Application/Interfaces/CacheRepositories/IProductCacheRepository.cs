using Boozewasher.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boozewasher.Application.Interfaces.CacheRepositories
{
    public interface IBrandCacheRepository
    {
        Task<List<Brand>> GetCachedListAsync();

        Task<Brand> GetByIdAsync(int brandId);
    }
}