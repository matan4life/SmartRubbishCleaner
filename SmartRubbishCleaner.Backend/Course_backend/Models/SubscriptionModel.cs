﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Models
{
    public class SubscriptionModel
    {
        public int SubscriptionId { get; set; }
        public string IdentificationName { get; set; }
        public double Price { get; set; }
    }
}
