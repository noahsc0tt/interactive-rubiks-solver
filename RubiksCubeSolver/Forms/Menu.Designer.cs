namespace RubiksCubeSolver.Forms
{
    partial class Menu
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
            solverButton = new System.Windows.Forms.Button();
            timerButton = new System.Windows.Forms.Button();
            notationButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // solverButton
            // 
            solverButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            solverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            solverButton.ForeColor = System.Drawing.SystemColors.ControlText;
            solverButton.Location = new System.Drawing.Point(49, 48);
            solverButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            solverButton.Name = "solverButton";
            solverButton.Size = new System.Drawing.Size(1372, 331);
            solverButton.TabIndex = 0;
            solverButton.TabStop = false;
            solverButton.Text = "Rubik's Cube Solver";
            solverButton.UseVisualStyleBackColor = true;
            solverButton.Click += SolverButton_Click;
            // 
            // timerButton
            // 
            timerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            timerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            timerButton.Location = new System.Drawing.Point(49, 455);
            timerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            timerButton.Name = "timerButton";
            timerButton.Size = new System.Drawing.Size(624, 331);
            timerButton.TabIndex = 1;
            timerButton.TabStop = false;
            timerButton.Text = "Timer";
            timerButton.UseVisualStyleBackColor = true;
            timerButton.Click += TimerButton_Click;
            // 
            // notationButton
            // 
            notationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            notationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            notationButton.Location = new System.Drawing.Point(796, 455);
            notationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            notationButton.Name = "notationButton";
            notationButton.Size = new System.Drawing.Size(624, 331);
            notationButton.TabIndex = 2;
            notationButton.TabStop = false;
            notationButton.Text = "Notation Explanation";
            notationButton.UseVisualStyleBackColor = true;
            notationButton.Click += NotationButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(notationButton);
            Controls.Add(timerButton);
            Controls.Add(solverButton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Menu";
            Text = "Menu";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button solverButton;
        private System.Windows.Forms.Button timerButton;
        private System.Windows.Forms.Button notationButton;
    }
}

