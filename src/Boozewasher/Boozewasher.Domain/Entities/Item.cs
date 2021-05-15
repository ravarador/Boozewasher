using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Domain.Entities
{
    public class Item : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public bool IsEmpty { get; set; }
        public int UsageCount { get; set; }
        public decimal Expense { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}
