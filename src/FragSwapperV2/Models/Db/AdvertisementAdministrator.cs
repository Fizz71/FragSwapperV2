
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models
{
    public class AdvertisementAdministrator
    {
        public int ID { get; set; }
        public Advertisement Advertisement { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
