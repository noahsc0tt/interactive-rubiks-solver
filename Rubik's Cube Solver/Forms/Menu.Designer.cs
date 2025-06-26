namespace Rubiks_Cube_Solver
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
            this.btnSolver = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnNotation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSolver
            // 
            this.btnSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            this.btnSolver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSolver.Location = new System.Drawing.Point(71, 70);
            this.btnSolver.Name = "btnSolver";
            this.btnSolver.Size = new System.Drawing.Size(1329, 353);
            this.btnSolver.TabIndex = 0;
            this.btnSolver.TabStop = false;
            this.btnSolver.Text = "Rubik\'s Cube Solver";
            this.btnSolver.UseVisualStyleBackColor = true;
            this.btnSolver.Click += new System.EventHandler(this.btnSolver_Click);
            // 
            // btnTimer
            // 
            this.btnTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            this.btnTimer.Location = new System.Drawing.Point(71, 548);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(568, 250);
            this.btnTimer.TabIndex = 1;
            this.btnTimer.TabStop = false;
            this.btnTimer.Text = "Timer";
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // btnNotation
            // 
            this.btnNotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F);
            this.btnNotation.Location = new System.Drawing.Point(832, 548);
            this.btnNotation.Name = "btnNotation";
            this.btnNotation.Size = new System.Drawing.Size(568, 250);
            this.btnNotation.TabIndex = 2;
            this.btnNotation.TabStop = false;
            this.btnNotation.Text = "Notation Explanation";
            this.btnNotation.UseVisualStyleBackColor = true;
            this.btnNotation.Click += new System.EventHandler(this.btnNotation_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 900);
            this.Controls.Add(this.btnNotation);
            this.Controls.Add(this.btnTimer);
            this.Controls.Add(this.btnSolver);
            this.Name = "Menu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSolver;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnNotation;
    }
}

