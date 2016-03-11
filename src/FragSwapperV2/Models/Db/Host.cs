using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models
{
    public enum HostAccountType
    {
        New = -1,
        Inactive = 0,
        Standard = 1,
        Premium = 2
    }

    public class Host
    {
        public int ID { get; set; }

        [MaxLength(200), MinLength(1), Required]
        public string Name { get; set; }

        [MaxLength(20), MinLength(1), Required]
        public string Abreviation { get; set; }

        [MaxLength(20), MinLength(1), Required]
        public string ShortName { get; set; }

        [Required]
        public HostAccountType AccountType { get; set; }

        public DateTime? AccountExpiration { get; set; }
       
    }
}
