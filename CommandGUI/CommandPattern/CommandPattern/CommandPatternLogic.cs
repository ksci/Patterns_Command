using CommandPattern.Commands;
using CommandPattern.Databases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern
{
    public partial class CommandPatternGUI : Form
    {
        //stores Delegates for Command creation
        static SortedDictionary<string, Func<ArgStruct, Command>> FunctionsDictionary =
            new SortedDictionary<string, Func<ArgStruct, Command>>          
            {
                {"A", MakeAdd },
                {"R", MakeRemove },
                {"U", MakeUpdate }
            };

        //stores the Databases
        static Dictionary<string, DataBase> dataBases =
                new Dictionary<string, DataBase>();

        //stores the sequence of database commands
        static List<Command> commands = new List<Command>();                
        
        
        //The following methods are for creating the Command Objects
        static int historyIndex = 0;
        static Command MakeAdd (ArgStruct args)
        {
            return new AddCommand(args._database, args._key, args._value);
        }
        static Command MakeRemove (ArgStruct args)
        {
            return new RemoveCommand(args._database, args._key, args._value);
        }
        static Command MakeUpdate (ArgStruct args)
        {
            return new UpdateCommand(args._database, args._key, args._value);
        }

        //Create a struct for holding the arguments from the line read in by the streamreader
        private ArgStruct ParseLine (string line)
        {
            string[] words = line.Split();
            string command = words[0];
            string dataBaseKey = words[1];
            DataBase dataBaseValue;
            //check to see if database exists
            if (dataBases.ContainsKey(dataBaseKey))
            {
                dataBaseValue = dataBases[dataBaseKey];
            }
            else
            {
                dataBaseValue = new DataBase(dataBaseKey,logTextBox);
                dataBases.Add(dataBaseKey, dataBaseValue);
            }
            string key = words[2];
            string value = string.Join(" ", words, 3, words.Length - 3);
            return new ArgStruct(dataBaseValue, command, key, value);
        }

        //A recursive function for handling the creation of the macro commands
        private Command CreateMacro (MacroCommand macroCommand, StreamReader sr)
        {
            var line = sr.ReadLine();
            //base case, macro section is complete
            if (line.ElementAt(0) == 'E')
            {
                return macroCommand;
            }

            //nested macro case
            else if (line.ElementAt(0) == 'B')
            {
                macroCommand.commands.Add(CreateMacro(new MacroCommand(), sr));
            }

            //add line to macro and run function again
            else
            {
                ArgStruct args = ParseLine(line);
                macroCommand.commands.Add(FunctionsDictionary[args._command](args));
                CreateMacro(macroCommand, sr);
            }

            return macroCommand;
        }
    }
}
