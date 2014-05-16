using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Twitter;
using Owin;

[assembly: OwinStartup(typeof(KatanaTest.Startup))]

namespace KatanaTest
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                var response = env["owin.ResponseBody"] as Stream;
                await response.WriteAsync(Encoding.UTF8.GetBytes("Before"), 0, 6);
                await next.Invoke(env);
                await response.WriteAsync(Encoding.UTF8.GetBytes("After"), 0, 5);

            })));

            app.Use<RawOwinMiddleware>();

            app.Use<LoggerMiddleware>();

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello Paris!");
            });
        }
    }
}
