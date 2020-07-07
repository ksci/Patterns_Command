using CommandPattern.Databases;

namespace CommandPattern
{
    public struct ArgStruct
    {
        public DataBase _database;
        public string _command;
        public string _key;
        public string _value;

        public ArgStruct (DataBase database, string command, string key, string value)
        {
            _database = database;
            _command = command;
            _key = key;
            _value = value;
        }
    }
}