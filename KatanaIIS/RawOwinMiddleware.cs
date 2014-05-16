using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KatanaTest
{

    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class RawOwinMiddleware
    {

        private AppFunc next;

        public RawOwinMiddleware(AppFunc next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            await response.WriteAsync(Encoding.UTF8.GetBytes("Before"),0,6);

            await next.Invoke(environment);
            await response.WriteAsync(Encoding.UTF8.GetBytes("After"), 0, 5);
        }
    }
}