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

        public IEnumerable GetItems()
        {
            ArrayList items = new ArrayList();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(HttpContext.Current.Server.MapPath(Path));
            string line;
            while ((line = file.ReadLine()) != null)
            {
                items.Add(JsonConvert.DeserializeObject(line));
            }

            file.Close();

            return items;
        }

        public void SaveItems(object[] items)
        {
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath(Path));
            foreach (var category in items)
            {
                var line = JsonConvert.SerializeObject(category);
                file.WriteLine(line);
            }
            
            file.Close();
        }

        public void SaveItem(object item)
        {
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath(Path), true);

            var line = JsonConvert.SerializeObject(item);
            file.WriteLine(line);
            
            file.Close();
        }
    }
}