namespace Rubiks_Cube_Solver
{
    partial class During_Solve
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
            this.lblStop = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblStop
            // 
            this.lblStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStop.BackColor = System.Drawing.Color.Transparent;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.ForeColor = System.Drawing.Color.Black;
            this.lblStop.Location = new System.Drawing.Point(420, 655);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(700, 229);
            this.lblStop.TabIndex = 11;
            this.lblStop.Text = "Click Space To Stop Timer";
            this.lblStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F);
            this.lblTimer.Location = new System.Drawing.Point(279, 132);
            this.lblTimer.MinimumSize = new System.Drawing.Size(984, 464);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(984, 464);
            this.lblTimer.TabIndex = 10;
            this.lblTimer.Text = "00:00.59";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.solveTimer_Tick);
            // 
            // During_Solve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 1005);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblTimer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.MinimumSize = new System.Drawing.Size(1278, 974);
            this.Name = "During_Solve";
            this.Text = "During_Solve";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.During_Solve_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.During_Solve_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer;
    }
}