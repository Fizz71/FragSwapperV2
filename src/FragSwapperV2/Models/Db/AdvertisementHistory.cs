using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FragSwapperV2.Models
{
    public class AdvertisementHistory
    {
        public int ID { get; set; }

        [Required]
        public int AdvertisementID { get; set; }

        [ForeignKey("AdvertisementID")]
        public Advertisement Advertisement { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Shown { get; set; }

        [Required]
        public int Clicked { get; set; }
    }
}
