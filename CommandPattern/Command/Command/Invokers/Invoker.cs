using CommandPattern.Commands;
using CommandPattern.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Invokers
{
    public static class Invoker
    {
        //The Invoker wil be keeping track of the commands that have been read in and the databases created
        public static Dictionary<string, DataBase> dataBases =
                new Dictionary<string, DataBase>();                         //stores the Databases
        public static List<Command> commands = new List<Command>();                //stores the sequence of database commands

        public static void PrintAllDataBases ()
        {
            Console.WriteLine("");
            Console.WriteLine("Contents of Databases:");
            foreach (var database in dataBases)
            {
                Console.WriteLine($"Database {database.Value.GetID()}:");
                database.Value.Display();
            }
        }

        public static void UndoAll()
        {
            commands.Reverse();                 //reverse the list order before calling undo
            foreach (var command in commands)
            {
                command.Undo();
            }
            commands.Reverse();
        }

        public static void ExecuteAll()
        {
            foreach (var command in commands)    //Execute all commands 
            {
                command.Execute();
            }
        }
    }
}
