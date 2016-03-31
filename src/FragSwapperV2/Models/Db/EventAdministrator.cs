
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models.Db
{
    public class EventAdministrator
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
