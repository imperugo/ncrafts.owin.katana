namespace OwinMiddlewares
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using System.Threading.Tasks;

	public class RawOwinMiddleware
    {

        private Func<IDictionary<string, object>, Task> next;

        public RawOwinMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
			await response.WriteAsync(Encoding.UTF8.GetBytes("Before (raw owin middleware class)\r\n"), 0, 36);

            await this.next.Invoke(environment);
			await response.WriteAsync(Encoding.UTF8.GetBytes("After (raw owin middleware class)\r\n"), 0, 35);
        }
    }
}