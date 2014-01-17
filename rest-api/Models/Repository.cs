using System.Collections;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public void SaveCategory(object category)
        {
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/categories.txt"), true);

            var line = JsonConvert.SerializeObject(category);
            file.WriteLine(line);
            
            file.Close();
        }

        public void RemoveCategoryByName(string categoryName)
        {
            ArrayList categories = new ArrayList();

            // Read the file and display it line by line.
            System.IO.StreamReader fileReader =
                new System.IO.StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/categories.txt"));
            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                categories.Add(line);
            }

            fileReader.Close();

            // Overwrite the file with the ones we want.
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/categories.txt"), false);

            foreach (var category in categories)
            {
                var obj = JObject.Parse((string)category);
                var name = (string)obj["Name"];
                if (name != categoryName)
                {
                    var writeLine = JsonConvert.SerializeObject(category);
                    file.WriteLine(writeLine);
                }
            }

            file.Close();
        }
    }
}