using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public static class Factory
    {
        //stores Delegates for Command creation
        static SortedDictionary<string, Func<ArgStruct, Command>> FunctionsDictionary =
            new SortedDictionary<string, Func<ArgStruct, Command>>          
            {
                {"A", new Func<ArgStruct, Command>(MakeAdd) },
                {"R", new Func<ArgStruct, Command>(MakeRemove) },
                {"U", new Func<ArgStruct, Command>(MakeUpdate) }
            };

        //The following methods are for creating the Command Objects

        public static Command MakeCommand(ArgStruct args)
        {
            return FunctionsDictionary[args._command](args);
        }

        static Command MakeAdd (ArgStruct args)
        {
            Command command = new AddCommand(args._database, args._key, args._value);
            return command;
        }
        static Command MakeRemove (ArgStruct args)
        {
            Command command = new RemoveCommand(args._database, args._key, args._value);
            return command;
        }
        static Command MakeUpdate (ArgStruct args)
        {
            Command command = new UpdateCommand(args._database, args._key, args._value);
            return command;
        }

        //A recursive function for handling the creation of the macro commands

        public static Command CreateMacro (MacroCommand macroCommand, StreamReader sr)
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
                ArgStruct args = Parser.ParseLine(line);
                macroCommand.commands.Add(Factory.MakeCommand(args));
                CreateMacro(macroCommand, sr);
            }

            return macroCommand;
        }
    }
}
