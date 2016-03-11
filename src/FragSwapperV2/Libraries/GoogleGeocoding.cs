using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using FragSwapperV2.Models.Google;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace FragSwapperV2.Libraries
{

    public class GoogleGeocoding
    {
        public string apiKey { get; set; }
        public string apiURL { get; set; }

        public GoogleGeocoding(string APIKey, string APIURL)
        {
            apiKey = APIKey;
            apiURL = APIURL;
        }

        /// <summary>
        /// Gets the Google Map API Geocoding Information for an Address.
        /// https://developers.google.com/maps/documentation/geocoding/intro#geocoding
        /// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain View, CA") into 
        /// geographic coordinates (like latitude 37.423021 and longitude -122.083739), which you can use to place markers 
        /// on a map, or position the map.
        /// </summary>
        /// <param name="Address">Any string of data Google can use to reslove a location or addresss.</param>
        /// <returns>Geocode information about the address or an empty object if address is bad, or API failed.</returns>
        public GeocodingResponse GetGeocoding(string Address)
        {
            if (Address.Trim().Length == 0) return new GeocodingResponse();
            try
            {
                var requestUri = apiURL + string.Format("geocode/json?address={0}&key={1}", Uri.EscapeDataString(Address), apiKey);
                var response = new System.Net.WebClient().DownloadString(requestUri);
                return JsonConvert.DeserializeObject<GeocodingResponse>(response);
            }
            catch (Exception)
            {
                // todo: Handle the exception.
                return new GeocodingResponse();
            }
        }
    }
}
