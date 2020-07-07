using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Databases;

namespace CommandPattern.Commands
{
    public class AddCommand : Command
    {
        public DataBase _dataBase { get; }
        public string _key { get; }
        public string _value { get; }

        public AddCommand (DataBase dataBase, string key, string value)
        {
            _dataBase = dataBase;
            _key = key;
            _value = value;
        }

        public void Execute ()
        {
            _dataBase.Add(_key, _value);
        }

        public void Undo ()
        {
            _dataBase.Remove(_key);
        }
        public override string ToString ()
        {
            return ($"Add: {_dataBase.GetID()}, K:{_key}, V:{_value}");
        }
    }
}
