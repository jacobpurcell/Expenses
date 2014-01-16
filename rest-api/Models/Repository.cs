using System.Collections;
using System.Web;
using Newtonsoft.Json;

namespace Expenses.Models
{
    public class Repository
    {
        public IEnumerable GetCategories()
        {
            ArrayList categories = new ArrayList();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/categories.txt"));
            string line;
            while ((line = file.ReadLine()) != null)
            {
                categories.Add(JsonConvert.DeserializeObject(line));
            }

            file.Close();

            return categories;
        }

        public void SaveCategories(object[] categories)
        {
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/categories.txt"));
            foreach (var category in categories)
            {
                var line = JsonConvert.SerializeObject(category);
                file.WriteLine(line);
            }
            
            file.Close();
        }
    }
}