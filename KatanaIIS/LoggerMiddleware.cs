using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace KatanaTest
{
    public class LoggerMiddleware : OwinMiddleware
    {
        public LoggerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            await context.Response.WriteAsync("Before");
            await Next.Invoke(context);
            await context.Response.WriteAsync("After");
        }
    }
}