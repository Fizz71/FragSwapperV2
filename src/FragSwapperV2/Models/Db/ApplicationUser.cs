﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FragSwapperV2.Models.Db
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int oldSwapperKey { get; set; }
        public bool settingEnableDefaultRedirect { get; set; }
    }
}
