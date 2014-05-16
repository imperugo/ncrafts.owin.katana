using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KatanaWebApi
{
    public class SpeakersController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Simone Chiaretta", "Ugo Lattanzi" };
        }
    }
}