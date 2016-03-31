using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;
using Newtonsoft.Json;
using Microsoft.AspNet.Authorization;

namespace FragSwapperV2.Api
{
    public class EventsController : Controller
    {
        ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/Events/GetCurrent")]
        public string GetCurrent()
        {
            var emf = new EventMapFilter();
            emf.StatusFrom = EventStatus.Preview;
            emf.StatusTo = EventStatus.EventDay;
            return GetFilteredEvents(emf);
        }

        [HttpGet]
        [Route("api/Events/GetArchived")]
        public string GetArchived(string filter)
        {
            var eventsFilter = JsonConvert.DeserializeObject<EventMapFilter>(filter);
            eventsFilter.StatusFrom = EventStatus.Archived;
            eventsFilter.StatusTo = EventStatus.Archived;
            return GetFilteredEvents(eventsFilter);
        }

        private string GetFilteredEvents(EventMapFilter filter)
        {
            var query = _context.Events.AsQueryable();
            if (filter.StatusFrom != null)
                query = query.Where(e => (e.Status >= filter.StatusFrom));
            if (filter.StatusTo != null)
                query = query.Where(e => (e.Status <= filter.StatusTo));
            if ((filter.EventName != null) && (filter.EventName.Length > 0))
                query = query.Where(e => (e.Name.Contains(filter.EventName)));
            if (filter.EventYear != null)
                query = query.Where(e => (e.EventDate.Year == filter.EventYear));

            var res = query
                .Select(mi => new EventMapItem
                {
                    EventID = mi.ID,
                    Status = mi.Status.ToString(),
                    EventDate = mi.EventDate.ToString("MMMM dd, yyyy"),
                    Name = mi.Name,
                    HostName = mi.Host.ShortName,
                    LocationLat = mi.LocationLat,
                    LocationLng = mi.LocationLng
                }).ToList<EventMapItem>();

            return JsonConvert.SerializeObject(res);
        }
    }
}
