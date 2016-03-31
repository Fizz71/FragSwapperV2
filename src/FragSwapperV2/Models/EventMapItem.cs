using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models
{
    public class EventMapItem
    {
        public int EventID { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string EventDate { get; set; }
        public double? LocationLat { get; set; }
        public double? LocationLng { get; set; }

    }
}
