using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.OptionsModel;
using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;
using FragSwapperV2.Libraries;
using System.Linq;
using System.Collections.Generic;

namespace FragSwapperV2.Api
{
    public class CommonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        public CommonController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _appSettings = appSettings.Value;
        }

        // This API expects to get a location containing a Lat and Lng and it will
        // return information from the Google API about that location.
        [HttpGet]
        [Route("api/Common/GetUserLocationInfo")]
        public string GetUserLocationInfo(string location)
        {
            var userLocation = new UserLocation();

            if (location != null)
            {
                userLocation = JsonConvert.DeserializeObject<UserLocation>(location);

                try
                {
                    var google = new GoogleGeocoding(_appSettings.GoogleServerAPIKey, _appSettings.GoogleMapApiUrl);
                    var gc = google.GetGeocoding(userLocation.Lat, userLocation.Lng);

                    if (gc.status == "OK")
                    {
                        try // to get a RegionID
                        {
                            userLocation.RegionID =
                                _context
                                    .Regions
                                    .Where(x => x.Name ==
                                        gc.results.Where(y => y.types.Contains("country")).FirstOrDefault().formatted_address)
                                    .FirstOrDefault().ID;
                        }
                        catch (System.Exception)
                        {
                            // todo: Don't really care, but we should probably save the lat and lng they tried.
                        }

                        try // to get a StateID
                        {
                            string aal1 = gc.results.Where(y => y.types.Contains("administrative_area_level_1")).FirstOrDefault().formatted_address;

                            // administrative_area_level_1 includes "state,country abbr" so we'll split it in the actually pull:
                            userLocation.StateID = _context.States.Where(x => x.Name == aal1.Split(',')[0]).FirstOrDefault().ID;
                        }
                        catch (System.Exception)
                        {
                            // todo: Don't really care, but we should probably save the lat and lng they tried.
                        }
                    }
                }
                catch (System.Exception)
                {
                    // todo: Do something with the error, then move on.
                }
            }

            return JsonConvert.SerializeObject(userLocation);
        }




        [HttpGet]
        [Route("api/Common/GetRegions")]
        public string GetRegions()
        {
            return JsonConvert.SerializeObject(_context.Regions.OrderBy(x => x.Name).ToList());
        }

        [HttpGet]
        [Route("api/Common/GetStates")]
        public string GetStates(int regionID)
        {
            return JsonConvert.SerializeObject(_context.States.Where(x => x.Region.ID == regionID).OrderBy(x => x.Name).ToList());
        }

    }
}
