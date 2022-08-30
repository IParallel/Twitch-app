using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TwitchApp.BDModels
{
    public class ChildKeyModel
    {
        public string name;
        public string image;
        public string key;
        public string qty;

        public ChildKeyModel(string name, string image, string key, string qty)
        {
            this.name = name;
            this.image = image;
            this.key = key;
            this.qty = qty;
        }
    }

    public class Config<T>
    {
        private List<T> data = new();
        private readonly string route = @"configs\";
        private readonly string fileName;

        public Config(string fileName)
        {
            this.fileName = $"{fileName}.json";
        }
        public void Save()
        {
            if (!Directory.Exists(route)) Directory.CreateDirectory(route);
            string SaveString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(route + fileName, SaveString);
        }

        public List<T> GetAll()
        {
            return data;
        }

        public void Load()
        {
            try
            {
                var LoadString = File.ReadAllText(route+fileName);

                #pragma warning disable CS8601 // Posible asignación de referencia nula
                data = JsonConvert.DeserializeObject<List<T>>(LoadString);
                #pragma warning restore CS8601 // Posible asignación de referencia nula
            }
            catch { }
        }

        public void Add(T Element)
        {
            data.Add(Element);
            Save();
        }

        public List<T> Search(Func<T, bool> thing)
        {
            return data.Where(thing).ToList();
        }

        public void Delete(Func<T, bool> thing)
        {
            data = data.Where(x => !thing(x)).ToList();
            Save();
        }

        public void Update(Func<T, bool> thing, T New)
        {
            data = data.Select(x =>
            {
                if (thing(x)) x = New;
                return x;
            }).ToList();
            Save();
        }
    }
}
