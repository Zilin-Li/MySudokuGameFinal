namespace MySudokuGame
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xSudokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameBoard = new System.Windows.Forms.Panel();
            this.GameOption = new System.Windows.Forms.Panel();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.HintButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.Mytime = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.testbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GameInfo = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.GameOption.SuspendLayout();
            this.GameInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1994, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem1,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem,
            this.xSudokuToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(171, 41);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // easyToolStripMenuItem1
            // 
            this.easyToolStripMenuItem1.Name = "easyToolStripMenuItem1";
            this.easyToolStripMenuItem1.Size = new System.Drawing.Size(315, 46);
            this.easyToolStripMenuItem1.Text = "Easy";
            this.easyToolStripMenuItem1.Click += new System.EventHandler(this.EasyToolStripMenuItem1_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(315, 46);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.MediumToolStripMenuItem_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(315, 46);
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.HardToolStripMenuItem_Click);
            // 
            // xSudokuToolStripMenuItem
            // 
            this.xSudokuToolStripMenuItem.Name = "xSudokuToolStripMenuItem";
            this.xSudokuToolStripMenuItem.Size = new System.Drawing.Size(315, 46);
            this.xSudokuToolStripMenuItem.Text = "X Sudoku";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(144, 41);
            this.optionsToolStripMenuItem1.Text = "Options..";
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(278, 46);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(278, 46);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(278, 46);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(102, 41);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(99, 41);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(87, 41);
            this.hintToolStripMenuItem.Text = "Hint";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(108, 41);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // GameBoard
            // 
            this.GameBoard.AutoSize = true;
            this.GameBoard.Location = new System.Drawing.Point(347, 54);
            this.GameBoard.Margin = new System.Windows.Forms.Padding(2);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(944, 952);
            this.GameBoard.TabIndex = 1;
            // 
            // GameOption
            // 
            this.GameOption.AutoSize = true;
            this.GameOption.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GameOption.Controls.Add(this.RestoreButton);
            this.GameOption.Controls.Add(this.SaveButton);
            this.GameOption.Controls.Add(this.HintButton);
            this.GameOption.Controls.Add(this.UndoButton);
            this.GameOption.Controls.Add(this.PauseButton);
            this.GameOption.Controls.Add(this.RedoButton);
            this.GameOption.Location = new System.Drawing.Point(59, 98);
            this.GameOption.Margin = new System.Windows.Forms.Padding(2);
            this.GameOption.Name = "GameOption";
            this.GameOption.Size = new System.Drawing.Size(284, 925);
            this.GameOption.TabIndex = 3;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RestoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RestoreButton.Location = new System.Drawing.Point(50, 782);
            this.RestoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(189, 74);
            this.RestoreButton.TabIndex = 5;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveButton.Location = new System.Drawing.Point(50, 643);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(189, 74);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save Game";
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // HintButton
            // 
            this.HintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.HintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HintButton.Location = new System.Drawing.Point(50, 504);
            this.HintButton.Margin = new System.Windows.Forms.Padding(2);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(189, 74);
            this.HintButton.TabIndex = 3;
            this.HintButton.Text = "Hint";
            this.HintButton.UseVisualStyleBackColor = false;
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.UndoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UndoButton.Location = new System.Drawing.Point(50, 85);
            this.UndoButton.Margin = new System.Windows.Forms.Padding(2);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(189, 74);
            this.UndoButton.TabIndex = 0;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = false;
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PauseButton.Location = new System.Drawing.Point(50, 360);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(189, 74);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = false;
            // 
            // RedoButton
            // 
            this.RedoButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RedoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedoButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RedoButton.Location = new System.Drawing.Point(50, 226);
            this.RedoButton.Margin = new System.Windows.Forms.Padding(2);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(189, 74);
            this.RedoButton.TabIndex = 1;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1330, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Timer:";
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(1425, 76);
            this.TimeBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(255, 29);
            this.TimeBox.TabIndex = 5;
            // 
            // testbox
            // 
            this.testbox.Location = new System.Drawing.Point(2, 56);
            this.testbox.Margin = new System.Windows.Forms.Padding(2);
            this.testbox.Multiline = true;
            this.testbox.Name = "testbox";
            this.testbox.Size = new System.Drawing.Size(300, 160);
            this.testbox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1727, 544);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 80);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GameInfo
            // 
            this.GameInfo.Controls.Add(this.testbox);
            this.GameInfo.Location = new System.Drawing.Point(1335, 168);
            this.GameInfo.Name = "GameInfo";
            this.GameInfo.Size = new System.Drawing.Size(304, 679);
            this.GameInfo.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1994, 1121);
            this.Controls.Add(this.GameInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameOption);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GameOption.ResumeLayout(false);
            this.GameInfo.ResumeLayout(false);
            this.GameInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Panel GameBoard;
        private System.Windows.Forms.Panel GameOption;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button HintButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Timer Mytime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.TextBox testbox;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xSudokuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel GameInfo;
    }
}

