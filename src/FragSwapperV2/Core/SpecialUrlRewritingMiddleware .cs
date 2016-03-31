using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Core
{
    public class SpecialUrlRewritingMiddleware
    {
        private readonly RequestDelegate _next;
        private ApplicationDbContext _dbContext;

        // Controller names we know to skip to save time by not hitting the database.
        const string knownControllers = "|Account|Home|Manage|Event|";

        public SpecialUrlRewritingMiddleware(RequestDelegate next, ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToUriComponent();

            // Since this process will hit the database we'd like to avoid it
            // if we know for a fact this is not a URL we want to mess with. 
            // We only care about URLs with one "/" before a text string that
            // we know are not controllers that exist.

            // Skip "/" only, or controller names we already know and Don't waste our time with paths that have more than one /.
            if ((path!="/") && (!knownControllers.Contains("|"+ path+ "|")) && (path.Split('/').Length == 2))
            {
                context.Request.Path = SpecialPathRewrite(path);
            }

            //Let the next middleware (MVC routing) handle the request
            //In case the path was updated, the MVC routing will see the updated path
            await _next.Invoke(context);
        }

        // We want to see if the contents of path represents a host, and if it does see if there are any event
        // in this order:  Open, EventDay, Post, Preview.  Events by host can never overlap times of being Open
        // or EventDay and a Post Event takes presidence over one in Preview.
        private string SpecialPathRewrite(string path)
        {
            string special = path.Replace("/", "");

            // See if we have a Host.
            Host h = _dbContext.Hosts
                .FirstOrDefault(x => x.ShortName == special);

            // If we don't have a host then we found nothing special but we need to keep going with the
            // existing path that came in so we pass it back out.
            if (h == null) return path;

            // Does the host have an active event?  
            Event e = _dbContext.Events
                .FirstOrDefault(x => ((x.Host.ID == h.ID) && (x.Status >= EventStatus.Open) && (x.Status <= EventStatus.PostEvent)));
            if (e != null) return "/Event/" + e.ID.ToString();

            // How about a preview event?  
            e = _dbContext.Events
                .FirstOrDefault(x => ((x.Host.ID == h.ID) && (x.Status == EventStatus.Preview)));
            if (e != null) return "/Event/" + e.ID.ToString();

            // Ok...We have a host but no active event so go to the host page.
            return "/Home/Host/" + h.ID.ToString();
        }
    }
}
