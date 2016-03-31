using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.ViewModels.Hosts
{
    public class CreateHostViewModel
    {
        [Required, Display(Name = "Host Account Type")]
        public bool RequestPremium { get; set; }

        [MaxLength(200), Required, Display(Name = "Host Name")]
        [Remote("CreateValidation", "Hosts", ErrorMessage = "That Host Name is already in use.")]
        public string Name { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must confirm that you are authorized to create this Host Account.")]
        public bool HostPermission { get; set; }

        [MaxLength(20), MinLength(2), Required, Display(Name = "Abbreviation")]
        public string Abbreviation { get; set; }

        [MaxLength(20), MinLength(2), Required, Display(Name = "Short Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Short Name can only be letters and numbers.")]
        [Remote("CreateValidation", "Hosts",ErrorMessage ="That Short Name is already in use.")]
        public string ShortName { get; set; }
    }
}
