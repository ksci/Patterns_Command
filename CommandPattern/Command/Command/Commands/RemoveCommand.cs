using CommandPattern.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand (DataBase database, string key, string value)
        {
            _database = database;
            _key = key;
            _value = value;
        }

        public DataBase _database { get; set; }
        public string _key { get; set; }
        public string _value { get; set; }
        public string _previousValue { get; set; }
        public void Execute ()
        {
            _previousValue = _database.Get(_key);
            _database.Remove(_key);
        }

        public void Undo ()
        {
            _database.Add(_key, _previousValue);
            Console.WriteLine("Undid Remove Command");
            _database.Display();
        }
    }
}
