using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PendingOrder
    {
        public int PendingOrderId { get; set; }
        public string PendingOrderTitle { get; set; }

        public string PendingOrderDescription { get; set; }

        public int PendingOrderQty { get; set; }
        public string Client {  get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }


    }
}
