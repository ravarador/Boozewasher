﻿using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boozewasher.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
