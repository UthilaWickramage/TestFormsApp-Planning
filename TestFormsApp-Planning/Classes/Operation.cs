using Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class Operation
    {
        public int OperationId { get; set; }
        public string OrderNo { get; set; }

    public string Customer {  get; set; }

        public double Qty { get; set; }

        public string ProductName { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string OperationType { get; set; }

        public double Capacity { get; set; }

        public Operation_Type Operation_Type { get; set; }

        public Product Product { get; set; }

        public WorkStation WorkStation { get; set; }

        public Order Order { get; set; }
    }
}
