using Boozewasher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Application.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        IQueryable<Branch> Branches { get; }

        Task<List<Branch>> GetListAsync();

        Task<Branch> GetByIdAsync(int branchId);

        Task<int> InsertAsync(Branch branch);

        Task UpdateAsync(Branch branch);

        Task DeleteAsync(Branch branch);
    }
}
