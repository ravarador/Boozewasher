﻿using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Birthdate { get; set; }
        public string TIN { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}
