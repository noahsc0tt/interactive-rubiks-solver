namespace Rubik_s_Cube_Solver
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
            this.btnPenalty = new System.Windows.Forms.Button();
            this.btnEditAll = new System.Windows.Forms.Button();
            this.btnEditSolve = new System.Windows.Forms.Button();
            this.btnDeleteSolve = new System.Windows.Forms.Button();
            this.lblAo5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblAo20 = new System.Windows.Forms.Label();
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
            this.lblPreviousSolve.Location = new System.Drawing.Point(613, 69);
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
            this.lblTime.Location = new System.Drawing.Point(613, 148);
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
            this.lblScrambleHeader.Location = new System.Drawing.Point(613, 379);
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
            this.lblScramble.Location = new System.Drawing.Point(613, 476);
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
            // btnPenalty
            // 
            this.btnPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.btnPenalty.Location = new System.Drawing.Point(1322, 69);
            this.btnPenalty.Name = "btnPenalty";
            this.btnPenalty.Size = new System.Drawing.Size(418, 203);
            this.btnPenalty.TabIndex = 10;
            this.btnPenalty.TabStop = false;
            this.btnPenalty.Text = "+2s Previous Solve\r\n(Penalty)";
            this.btnPenalty.UseVisualStyleBackColor = true;
            this.btnPenalty.Visible = false;
            // 
            // btnEditAll
            // 
            this.btnEditAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.btnEditAll.Location = new System.Drawing.Point(1322, 760);
            this.btnEditAll.Name = "btnEditAll";
            this.btnEditAll.Size = new System.Drawing.Size(418, 203);
            this.btnEditAll.TabIndex = 11;
            this.btnEditAll.TabStop = false;
            this.btnEditAll.Text = "Edit All Previous Solves";
            this.btnEditAll.UseVisualStyleBackColor = true;
            this.btnEditAll.Visible = false;
            // 
            // btnEditSolve
            // 
            this.btnEditSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.btnEditSolve.Location = new System.Drawing.Point(1322, 528);
            this.btnEditSolve.Name = "btnEditSolve";
            this.btnEditSolve.Size = new System.Drawing.Size(418, 203);
            this.btnEditSolve.TabIndex = 12;
            this.btnEditSolve.TabStop = false;
            this.btnEditSolve.Text = "Edit Previous Solve";
            this.btnEditSolve.UseVisualStyleBackColor = true;
            this.btnEditSolve.Visible = false;
            // 
            // btnDeleteSolve
            // 
            this.btnDeleteSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.btnDeleteSolve.Location = new System.Drawing.Point(1322, 296);
            this.btnDeleteSolve.Name = "btnDeleteSolve";
            this.btnDeleteSolve.Size = new System.Drawing.Size(418, 203);
            this.btnDeleteSolve.TabIndex = 13;
            this.btnDeleteSolve.TabStop = false;
            this.btnDeleteSolve.Text = "Delete Previous Solve";
            this.btnDeleteSolve.UseVisualStyleBackColor = true;
            this.btnDeleteSolve.Visible = false;
            // 
            // lblAo5
            // 
            this.lblAo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.lblAo5.Location = new System.Drawing.Point(99, 199);
            this.lblAo5.Name = "lblAo5";
            this.lblAo5.Size = new System.Drawing.Size(410, 141);
            this.lblAo5.TabIndex = 14;
            this.lblAo5.Text = "Av. Of Last 5: 00:00.00";
            this.lblAo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAo5.Visible = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.label1.Location = new System.Drawing.Point(99, 820);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 141);
            this.label1.TabIndex = 15;
            this.label1.Text = "Worst Time: 00:00.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // lblBest
            // 
            this.lblBest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.lblBest.Location = new System.Drawing.Point(99, 665);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(410, 141);
            this.lblBest.TabIndex = 16;
            this.lblBest.Text = "Best Time: 00:00.00";
            this.lblBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBest.Visible = false;
            // 
            // lblAverage
            // 
            this.lblAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.lblAverage.Location = new System.Drawing.Point(99, 509);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(410, 141);
            this.lblAverage.TabIndex = 17;
            this.lblAverage.Text = "Average Time: 00:00.00";
            this.lblAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAverage.Visible = false;
            // 
            // lblAo20
            // 
            this.lblAo20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAo20.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.lblAo20.Location = new System.Drawing.Point(99, 353);
            this.lblAo20.Name = "lblAo20";
            this.lblAo20.Size = new System.Drawing.Size(410, 141);
            this.lblAo20.TabIndex = 18;
            this.lblAo20.Text = "Av. Of Last 20: 00:00.00";
            this.lblAo20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAo20.Visible = false;
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
            this.Controls.Add(this.lblAo20);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblBest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAo5);
            this.Controls.Add(this.btnDeleteSolve);
            this.Controls.Add(this.btnEditSolve);
            this.Controls.Add(this.btnEditAll);
            this.Controls.Add(this.btnPenalty);
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
        private System.Windows.Forms.Button btnPenalty;
        private System.Windows.Forms.Button btnEditAll;
        private System.Windows.Forms.Button btnEditSolve;
        private System.Windows.Forms.Button btnDeleteSolve;
        private System.Windows.Forms.Label lblAo5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblAo20;
        private System.Windows.Forms.Button btnMenu;
    }
}