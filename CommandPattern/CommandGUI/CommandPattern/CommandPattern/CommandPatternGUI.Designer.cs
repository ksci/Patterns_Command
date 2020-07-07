namespace CommandPattern
{
    partial class CommandPatternGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.selectFileButton = new System.Windows.Forms.Button();
            this.inputFileNameTextBox = new System.Windows.Forms.TextBox();
            this.selectCommandsListBox = new System.Windows.Forms.CheckedListBox();
            this.selectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.runCommandsbutton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.undoCommandsButton = new System.Windows.Forms.Button();
            this.HistoryBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFileButton
            // 
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileButton.Location = new System.Drawing.Point(38, 13);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(117, 31);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // inputFileNameTextBox
            // 
            this.inputFileNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputFileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputFileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFileNameTextBox.Location = new System.Drawing.Point(174, 19);
            this.inputFileNameTextBox.Name = "inputFileNameTextBox";
            this.inputFileNameTextBox.Size = new System.Drawing.Size(156, 17);
            this.inputFileNameTextBox.TabIndex = 1;
            // 
            // selectCommandsListBox
            // 
            this.selectCommandsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCommandsListBox.FormattingEnabled = true;
            this.selectCommandsListBox.Location = new System.Drawing.Point(38, 82);
            this.selectCommandsListBox.Name = "selectCommandsListBox";
            this.selectCommandsListBox.Size = new System.Drawing.Size(292, 441);
            this.selectCommandsListBox.TabIndex = 2;
            this.selectCommandsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SelectCommandsListBox_ItemCheck);
            this.selectCommandsListBox.SelectedIndexChanged += new System.EventHandler(this.SelectCommandsListBox_SelectedIndexChanged);
            // 
            // selectFileDialog
            // 
            this.selectFileDialog.FileName = "openFileDialog1";
            // 
            // runCommandsbutton
            // 
            this.runCommandsbutton.Enabled = false;
            this.runCommandsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runCommandsbutton.Location = new System.Drawing.Point(38, 529);
            this.runCommandsbutton.Name = "runCommandsbutton";
            this.runCommandsbutton.Size = new System.Drawing.Size(292, 31);
            this.runCommandsbutton.TabIndex = 3;
            this.runCommandsbutton.Text = "Run Commands";
            this.runCommandsbutton.UseVisualStyleBackColor = true;
            this.runCommandsbutton.Visible = false;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(390, 63);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(388, 460);
            this.logTextBox.TabIndex = 4;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logLabel.Location = new System.Drawing.Point(745, 42);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(33, 18);
            this.logLabel.TabIndex = 5;
            this.logLabel.Text = "Log";
            // 
            // undoCommandsButton
            // 
            this.undoCommandsButton.Enabled = false;
            this.undoCommandsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoCommandsButton.Location = new System.Drawing.Point(38, 566);
            this.undoCommandsButton.Name = "undoCommandsButton";
            this.undoCommandsButton.Size = new System.Drawing.Size(292, 31);
            this.undoCommandsButton.TabIndex = 6;
            this.undoCommandsButton.Text = "Undo Commands";
            this.undoCommandsButton.UseVisualStyleBackColor = true;
            this.undoCommandsButton.Visible = false;
            // 
            // HistoryBoxLabel
            // 
            this.HistoryBoxLabel.AutoSize = true;
            this.HistoryBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryBoxLabel.Location = new System.Drawing.Point(35, 63);
            this.HistoryBoxLabel.Name = "HistoryBoxLabel";
            this.HistoryBoxLabel.Size = new System.Drawing.Size(55, 18);
            this.HistoryBoxLabel.TabIndex = 7;
            this.HistoryBoxLabel.Text = "History";
            // 
            // CommandPatternGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 625);
            this.Controls.Add(this.HistoryBoxLabel);
            this.Controls.Add(this.undoCommandsButton);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.runCommandsbutton);
            this.Controls.Add(this.selectCommandsListBox);
            this.Controls.Add(this.inputFileNameTextBox);
            this.Controls.Add(this.selectFileButton);
            this.Name = "CommandPatternGUI";
            this.Text = "Command Pattern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox inputFileNameTextBox;
        private System.Windows.Forms.CheckedListBox selectCommandsListBox;
        private System.Windows.Forms.OpenFileDialog selectFileDialog;
        private System.Windows.Forms.Button runCommandsbutton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button undoCommandsButton;
        private System.Windows.Forms.Label HistoryBoxLabel;
    }
}

