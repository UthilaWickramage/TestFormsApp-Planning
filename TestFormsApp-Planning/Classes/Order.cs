using Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Title { get; set; }
public string Description { get; set; }

    public string Customer {  get; set; }

        public double Qty { get; set; }

        public string ProductName { get; set; }

        public Product Product { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
