namespace RubiksCubeSolver.Timer.Forms
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
            previousSolveHeaderLabel = new System.Windows.Forms.Label();
            previousTimeLabel = new System.Windows.Forms.Label();
            scrambleHeaderLabel = new System.Windows.Forms.Label();
            scrambleLabel = new System.Windows.Forms.Label();
            startLabel = new System.Windows.Forms.Label();
            menuButton = new RubiksCubeSolver.Forms.MenuButton();
            SuspendLayout();
            // 
            // previousSolveHeaderLabel
            // 
            previousSolveHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            previousSolveHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            previousSolveHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            previousSolveHeaderLabel.Location = new System.Drawing.Point(370, 44);
            previousSolveHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            previousSolveHeaderLabel.MaximumSize = new System.Drawing.Size(718, 91);
            previousSolveHeaderLabel.MinimumSize = new System.Drawing.Size(718, 91);
            previousSolveHeaderLabel.Name = "previousSolveHeaderLabel";
            previousSolveHeaderLabel.Size = new System.Drawing.Size(718, 91);
            previousSolveHeaderLabel.TabIndex = 0;
            previousSolveHeaderLabel.Text = "Previous Solve:";
            previousSolveHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousTimeLabel
            // 
            previousTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            previousTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            previousTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F);
            previousTimeLabel.Location = new System.Drawing.Point(370, 135);
            previousTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            previousTimeLabel.MaximumSize = new System.Drawing.Size(718, 170);
            previousTimeLabel.MinimumSize = new System.Drawing.Size(718, 170);
            previousTimeLabel.Name = "previousTimeLabel";
            previousTimeLabel.Size = new System.Drawing.Size(718, 170);
            previousTimeLabel.TabIndex = 1;
            previousTimeLabel.Text = "00:00.00";
            previousTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrambleHeaderLabel
            // 
            scrambleHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            scrambleHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            scrambleHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            scrambleHeaderLabel.Location = new System.Drawing.Point(370, 340);
            scrambleHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            scrambleHeaderLabel.Name = "scrambleHeaderLabel";
            scrambleHeaderLabel.Size = new System.Drawing.Size(718, 91);
            scrambleHeaderLabel.TabIndex = 8;
            scrambleHeaderLabel.Text = "Scramble:";
            scrambleHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrambleLabel
            // 
            scrambleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            scrambleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            scrambleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            scrambleLabel.Location = new System.Drawing.Point(370, 431);
            scrambleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            scrambleLabel.Name = "scrambleLabel";
            scrambleLabel.Size = new System.Drawing.Size(718, 321);
            scrambleLabel.TabIndex = 6;
            scrambleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel
            // 
            startLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            startLabel.BackColor = System.Drawing.Color.Transparent;
            startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            startLabel.ForeColor = System.Drawing.Color.Black;
            startLabel.Location = new System.Drawing.Point(329, 752);
            startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            startLabel.Name = "startLabel";
            startLabel.Size = new System.Drawing.Size(794, 99);
            startLabel.TabIndex = 9;
            startLabel.Text = "Click Space To Start Timer";
            startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            menuButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            menuButton.BackColor = System.Drawing.Color.LightCyan;
            menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            menuButton.Location = new System.Drawing.Point(34, 44);
            menuButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            menuButton.Name = "menuButton";
            menuButton.Size = new System.Drawing.Size(264, 91);
            menuButton.TabIndex = 27;
            menuButton.TabStop = false;
            menuButton.Text = "Menu";
            menuButton.UseVisualStyleBackColor = false;
            // 
            // BeforeSolve
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(menuButton);
            Controls.Add(startLabel);
            Controls.Add(scrambleHeaderLabel);
            Controls.Add(scrambleLabel);
            Controls.Add(previousTimeLabel);
            Controls.Add(previousSolveHeaderLabel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1468, 869);
            Name = "BeforeSolve";
            Text = "Before Solve";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += BeforeSolve_Load;
            KeyDown += BeforeSolve_KeyDown;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label previousSolveHeaderLabel;
        private System.Windows.Forms.Label previousTimeLabel;
        private System.Windows.Forms.Label scrambleHeaderLabel;
        private System.Windows.Forms.Label scrambleLabel;
        private System.Windows.Forms.Label startLabel;
        private RubiksCubeSolver.Forms.MenuButton menuButton;
    }
}