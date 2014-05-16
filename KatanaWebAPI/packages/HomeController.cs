using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KatanaWebAPI
{
    public class HomeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "Ugo Lattanzi", "Simone Chiaretta" };
        }
    }
}