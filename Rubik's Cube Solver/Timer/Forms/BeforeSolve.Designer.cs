namespace Rubiks_Cube_Solver.Timer.Forms
{
    partial class BeforeSolve
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
            lblPreviousSolve = new System.Windows.Forms.Label();
            lblTime = new System.Windows.Forms.Label();
            lblScrambleHeader = new System.Windows.Forms.Label();
            lblScramble = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            btnMenu = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblPreviousSolve
            // 
            lblPreviousSolve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblPreviousSolve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblPreviousSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            lblPreviousSolve.Location = new System.Drawing.Point(370, 44);
            lblPreviousSolve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPreviousSolve.MaximumSize = new System.Drawing.Size(718, 91);
            lblPreviousSolve.MinimumSize = new System.Drawing.Size(718, 91);
            lblPreviousSolve.Name = "lblPreviousSolve";
            lblPreviousSolve.Size = new System.Drawing.Size(718, 91);
            lblPreviousSolve.TabIndex = 0;
            lblPreviousSolve.Text = "Previous Solve:";
            lblPreviousSolve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F);
            lblTime.Location = new System.Drawing.Point(370, 135);
            lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTime.MaximumSize = new System.Drawing.Size(718, 170);
            lblTime.MinimumSize = new System.Drawing.Size(718, 170);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(718, 170);
            lblTime.TabIndex = 1;
            lblTime.Text = "00:00.00";
            lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScrambleHeader
            // 
            lblScrambleHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblScrambleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            lblScrambleHeader.Location = new System.Drawing.Point(370, 340);
            lblScrambleHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblScrambleHeader.Name = "lblScrambleHeader";
            lblScrambleHeader.Size = new System.Drawing.Size(718, 91);
            lblScrambleHeader.TabIndex = 8;
            lblScrambleHeader.Text = "Scramble:";
            lblScrambleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScramble
            // 
            lblScramble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblScramble.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblScramble.Location = new System.Drawing.Point(370, 431);
            lblScramble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblScramble.Name = "lblScramble";
            lblScramble.Size = new System.Drawing.Size(718, 321);
            lblScramble.TabIndex = 6;
            lblScramble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart
            // 
            lblStart.BackColor = System.Drawing.Color.Transparent;
            lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblStart.ForeColor = System.Drawing.Color.Black;
            lblStart.Location = new System.Drawing.Point(329, 752);
            lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(794, 99);
            lblStart.TabIndex = 9;
            lblStart.Text = "Click Space To Start Timer";
            lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = System.Drawing.Color.LightCyan;
            btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnMenu.Location = new System.Drawing.Point(51, 44);
            btnMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new System.Drawing.Size(264, 99);
            btnMenu.TabIndex = 19;
            btnMenu.TabStop = false;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // BeforeSolve
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(btnMenu);
            Controls.Add(lblStart);
            Controls.Add(lblScrambleHeader);
            Controls.Add(lblScramble);
            Controls.Add(lblTime);
            Controls.Add(lblPreviousSolve);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1468, 869);
            Name = "BeforeSolve";
            Text = "Before_Solve";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += BeforeSolve_Load;
            KeyPress += BeforeSolve_KeyPress;
            ResumeLayout(false);

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