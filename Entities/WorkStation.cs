﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkStation
    {
        [Key]
        public int WorkStationId { get; set; }

        public string WorkStationName { get; set; }


        public virtual List<ScheduleDetails> ScheduleDetails { get; set; }

        //public virtual List<Holiday> Holidays { get; set; }

        public virtual List<CustomDay> CustomDays { get; set; }
                public virtual List<Output_Rate> OutputRates { get; set; }

    }
}
