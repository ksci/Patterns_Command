/*Author:       Kyle Miller
 * Project:     Command Pattern CS 3450
 * Purpose:     Build a program that reads in a file, makes command objects
 * and then executes those commands.  Finally, undo those commands
 * 
 * Declaration: I wrote all this code.
 * 
 */

using System;
using CommandPattern.Invokers;

namespace CommandPattern
{
    public class Program
    {      
        static void Main()
        {

            Parser.ParseFile(@"Update.txt");

            Invoker.ExecuteAll();
            Invoker.PrintAllDataBases();

            Invoker.UndoAll();
            Invoker.PrintAllDataBases();

            Console.ReadKey();

        }                
    }
}
