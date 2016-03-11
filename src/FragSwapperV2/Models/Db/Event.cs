using System;
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models
{
    public enum EventAccountType
    {
        Standard = 1,
        Premium = 2
    }

    public enum EventStatus
    {
        Deleted = -1,
        Requested = 0,
        Preview = 1,
        Open = 2,
        EventDay = 3,
        PostEvent = 4,
        Archived = 5
    }

    public class Event
    {
        public int ID { get; set; }

        [Required]
        public Host Host { get; set; }

        [Required]
        public EventAccountType AccountType { get; set; }

        [Required]
        public EventStatus Status { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime EventDate { get; set; }


        /// <summary>
        /// Used to track when a event is to change event status.
        /// The datetime is stored in the server's local time as inticated by the "S" 
        /// prefix of the field name.  This is done so that the date compare can be done 
        /// on the server with no regard to the event's actual location.
        /// </summary>
        public DateTime OpenSDateTime { get; set; }

        public DateTime EventDaySDateTime { get; set; }

        public DateTime PostEventSDateTime { get; set; }

        public DateTime ArchiveSDateTime { get; set; }


        public string LocationFormattedAddress { get; set; }

        public string LocationLat { get; set; }

        public string LocationLng { get; set; }

        public string LocationType { get; set; }


        /// <summary>
        /// The Modules fields track the if optional module is enabled for an event.  Some module are
        /// only available to Premium events.  There are other modules, but these are the modules that
        /// can be specifically turned on and off by the admin.
        /// </summary>
        [Required]
        public bool ModuleChatRoom { get; set; }

        [Required]
        public bool ModuleCarPool { get; set; }

        [Required]
        public bool ModuleSpecialRequestBoard { get; set; }

    }
}
