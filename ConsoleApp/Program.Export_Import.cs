using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConsoleApp
{
    public partial class Program
    {
        private static void Import()
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = $".json|*.json|.xml|*.xml"
            };

            if(dialog.ShowDialog() != DialogResult.OK)
                return;

            string json;
            switch (dialog.FileName.Split('.').Last())
            {
                case "json":
                    json = File.ReadAllText(dialog.FileName);
                    break;
                case "xml":
                    var xml = XDocument.Load(dialog.FileName);
                    json = JsonConvert.SerializeXNode(xml.Root, Formatting.None, true);
                    var indexOfStart = json.IndexOf('[');
                    var indexOfEnd = json.IndexOf(']');
                    if(indexOfStart >= 0 && indexOfEnd >= 0)
                        json = json.Substring(indexOfStart, indexOfEnd - indexOfStart + 1);
                    break;
                default:
                    return;
            }

            var token = JToken.Parse(json);
            ICollection<Person> people;
            if (token is JArray)
                people = token.ToObject<List<Person>>();
            else
                people = new List<Person> { token.ToObject<Person>() } ;

            //var person = JsonConvert.DeserializeObject<Person>(json);
            foreach (var person in people)
            {
                Edit(person);
                Service.Create(person);
            }

        }

        public static void Export(int id)
        {
            if (id == 0)
                Export(Service.Read(), "", nameof(Person), "People");
            else
            {
                var person = Service.Read(id);
                Export(person, $"{person.LastName} {person.FirstName}");
            }
        }

        private static void Export(object @object, string fileName = "", string xmlElementName = null, string xmlRootName = null)
        {

            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                FileName = fileName,
                Filter = $".json|*.json|.xml|*.xml|{Properties.Resources.AllFiles}|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd.MM.yyyy",
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(@object, serializerSettings);
            switch (dialog.FileName.Split('.').Last())
            {
                case "json":
                    File.WriteAllText(dialog.FileName, json);
                    break;
                case "xml":
                    var xml = JsonConvert.DeserializeXNode($"{{\"{xmlElementName}\": {json}}}", xmlRootName);
                    xml.Save(dialog.FileName);
                    break;
            }

            /*//var memoryStream = new MemoryStream();
            var file = dialog.OpenFile();
            using (var writer = new StreamWriter(file))
            {
                writer.Write(json);
                //writer.Dispose();
            }*/

        }
    }
}
