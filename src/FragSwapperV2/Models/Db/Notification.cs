using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models.Db
{
    public class Notification
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
    }
}
