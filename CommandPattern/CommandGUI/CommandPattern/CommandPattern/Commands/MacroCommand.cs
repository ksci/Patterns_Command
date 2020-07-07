using System;
using System.Collections.Generic;
using System.IO;
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
            foreach(var command in commands)
            {
                command.Execute();
            }
        }

        public void Undo ()
        {

            commands.Reverse();             //reverse order of list
            foreach(var command in commands)
            {
                command.Undo();
            }
            commands.Reverse();             //return list to correct order
        }

        public override string ToString ()
        {
            if (commands.Count > 0)
            {
                return $"Macro with {commands.Count} commands";

            }
            else
            {
                return $"Beginnning of History";
            }
        }
    }
}
