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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xSudokuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameBoard = new System.Windows.Forms.Panel();
            this.GameOption = new System.Windows.Forms.Panel();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.HintButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.GameOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.difficToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2019, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(171, 41);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // difficToolStripMenuItem
            // 
            this.difficToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.difficToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem1,
            this.hardToolStripMenuItem1,
            this.xSudokuToolStripMenuItem1});
            this.difficToolStripMenuItem.Name = "difficToolStripMenuItem";
            this.difficToolStripMenuItem.Size = new System.Drawing.Size(146, 41);
            this.difficToolStripMenuItem.Text = "Difficulty";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(315, 46);
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.EasyToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem1
            // 
            this.mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            this.mediumToolStripMenuItem1.Size = new System.Drawing.Size(315, 46);
            this.mediumToolStripMenuItem1.Text = "Medium";
            this.mediumToolStripMenuItem1.Click += new System.EventHandler(this.MediumToolStripMenuItem1_Click);
            // 
            // hardToolStripMenuItem1
            // 
            this.hardToolStripMenuItem1.Name = "hardToolStripMenuItem1";
            this.hardToolStripMenuItem1.Size = new System.Drawing.Size(315, 46);
            this.hardToolStripMenuItem1.Text = "Hard";
            // 
            // xSudokuToolStripMenuItem1
            // 
            this.xSudokuToolStripMenuItem1.Name = "xSudokuToolStripMenuItem1";
            this.xSudokuToolStripMenuItem1.Size = new System.Drawing.Size(315, 46);
            this.xSudokuToolStripMenuItem1.Text = "X Sudoku";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(78, 41);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // GameBoard
            // 
            this.GameBoard.AutoSize = true;
            this.GameBoard.Location = new System.Drawing.Point(82, 75);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(1464, 950);
            this.GameBoard.TabIndex = 1;
            // 
            // GameOption
            // 
            this.GameOption.AutoSize = true;
            this.GameOption.BackColor = System.Drawing.SystemColors.Info;
            this.GameOption.Controls.Add(this.RestoreButton);
            this.GameOption.Controls.Add(this.SaveButton);
            this.GameOption.Controls.Add(this.HintButton);
            this.GameOption.Controls.Add(this.PauseButton);
            this.GameOption.Controls.Add(this.RedoButton);
            this.GameOption.Controls.Add(this.UndoButton);
            this.GameOption.Location = new System.Drawing.Point(1615, 75);
            this.GameOption.Name = "GameOption";
            this.GameOption.Size = new System.Drawing.Size(392, 823);
            this.GameOption.TabIndex = 3;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RestoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RestoreButton.Location = new System.Drawing.Point(50, 602);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(306, 75);
            this.RestoreButton.TabIndex = 5;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveButton.Location = new System.Drawing.Point(50, 488);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(306, 75);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save Game";
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // HintButton
            // 
            this.HintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.HintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HintButton.Location = new System.Drawing.Point(50, 384);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(306, 75);
            this.HintButton.TabIndex = 3;
            this.HintButton.Text = "Hint";
            this.HintButton.UseVisualStyleBackColor = false;
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PauseButton.Location = new System.Drawing.Point(50, 279);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(306, 75);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = false;
            // 
            // RedoButton
            // 
            this.RedoButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RedoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedoButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RedoButton.Location = new System.Drawing.Point(50, 171);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(306, 75);
            this.RedoButton.TabIndex = 1;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = false;
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.UndoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UndoButton.Location = new System.Drawing.Point(50, 67);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(306, 75);
            this.UndoButton.TabIndex = 0;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(2019, 1190);
            this.Controls.Add(this.GameOption);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GameOption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xSudokuToolStripMenuItem1;
        private System.Windows.Forms.Panel GameBoard;
        private System.Windows.Forms.Panel GameOption;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button HintButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button RedoButton;
    }
}

