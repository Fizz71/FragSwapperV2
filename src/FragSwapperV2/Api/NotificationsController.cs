using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FragSwapperV2.Api
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        public string Get()
        {
            return "Boom goes the dynamite Controller.";
        }
    }
}
