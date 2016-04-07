using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;

namespace FragSwapperV2.Libraries
{
    public static class Common
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

        public static string HostImageLogo(int hostID, ApplicationDbContext _context)
        {

            try
            {
                return "~/images/dbHost/" + _context.Images.FirstOrDefault(x => x.Source == Image.ImageSource.Host && x.Host.ID == hostID).FileName;
            }
            catch (Exception)
            {
                // todo: Report need a host logo image
                return "";
            }

        }

        public static List<HostEventImages> RandomHostImages(int hostID, int maxImages, ApplicationDbContext _context)
        {
            // Get all images for events for this host.  We'll order by the event date so they
            // are presented in the order from oldest to newest.
            var allImages = _context.Images
                .Where(x => x.Source == Image.ImageSource.Event && x.Host.ID == hostID)
                .OrderBy(x => x.Event.EventDate)
                .Select(x => new HostEventImages
                {
                    Caption = x.Event.Name + " - " + x.Event.EventDate.ToString("MMMM, yyyy"),
                    FileName = "~/images/dbEvent/" + x.Event.ID.ToString() + "/" + x.FileName
                }).ToList();

            // We will now randomly remove items until we get to the maxImages.
            Random rand = new Random();
            while (allImages.Count > maxImages) allImages.RemoveAt(rand.Next(0, allImages.Count - 1));

            return allImages;
        }
        //_context.Advertisements.Where(x => x.ActiveSiteAd).ToList();
    }

}
