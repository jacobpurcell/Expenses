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

        // GET api/category
        public HttpResponseMessage Get()
        {
            var repository = new Repository();
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
            var categories = new object[]
            {
                new 
                { 
                    Name="Train", 
                    Details = new []
                    {
                        new { Name="OutDate", Type="DateTime", Required=false, Value="01/01/2014"}, 
                        new { Name="From", Type="string", Required=false, Value=""}, 
                        new { Name="To", Type="string", Required=false, Value=""}
                    } 
                },
                new 
                { 
                    Name="Car Rental", 
                    Details = new []
                    {
                        new { Name="NumberOfDays", Type="Integer", Required=false, Value=10 }
                    }  
                },
            };

            var repository = new Repository();
            repository.SaveCategories(categories);
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
