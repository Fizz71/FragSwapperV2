using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models
{

    public class UserLocation
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int RegionID { get; set; }
        public int StateID { get; set; }
    }
}
