using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern.Databases
{
    public class DataBase
    {
        public Dictionary<string, string> _data { get; set; }
        public string _id { get; }
        public TextBox _textbox;                //added this for printing to GUI
        public DataBase (string id, TextBox textbox)
        {
            _data = new Dictionary<string, string>();
            _id = id;
            _textbox = textbox;
        }

        public string GetID ()
        {
            return _id;
        }
        public void Add (string key, string value)
        {
            if (!_data.ContainsKey(key))
            {
                _data.Add(key, value);
            }
        }
        public void Update (string key, string value)
        {
            if (_data.ContainsKey(key))
            {
                _data[key] = value;
            }
        }
        public void Remove (string key)
        {
            if (_data.ContainsKey(key))
            {
                _data.Remove(key);
            }
        }
        public void Display ()
        {
            _textbox.AppendText($"Database: {_id}\r\n");
            foreach (var item in _data)
            {
                _textbox.AppendText($"{item.Key} | {item.Value}");
                _textbox.AppendText("\r\n");
            }
            
            _textbox.AppendText("\r\n");
        }

        public string Get (string key)
        {
            if(_data.ContainsKey(key))
            {
                return _data[key];
            }
            else
            {
                return null;
            }
        }

    }
}

