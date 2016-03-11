using Microsoft.AspNet.Builder;
using Microsoft.Owin.Builder;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FragSwapperV2.Extensions
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class SignalRExtension
    {
        public static IApplicationBuilder UseAppBuilder(
            this IApplicationBuilder app, 
            Action<IAppBuilder> configure)
        {
            app.UseOwin(addToPipeline =>
            {
                addToPipeline(next =>
                {
                    var appBuilder = new AppBuilder();
                    appBuilder.Properties["builder.DefaultApp"] = next;

                    configure(appBuilder);

                    return appBuilder.Build<AppFunc>();
                });
            });

            return app;
        }

        public static void UseSignalR2(this IApplicationBuilder app)
        {
            app.UseAppBuilder(appBuilder => appBuilder.MapSignalR());
        }
    }
}
