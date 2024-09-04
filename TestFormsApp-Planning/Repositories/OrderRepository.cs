using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Repositories
{
    public class OrderRepository:IOrderRepository
    {

        public async Task SaveOrder(Order order)
        {
            using (var context = new ScheduleDBContext())
            {
                context.Add(order);
                await context.SaveChangesAsync();
            }
        }

    }
}
