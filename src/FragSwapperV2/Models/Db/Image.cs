using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models.Db
{
    public class Image
    {
        public enum ImageSource
        {
            Sponsor = 1,
            EventAd = 2,
            Event = 3,
            Host = 4,
            HostSponsors = 5
        }

        public int ID { get; set; }
        public ImageSource Source { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Event Event { get; set; }
        public Host Host { get; set; }
        public Advertisement Advertisement { get; set; }
        public string FileName { get; set; }
    }
}
