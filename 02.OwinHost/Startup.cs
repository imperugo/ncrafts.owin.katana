using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinHost.Startup))]

namespace OwinHost
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Run(context =>
			{
				context.Response.ContentType = "text/plain";
				return context.Response.WriteAsync("Hello Paris!");
			});
		}
	}
}
