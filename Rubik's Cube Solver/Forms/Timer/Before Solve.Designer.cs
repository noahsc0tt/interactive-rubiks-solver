namespace Rubiks_Cube_Solver
{
    partial class Before_Solve
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
            this.lblPreviousSolve = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScrambleHeader = new System.Windows.Forms.Label();
            this.lblScramble = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPreviousSolve
            // 
            this.lblPreviousSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviousSolve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreviousSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.lblPreviousSolve.Location = new System.Drawing.Point(440, 69);
            this.lblPreviousSolve.MaximumSize = new System.Drawing.Size(616, 79);
            this.lblPreviousSolve.MinimumSize = new System.Drawing.Size(616, 79);
            this.lblPreviousSolve.Name = "lblPreviousSolve";
            this.lblPreviousSolve.Size = new System.Drawing.Size(616, 79);
            this.lblPreviousSolve.TabIndex = 0;
            this.lblPreviousSolve.Text = "Previous Solve:";
            this.lblPreviousSolve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F);
            this.lblTime.Location = new System.Drawing.Point(440, 148);
            this.lblTime.MaximumSize = new System.Drawing.Size(616, 148);
            this.lblTime.MinimumSize = new System.Drawing.Size(616, 148);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(616, 148);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "00:00.00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScrambleHeader
            // 
            this.lblScrambleHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScrambleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.lblScrambleHeader.Location = new System.Drawing.Point(440, 380);
            this.lblScrambleHeader.Name = "lblScrambleHeader";
            this.lblScrambleHeader.Size = new System.Drawing.Size(616, 97);
            this.lblScrambleHeader.TabIndex = 8;
            this.lblScrambleHeader.Text = "Scramble:";
            this.lblScrambleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScramble
            // 
            this.lblScramble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScramble.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.lblScramble.Location = new System.Drawing.Point(440, 477);
            this.lblScramble.Name = "lblScramble";
            this.lblScramble.Size = new System.Drawing.Size(616, 343);
            this.lblScramble.TabIndex = 6;
            this.lblScramble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart
            // 
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(590, 892);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(681, 86);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Click Space To Start Timer";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.LightCyan;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(99, 69);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(226, 86);
            this.btnMenu.TabIndex = 19;
            this.btnMenu.TabStop = false;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // Before_Solve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 900);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblScrambleHeader);
            this.Controls.Add(this.lblScramble);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPreviousSolve);
            this.MinimumSize = new System.Drawing.Size(1468, 869);
            this.Name = "Before_Solve";
            this.Text = "Before_Solve";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Before_Solve_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Before_Solve_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPreviousSolve;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScrambleHeader;
        private System.Windows.Forms.Label lblScramble;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnMenu;
    }
}