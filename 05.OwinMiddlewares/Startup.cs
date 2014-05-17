using Microsoft.Owin;

using OwinMiddlewares;

[assembly: OwinStartup(typeof(Startup))]

namespace OwinMiddlewares
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using System.Threading.Tasks;

	using Owin;

	public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            app.Use(new Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>(next => (async env =>
            {
                var response = env["owin.ResponseBody"] as Stream;
                await response.WriteAsync(Encoding.UTF8.GetBytes("Before (Inline AppFunc)\r\n"), 0, 25);
                await next.Invoke(env);
				await response.WriteAsync(Encoding.UTF8.GetBytes("After (Inline AppFunc)\r\n"), 0, 24);

            })));

            app.Use<RawOwinMiddleware>();

            app.Use<LoggerMiddleware>();

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello Paris!\r\n");
            });
        }
    }
}
