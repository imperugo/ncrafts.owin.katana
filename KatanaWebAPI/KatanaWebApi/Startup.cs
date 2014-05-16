using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KatanaWebAPI.Startup))]

namespace KatanaWebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "api/{controller}", new { controller = "Speakers" });

            app.UseWebApi(config);
        }
    }
}
