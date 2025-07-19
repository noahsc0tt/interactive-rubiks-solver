namespace Rubiks_Cube_Solver.Timer.Forms
{
    partial class DuringSolve
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
            components = new System.ComponentModel.Container();
            lblStop = new System.Windows.Forms.Label();
            lblTimer = new System.Windows.Forms.Label();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblStop
            // 
            lblStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblStop.BackColor = System.Drawing.Color.Transparent;
            lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblStop.ForeColor = System.Drawing.Color.Black;
            lblStop.Location = new System.Drawing.Point(290, 656);
            lblStop.Name = "lblStop";
            lblStop.Size = new System.Drawing.Size(700, 229);
            lblStop.TabIndex = 11;
            lblStop.Text = "Click Space To Stop Timer";
            lblStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            lblTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F);
            lblTimer.Location = new System.Drawing.Point(149, 133);
            lblTimer.MinimumSize = new System.Drawing.Size(984, 464);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new System.Drawing.Size(984, 464);
            lblTimer.TabIndex = 10;
            lblTimer.Text = "00:00.00";
            lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += solveTimer_Tick;
            // 
            // DuringSolve
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(23F, 46F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1284, 900);
            Controls.Add(lblStop);
            Controls.Add(lblTimer);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            MinimumSize = new System.Drawing.Size(1278, 869);
            Name = "DuringSolve";
            Text = "During_Solve";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += DuringSolve_Load;
            KeyPress += DuringSolve_KeyPress;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer;
    }
}