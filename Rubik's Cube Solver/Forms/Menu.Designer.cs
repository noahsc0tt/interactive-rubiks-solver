namespace Rubiks_Cube_Solver.Forms
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
            btnSolver = new System.Windows.Forms.Button();
            btnTimer = new System.Windows.Forms.Button();
            btnNotation = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnSolver
            // 
            btnSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            btnSolver.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSolver.Location = new System.Drawing.Point(49, 48);
            btnSolver.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSolver.Name = "btnSolver";
            btnSolver.Size = new System.Drawing.Size(1372, 331);
            btnSolver.TabIndex = 0;
            btnSolver.TabStop = false;
            btnSolver.Text = "Rubik's Cube Solver";
            btnSolver.UseVisualStyleBackColor = true;
            btnSolver.Click += btnSolver_Click;
            // 
            // btnTimer
            // 
            btnTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            btnTimer.Location = new System.Drawing.Point(49, 455);
            btnTimer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTimer.Name = "btnTimer";
            btnTimer.Size = new System.Drawing.Size(624, 331);
            btnTimer.TabIndex = 1;
            btnTimer.TabStop = false;
            btnTimer.Text = "Timer";
            btnTimer.UseVisualStyleBackColor = true;
            btnTimer.Click += btnTimer_Click;
            // 
            // btnNotation
            // 
            btnNotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            btnNotation.Location = new System.Drawing.Point(796, 455);
            btnNotation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNotation.Name = "btnNotation";
            btnNotation.Size = new System.Drawing.Size(624, 331);
            btnNotation.TabIndex = 2;
            btnNotation.TabStop = false;
            btnNotation.Text = "Notation Explanation";
            btnNotation.UseVisualStyleBackColor = true;
            btnNotation.Click += btnNotation_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(btnNotation);
            Controls.Add(btnTimer);
            Controls.Add(btnSolver);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Menu";
            Text = "Menu";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSolver;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnNotation;
    }
}

