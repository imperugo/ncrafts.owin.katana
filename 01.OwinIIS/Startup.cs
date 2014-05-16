using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinIIS.Startup))]

namespace OwinIIS
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
