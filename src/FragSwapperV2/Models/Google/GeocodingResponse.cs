using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models.Google
{
    /*
        This class is build to match the expected JSON results from the Google Maps Geocoding API as 
        returned from the Google Maps API using the "geocode/json".

        https://developers.google.com/maps/documentation/geocoding/intro#geocoding

        Sample JSON:
        {
           "results" : [
              {
                 "address_components" : [
                    {
                       "long_name" : "1600",
                       "short_name" : "1600",
                       "types" : [ "street_number" ]
                    },
                    {
                       "long_name" : "Amphitheatre Pkwy",
                       "short_name" : "Amphitheatre Pkwy",
                       "types" : [ "route" ]
                    },
                    {
                       "long_name" : "Mountain View",
                       "short_name" : "Mountain View",
                       "types" : [ "locality", "political" ]
                    },
                    {
                       "long_name" : "Santa Clara County",
                       "short_name" : "Santa Clara County",
                       "types" : [ "administrative_area_level_2", "political" ]
                    },
                    {
                       "long_name" : "California",
                       "short_name" : "CA",
                       "types" : [ "administrative_area_level_1", "political" ]
                    },
                    {
                       "long_name" : "United States",
                       "short_name" : "US",
                       "types" : [ "country", "political" ]
                    },
                    {
                       "long_name" : "94043",
                       "short_name" : "94043",
                       "types" : [ "postal_code" ]
                    }
                 ],
                 "formatted_address" : "1600 Amphitheatre Parkway, Mountain View, CA 94043, USA",
                 "geometry" : {
                    "location" : {
                       "lat" : 37.4224764,
                       "lng" : -122.0842499
                    },
                    "location_type" : "ROOFTOP",
                    "viewport" : {
                       "northeast" : {
                          "lat" : 37.4238253802915,
                          "lng" : -122.0829009197085
                       },
                       "southwest" : {
                          "lat" : 37.4211274197085,
                          "lng" : -122.0855988802915
                       }
                    }
                 },
                 "place_id" : "ChIJ2eUgeAK6j4ARbn5u_wAGqWA",
                 "types" : [ "street_address" ]
              }
           ],
           "status" : "OK"
        }
*/
    public class GeocodingResponse
    {
        public results[] results { get; set; }
        public string status { get; set; }

    }

    public class results
    {
        public address_component[] address_components { get; set; }
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
    }

    public class address_component
    {
        String long_name { get; set; }
        String short_name { get; set; }
        String types { get; set; }

    }

    public class geometry
    {
        public bounds bounds { get; set; }
        public location location { get; set; }
        public string location_type { get; set; }
        public viewport viewport { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class viewport
    {
        public northeast northeast { get; set; }
        public southwest southwest { get; set; }
    }

    public class bounds
    {
        public northeast northeast { get; set; }
    }

    public class northeast
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class southwest
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
