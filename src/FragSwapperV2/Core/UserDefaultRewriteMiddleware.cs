using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Core
{
    public class UserDefaultRewriteMiddleware
    {
        private readonly RequestDelegate _next;
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _usermanager;

        public UserDefaultRewriteMiddleware(RequestDelegate next, ApplicationDbContext dbcontext, UserManager<ApplicationUser> usermanager)
        {
            _dbContext = dbcontext;
            _next = next;
            _usermanager = usermanager;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToUriComponent();

            // We only check the user if this is a completely empty request, the user
            // is logged in, and has never redirected.
            if ((path == "/")
                    && (context.User.Identity.IsAuthenticated)
                    && (context.Session.Get("UserRedirected") == null))
                context.Request.Path = await UserDefaultRewrite(path, context);
            await _next.Invoke(context);
        }

        private async Task<string> UserDefaultRewrite(string path, HttpContext context)
        {
            // It doesn't matter what we set it to, we just need to set it so we
            // don't check again.
            context.Session.SetInt32("UserRedirected", 1);

            var user = await _usermanager.FindByNameAsync(context.User.Identity.Name);
            if (user.settingEnableDefaultRedirect)
            {
                // We have a user that wants to be re-directed so we need to see
                // where to send them.

                //todo: need to hit up database!!!

                // 1. Check for an Open/EventDay Event

                // 2. Check for a Post Event

                // 3. Check for liked Orginazation in Open/EventDay that they 
                // haven't said NotAttending to.

                // 4. Check for liked Orginazation in Preview that they 
                // haven't said NotAttending to.

                // At this point we have nothing left to check for, so send them
                // to the home page (already in "path")
                return path;
            }
            else
                return path;
        }
    }
}
