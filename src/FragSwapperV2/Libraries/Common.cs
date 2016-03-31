using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FragSwapperV2.Libraries
{
    public class Common
    {
        // These are global variables used by _Layout
        public static string GoogleBrowserAPIKey { get; set; }
        public static string GoogleMapApiUrl { get; set; }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }

}
