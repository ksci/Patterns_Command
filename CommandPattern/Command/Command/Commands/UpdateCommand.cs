using CommandPattern.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{

    public class UpdateCommand : Command
    {
        public DataBase _database { get; set; }
        public string _key { get; set; }
        public string _value { get; set; }
        public string _previousValue;

        public UpdateCommand (DataBase database, string key, string value)
        {
            _database = database;
            _key = key;
            _value = value;
        }

        public void Execute ()
        {
            _previousValue = _database.Get(_key);
            _database.Update(_key,_value);
        }

        public void Undo ()
        {
            _database.Update(_key, _previousValue);
            Console.WriteLine("Undid Update Command");
            _database.Display();
        }
    }
}
