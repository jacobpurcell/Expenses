using System.Collections;
using System.Web;
using Newtonsoft.Json;

namespace Expenses.Models
{
    public class Repository
    {
        private readonly string _name;
        private string Path { get { return string.Format("~/App_Data/{0}.txt", _name); }}

        public Repository(string name)
        {
            _name = name;
        }

        public IEnumerable GetCategories()
        {
            ArrayList categories = new ArrayList();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(HttpContext.Current.Server.MapPath(Path));
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
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath(Path));
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
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath(Path), true);

            var line = JsonConvert.SerializeObject(category);
            file.WriteLine(line);
            
            file.Close();
        }
    }
}