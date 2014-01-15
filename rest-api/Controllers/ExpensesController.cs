using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Web.Http;
using MongoDB.Bson;

namespace Expenses.Controllers
{
    public class ExpensesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            //return new string[] { "value1", "value2" };

            var data = new []
            {
                new {FieldA = "1", FieldB = "2"},
                new {FieldA = "10", FieldB = "20"}
            };

            return Request.CreateResponse(HttpStatusCode.OK, data, new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}