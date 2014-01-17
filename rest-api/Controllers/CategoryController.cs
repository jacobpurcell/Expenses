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
using Newtonsoft.Json.Linq;

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
        public void Post(HttpRequestMessage req) //[FromBody]string value  
        {
            var data = req.Content.ReadAsStringAsync().Result;  // Reading the request directly allows us to post arbitrary JSON objects
            var obj = JObject.Parse(data);
            var category = (object)obj["category"];
            repository.SaveCategory(category);
        }

        // PUT api/category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/categoryName
        public void Delete(string categoryName)
        {
            repository.RemoveCategoryByName(categoryName);
        }
    }
}
