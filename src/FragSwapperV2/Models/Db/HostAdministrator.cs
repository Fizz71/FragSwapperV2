
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models.Db
{
    public class HostAdministrator
    {
        public int ID { get; set; }
        public Host Host { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
