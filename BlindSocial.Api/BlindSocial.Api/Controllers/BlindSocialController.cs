using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlindSocial.Api.Controllers
{
    public class BlindSocialController : ApiController
    {
        const string subscriptionKey = "41dc37f9889a48cfa74b64d424596029";
        
        const string uriBase = "https://brazilsouth.api.cognitive.microsoft.com/vision/v1.0";

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
