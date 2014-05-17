namespace OwinWebAPI
{
	using System.Collections.Generic;
	using System.Web.Http;

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