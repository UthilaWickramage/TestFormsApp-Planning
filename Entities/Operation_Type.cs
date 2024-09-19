using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Operation_Type
    {
        [Key]
        public int Operation_Type_Id { get; set; }

        public string Operation_Type_Name { get; set; }

        public virtual List<Output_Rate> OutputRates { get; set; }
    }
}
