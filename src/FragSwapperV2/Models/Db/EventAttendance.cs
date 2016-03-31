using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models.Db
{
    public class EventAttendance
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool Attending { get; set; }
    }
}
