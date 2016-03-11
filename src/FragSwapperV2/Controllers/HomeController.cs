using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using FragSwapperV2.Models;
using FragSwapperV2.Libraries;

namespace FragSwapperV2.Controllers
{
    public class HomeController : Controller
    {
        AppSettings appSettings;

        public HomeController(IOptions<AppSettings> o)
        {
            appSettings = o.Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var google = new GoogleGeocoding(appSettings.GoogleAPIKey, appSettings.GoogleMapApiUrl);
            var gc = google.GetGeocoding("615 Wellington Ave., 19609");
            ViewData["Message"] = gc.results[0].formatted_address;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
