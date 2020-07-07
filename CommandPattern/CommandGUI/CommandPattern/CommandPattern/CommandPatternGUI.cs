using CommandPattern.Commands;
using CommandPattern.Databases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern
{
    public partial class CommandPatternGUI : Form
    {
        
        public CommandPatternGUI ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Choose the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_Click (object sender, EventArgs e)
        {
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = selectFileDialog.FileName;

                inputFileNameTextBox.Text = Path.GetFileName(filePath);
                CreateCommandList(filePath);
                CreateCheckedListBoxActions();
                ExecuteAllCommands();
                DisplayContentsOfDatabases();
                historyIndex = commands.Count()-1;
            }
        }

        /// <summary>
        /// Read in file and display in a checked list box.  This will allow the user to
        /// select which actions they wish to execute
        /// </summary>
        /// <param name="filePath"></param>
        private void CreateCheckedListBoxActions()
        {
            //selectCommandsListBox.Items.Clear();
            foreach (var command in commands)
            {
                selectCommandsListBox.Items.Add(command.ToString(),true);
            }
        }

        /// <summary>
        /// Prevent the user from eliminating a macro command.  They can remove the contents of the macro
        /// but not the macro itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCommandsListBox_ItemCheck (object sender, ItemCheckEventArgs e)
        {
            
            //e.NewValue = CheckState.Checked;

        }

        /// <summary>
        /// Creates a list of Commands from the temp file
        /// </summary>
        /// <param name="filePath"></param>
        private void CreateCommandList(string filePath)
        {
            commands.Clear();
            commands.Add(new MacroCommand());
            using( StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    Command newCommand;
                    var line = sr.ReadLine();
                    if (line.ElementAt(0) != 'B')
                    {
                        ArgStruct args = ParseLine(line);
                        newCommand = FunctionsDictionary[args._command](args);
                    }
                    else
                    {
                        newCommand = CreateMacro(new MacroCommand(), sr);
                    }

                    commands.Add(newCommand);

                }
            }
        }

        /// <summary>
        /// Execute all commands stored in commands List
        /// </summary>
        private void ExecuteAllCommands()
        {
            foreach (var command in commands)    //Execute all commands 
            {
                command.Execute();
            }
        }

        private void ExecuteCommands(int startIndex, int endIndex)
        {
            for (int i = startIndex+1; i <= endIndex; i++)
            {
                commands[i].Execute();
            }
        }
        /// <summary>
        /// Undo all commands stored in List<Command> commands
        /// </summary>
        private void UndoCommands (int startIndex, int endIndex)
        {
            for (int i = startIndex; i > endIndex; i--)
            {
                commands[i].Undo();
            }

        }
        private void DisplayContentsOfDatabases()
        {
            foreach (var database in dataBases)
            {
                database.Value.Display();
            }
        }
        

        private void SelectCommandsListBox_SelectedIndexChanged (object sender, EventArgs e)
        {
            
            GreyOutItems();
            if(selectCommandsListBox.SelectedIndex > historyIndex)
            {
                ExecuteCommands(historyIndex, selectCommandsListBox.SelectedIndex);
            }
            else if (selectCommandsListBox.SelectedIndex < historyIndex)
            {
                UndoCommands(historyIndex, selectCommandsListBox.SelectedIndex);                
            }
            if(historyIndex != selectCommandsListBox.SelectedIndex)
            {
                historyIndex = selectCommandsListBox.SelectedIndex;
                logTextBox.AppendText("DataBases Updated to the following values: \r\n");
                logTextBox.AppendText("***************************************************** \r\n");

                foreach (var database in dataBases)
                {
                    database.Value.Display();
                }
            }
            
        }
        private void GreyOutItems()
        {
            for(int i = 0; i <= selectCommandsListBox.SelectedIndex; i++)
            {
                selectCommandsListBox.SetItemCheckState(i, CheckState.Checked);

            }
            for (int i = selectCommandsListBox.SelectedIndex + 1; i < commands.Count; i++)
            {
                selectCommandsListBox.SetItemCheckState(i, CheckState.Indeterminate);
            }
        }
    }
}
