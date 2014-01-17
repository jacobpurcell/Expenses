using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Expenses.Models;
using Newtonsoft.Json;

namespace Expenses.Controllers
{
    public class CategoryController : ApiController
    {
        private const string JsonMediaType = "application/json";
        private Repository repository = new Repository();

        // GET api/category
        public HttpResponseMessage Get()
        {
            var categories = repository.GetCategories();

            return Request.CreateResponse(HttpStatusCode.OK, categories, JsonMediaType);
        }

        // GET api/category/5
        public HttpResponseMessage Get(int id)
        {
            var category = new {};
            return Request.CreateResponse(HttpStatusCode.OK, category, JsonMediaType);
        }

        // POST api/category
        public void Post([FromBody]string value)
        {
            // TODO: get the categories from the posted data
        }

        // PUT api/category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
        public void Delete(int id)
        {
        }
    }
}
