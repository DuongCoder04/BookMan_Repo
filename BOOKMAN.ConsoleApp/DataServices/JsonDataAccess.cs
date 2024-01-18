using Newtonsoft.Json;
namespace BOOKMAN.ConsoleApp.DataServices
{
    using Models;
    using System.Collections.Generic;
    using System.IO;

    public class JsonDataAccess :  IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = Config.Instance.DataFile;// "data.json";
        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return ;
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sRender = new StreamReader(_file))
            using (JsonReader jReader = new JsonTextReader(sRender))
            {
                Books = serializer.Deserialize<List<Book>>(jReader);
            }
            //var jsonString = File.ReadAllText(_file);
            //Books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
        }
        public void SaveChanges()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sWriter = new StreamWriter(_file))
            using (JsonWriter jWriter = new JsonTextWriter(sWriter))
            {
                serializer.Serialize(jWriter, Books);
            }
            //var jsonString = JsonConvert.SerializeObject(Books, Formatting.Indented);
            //File.WriteAllText(this._file, jsonString);
        }
    }
}
