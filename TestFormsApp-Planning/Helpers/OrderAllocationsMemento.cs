using Entities;
using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning.Helpers
{
    public class OrderAllocationsMemento
    {

        private List<OrderAllocation> OrderAllocations;

        public OrderAllocationsMemento(List<OrderAllocation> orderAllocations)
        {
            OrderAllocations = new List<OrderAllocation>();
            foreach (var order in orderAllocations)
            {
                OrderAllocations.Add(new OrderAllocation
                {
                    OrderTitle = order.OrderTitle,
                    HeaderText = order.OrderTitle,
                    StartTime = order.StartTime,

                    Id = order.OrderTitle.ToString(),
                    OrderAllocationId = order.OrderAllocationId,
                    EndTime = order.EndTime,
                    VisibleStartTime = order.VisibleStartTime,
                    VisibleEndTime = order.VisibleEndTime,
                    Qty = order.Qty.ToString(),
                    DurationInHours = double.Parse(order.DurationInHours.ToString()),
                    Customer = order.Customer,
                    deliveryDate = order.deliveryDate,
                    Contact = order.Contact
                });
            }
        }
    }
}
