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
                new { ReceiptNumber="1", Date = "2/2/12", Description="Description goes here", Miles="10", CurrencyAmount="10.20", CurrencyCode="GBP", ExchangeRate="1.0" },
                new { ReceiptNumber="10", Date = "20/1/14", Description="Description goes here", Miles="10", CurrencyAmount="10.20", CurrencyCode="GBP", ExchangeRate="1.0" }
            };

            return Request.CreateResponse(HttpStatusCode.OK, data, JsonMediaType);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var data =  new { ReceiptNumber = "10", Date = "20/12/12", Description="Description goes here", Miles="10", CurrencyAmount="10.20", CurrencyCode="GBP", ExchangeRate="1.0" };
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