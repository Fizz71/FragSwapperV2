using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FragSwapperV2.Models.Db
{
    public enum HostAccountType
    {
        Deleted = -2,
        New = -1,
        Inactive = 0,
        Standard = 1,
        Premium = 2
    }

    public enum HostLogoImageType
    {
        Square = 0,
        Rectangle = 1,
        Banner = 2
    }

    public class Host
    {
        public int ID { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(20), MinLength(2)]
        public string Abbreviation { get; set; }

        [Required, MaxLength(20), MinLength(2)]
        public string ShortName { get; set; }

        [MaxLength(200)]
        public string URL { get; set; }

        [Required, DefaultValue(HostLogoImageType.Rectangle)]
        public HostLogoImageType LogoImageType { get; set; }

        public string Message { get; set; }

        [Required]
        [DefaultValue(HostAccountType.New)]
        public HostAccountType AccountType { get; set; }

        // If this isn't a premium account, they can buy premium event tickets.
        // As the tickets are bought we add to this amount.
        [Required]
        public int PremiumEvents { get; set; }

        public DateTime? PremiumAccountExpiration { get; set; }

        [Required, DefaultValue(false)]
        public bool AutoApproveStandardEvent { get; set; }
    }
}
