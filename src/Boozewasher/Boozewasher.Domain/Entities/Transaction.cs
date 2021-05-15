using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        public DateTime DateTime { get; set; }
        public string PlateNumber { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public decimal Cost { get; set; }
        public string ItemsList { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}
