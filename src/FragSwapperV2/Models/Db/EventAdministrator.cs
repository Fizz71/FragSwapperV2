
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models
{
    public class EventAdministrator
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
