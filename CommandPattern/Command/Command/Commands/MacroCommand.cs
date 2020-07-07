using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class MacroCommand : Command
    {
        public List<Command> commands { get; set; }

        public MacroCommand ()
        {
            commands = new List<Command>();
        }

        public void Execute ()
        {
            Console.WriteLine("Beginning A Macro");
            foreach(var command in commands)
            {
                command.Execute();
            }
            Console.WriteLine("Ending A Macro");
        }

        public void Undo ()
        {
            Console.WriteLine("Begin Undoing A Macro");
            commands.Reverse();             //reverse order of list
            foreach(var command in commands)
            {
                command.Undo();
            }
            commands.Reverse();             //return list to correct order
            Console.WriteLine("End Undoing a Macro");
        }
    }
}
