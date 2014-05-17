using Microsoft.Owin;

using OwinWebAPI;

[assembly: OwinStartup(typeof(Startup))]

namespace OwinWebAPI
{
	using System.Web.Http;

	using Owin;

	public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "api/{controller}", new { controller = "Speakers" });

            app.UseWebApi(config);

			app.Run(context =>
			{
				context.Response.ContentType = "text/plain";
				context.Response.StatusCode = 301;
				context.Response.Headers.Add("Location",new []{"/api"});
				return context.Response.WriteAsync("If you this message something is really wrong");
			});
        }
    }
}
