using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FragSwapperV2.Models.Db;

namespace FragSwapperV2.Models
{
    public class EventMapFilter
    {
        public EventStatus? StatusFrom { get; set; }
        public EventStatus? StatusTo { get; set; }
        public string EventName { get; set; }
        public int? EventYear { get; set; }
    }
}
