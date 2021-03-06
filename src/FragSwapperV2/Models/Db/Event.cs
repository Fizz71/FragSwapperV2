﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FragSwapperV2.Models.Db
{
    public enum EventAccountType
    {
        Standard = 1,
        Premium = 2
    }

    // Notes: These status have matching map images by name!  Any additions or changes will
    // require you to updage /images/map and the googleMapService (for bouncing).
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

        public bool Premium { get; set; }


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

        public double? LocationLat { get; set; }

        public double? LocationLng { get; set; }

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

        [Required]
        public bool ModuleAdminQuestions { get; set; }


        // We only count these once an event is done (>Open) for summary purposes.
        [Required, DefaultValue(0)]
        public int Attendees { get; set; }

        [Required, DefaultValue(0)]
        public int Registered { get; set; }

        [Required, DefaultValue(0)]
        public int Listings { get; set; }

        [Required, DefaultValue(0)]
        public int Trades { get; set; }


    }
}
