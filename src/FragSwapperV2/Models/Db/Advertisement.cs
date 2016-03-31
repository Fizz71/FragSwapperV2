using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FragSwapperV2.Models.Db
{
    public class Advertisement
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        public string Notes { get; set; }

        public Event Event { get; set; }

        [Required]
        public DateTime StartSDateTime { get; set; }

        [Required]
        public DateTime EndSDateTime { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string DestinationURL { get; set; }


    }
}
