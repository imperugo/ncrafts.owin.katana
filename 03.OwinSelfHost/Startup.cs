using Microsoft.Owin;

using OwinSelfHost;

[assembly: OwinStartup(typeof(Startup))]

namespace OwinSelfHost
{
	using System;

	using Owin;

	public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            app.UseErrorPage();
            app.Run(context =>
            {
                // New code: Throw an exception for this URI path.
                if (context.Request.Path.ToString().Equals("/fail"))
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}
