using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Controllers
{
    public class ExpensesController : ApiController
    {
        private const string JsonMediaType = "application/json";

        // GET api/values
        public HttpResponseMessage Get()
        {
            var data = new []
            {
                new {FieldA = "1", FieldB = "2"},
                new {FieldA = "10", FieldB = "20"}
            };

            return Request.CreateResponse(HttpStatusCode.OK, data, JsonMediaType);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var data =  new {FieldA = "10", FieldB = "20"};
            return Request.CreateResponse(HttpStatusCode.OK, data, JsonMediaType);
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