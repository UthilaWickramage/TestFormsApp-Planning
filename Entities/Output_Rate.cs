using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Output_Rate
    {
        public int Output_Rate_Id { get; set; }
        public double Rate { get; set; }

        public int ProductId    { get; set; }
        public virtual Product Product { get; set; }
    
        public int WorkstationId { get; set; }

        public virtual WorkStation WorkStation { get; set; }

        public int OperationTypeId { get; set; }

        public virtual Operation_Type OperationType { get; set; }
    
    }
}
