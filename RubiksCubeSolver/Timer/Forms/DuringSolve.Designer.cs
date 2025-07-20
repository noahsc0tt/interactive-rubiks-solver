namespace RubiksCubeSolver.Timer.Forms
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
            stopLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // stopLabel
            // 
            stopLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            stopLabel.BackColor = System.Drawing.Color.Transparent;
            stopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            stopLabel.ForeColor = System.Drawing.Color.Black;
            stopLabel.Location = new System.Drawing.Point(290, 656);
            stopLabel.Name = "stopLabel";
            stopLabel.Size = new System.Drawing.Size(700, 229);
            stopLabel.TabIndex = 11;
            stopLabel.Text = "Click Space To Stop Timer";
            stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F);
            timeLabel.Location = new System.Drawing.Point(149, 133);
            timeLabel.MinimumSize = new System.Drawing.Size(984, 464);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(984, 464);
            timeLabel.TabIndex = 10;
            timeLabel.Text = "00:00.00";
            timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            // 
            // DuringSolve
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(23F, 46F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1284, 900);
            Controls.Add(stopLabel);
            Controls.Add(timeLabel);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            MinimumSize = new System.Drawing.Size(1278, 869);
            Name = "DuringSolve";
            Text = "During Solve";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += DuringSolve_Load;
            KeyPress += DuringSolve_KeyPress;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer;
    }
}