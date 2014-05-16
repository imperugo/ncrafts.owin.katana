using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHost
{
	using global::OwinSelfHost;

	using Microsoft.Owin.Hosting;

	class Program
	{
		/// <summary>
		/// Mains the specified arguments.
		/// </summary>
		/// <param name="args">The arguments.</param>
		static void Main(string[] args)
		{
			using (WebApp.Start<Startup>("http://localhost:9000"))
			{
				Console.WriteLine("Listening to http://localhost:9000");
				Console.WriteLine("http://localhost:9000/fail to test the error page");
				Console.WriteLine("Press [enter] to quit...");
				Console.ReadLine();
			}
		}
	}
}
