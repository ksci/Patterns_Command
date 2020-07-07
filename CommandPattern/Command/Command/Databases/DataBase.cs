using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Databases
{
    public class DataBase
    {
        public Dictionary<string, string> _data { get; set; }
        public string _id { get; }
        public DataBase (string id)
        {
            _data = new Dictionary<string, string>();
            _id = id;
        }

        public string GetID()
        {
            return _id;
        }
        public void Add(string key, string value)
        {
            if (!_data.ContainsKey(key))
            {
                _data.Add(key, value);
            }
        }
        public void Update (string key, string value)
        {
            if(_data.ContainsKey(key))
            {
                _data[key] = value;
            }
        }
        public void Remove (string key)
        {
            if(_data.ContainsKey(key))
            {
                _data.Remove(key);
            }
        }
        public void Display()
        {
                foreach (var item in _data)
                {
                    Console.WriteLine($"{item.Key} | {item.Value}");
                }
                Console.WriteLine("");
            
        }

        public string Get(string key)
        {
            return _data[key];
        }
    }
}
