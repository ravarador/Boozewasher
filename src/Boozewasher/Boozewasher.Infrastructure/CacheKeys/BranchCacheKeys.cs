using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Infrastructure.CacheKeys
{
    public static class BranchCacheKeys
    {
        public static string ListKey => "BranchList";

        public static string SelectListKey => "BranchSelectList";

        public static string GetKey(int branchId) => $"Branch-{branchId}";

        public static string GetDetailsKey(int branchId) => $"BranchDetails-{branchId}";
    }
}
