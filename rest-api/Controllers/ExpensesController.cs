using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expenses.Models;
using Newtonsoft.Json.Linq;

namespace Expenses.Controllers
{
    public class ExpensesController : ApiController
    {
        private const string JsonMediaType = "application/json";
        private Repository repository = new Repository("Expenses");

        // GET api/values
        public HttpResponseMessage Get()
        {
            var data = new []
            {
                new {ClaimNumber = "123", ReceiptNumber = "1", Custom = "Jacob", Date = "01/01/2014", Amount = "123.45", Currency = "GBP", Rate = "1", SterlingValue = "123.45" },
                new {ClaimNumber = "123", ReceiptNumber = "1", Custom = "Jacob", Date = "01/01/2014", Amount = "200.25", Currency = "GBP", Rate = "1", SterlingValue = "200.25" },
                new {ClaimNumber = "123", ReceiptNumber = "1", Custom = "Magda", Date = "05/01/2014", Amount = "100.50", Currency = "GBP", Rate = "1", SterlingValue = "100.50" },
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
        public void Post(HttpRequestMessage request)
        {
            // Check whether expense has been paid, and do not allow changing if it has
            var rawData = request.Content.ReadAsStringAsync().Result;  // Reading the request directly allows us to post arbitrary JSON objects
            var parsedExpense = JObject.Parse(rawData);
            repository.SaveCategory(parsedExpense);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            // Check whether expense has been paid, and do not allow changing if it has
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}