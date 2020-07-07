using CommandPattern.Commands;
using CommandPattern.Databases;
using CommandPattern.Invokers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public static class Parser
    {
        /// <summary>
        /// Parse the entire file, send off to subroutines as required to create Commands and save them to the invoker
        /// </summary>
        /// <param name="path"></param>
        public static void ParseFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))   //Read the file in, create Commands and add to list
            {
                while (!sr.EndOfStream)
                {
                    Command newCommand;
                    var line = sr.ReadLine();
                    if (line.ElementAt(0) != 'B')
                    {
                        ArgStruct args = ParseLine(line);
                        newCommand = Factory.MakeCommand(args);
                    }
                    else
                    {
                        newCommand = Factory.CreateMacro(new MacroCommand(), sr);
                    }

                    Invoker.commands.Add(newCommand);

                }
            }
        }
        /// <summary>
        /// parse the specific line.  This is separate from the parse file and is also public
        /// because of the need to parselines directly from the createMacro recursive function.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static ArgStruct ParseLine (string line)
        {
            string[] words = line.Split();
            string command = words[0];
            string dataBaseKey = words[1];
            DataBase dataBaseValue;
            //check to see if database exists
            if (Invoker.dataBases.ContainsKey(dataBaseKey))
            {
                dataBaseValue = Invoker.dataBases[dataBaseKey];
            }
            else
            {
                dataBaseValue = new DataBase(dataBaseKey);
                Invoker.dataBases.Add(dataBaseKey, dataBaseValue);
            }
            string key = words[2];
            string value = string.Join(" ", words, 3, words.Length - 3);
            return new ArgStruct(dataBaseValue, command, key, value);
        }
    }
}
