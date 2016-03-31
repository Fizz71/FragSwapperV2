using System;
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models.Db
{
    /// <summary>
    /// This object is being maintained to hold all the old profiles so they
    /// can be imported once the user re-registers.
    /// </summary>
    public class v1Swapper
    {
        public int ID { get; set; }

        [Required]
        public int SwapperKey { get; set; }

        [Required, MaxLength(30)]
        public string SwapperName { get; set; }

        [Required, MaxLength(10)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LaseName { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public bool AllowEmail { get; set; }

        [Required]
        public bool EmailTrades { get; set; }

        [MaxLength(3000)]
        public string WishList { get; set; }

        public DateTime CratedOn { get; set; }

        public string SwapperHosts { get; set; }
        public string SwapperAdminHosts { get; set; }
        public string SwapperEvents { get; set; }
        public string SwapperAdminEvents { get; set; }
    }
}
