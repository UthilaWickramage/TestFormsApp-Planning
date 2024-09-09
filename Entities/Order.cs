using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderTitle { get; set; }
        public string OrderDescription { get; set; }

        public string CustomerName { get; set; }

        public OrderStatus Status { get; set; }
        public double Qty { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
