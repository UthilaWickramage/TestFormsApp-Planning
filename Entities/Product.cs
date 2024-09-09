﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public double CapacityInHour {  get; set; }

        public List<Order> Orders { get; set; }

    }
}
