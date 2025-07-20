namespace Rubiks_Cube_Solver.Solver.Forms
{
    partial class OutputSolution
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
            cubeOrientationLabel = new System.Windows.Forms.Label();
            sequenceLabel = new System.Windows.Forms.Label();
            finishButton = new System.Windows.Forms.Button();
            stageNameLabel = new System.Windows.Forms.Label();
            explanationLabel = new System.Windows.Forms.Label();
            sequenceHeaderLabel = new System.Windows.Forms.Label();
            explanationHeaderLabel = new System.Windows.Forms.Label();
            menuButton = new Rubiks_Cube_Solver.Forms.MenuButton(this);
            SuspendLayout();
            // 
            // cubeOrientationLabel
            // 
            cubeOrientationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            cubeOrientationLabel.BackColor = System.Drawing.Color.Thistle;
            cubeOrientationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cubeOrientationLabel.Location = new System.Drawing.Point(67, 18);
            cubeOrientationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cubeOrientationLabel.Name = "cubeOrientationLabel";
            cubeOrientationLabel.Size = new System.Drawing.Size(563, 196);
            cubeOrientationLabel.TabIndex = 0;
            cubeOrientationLabel.Text = "Hold your cube with the white face on top and the green face facing you.";
            cubeOrientationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sequenceLabel
            // 
            sequenceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            sequenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sequenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            sequenceLabel.Location = new System.Drawing.Point(67, 375);
            sequenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            sequenceLabel.Name = "sequenceLabel";
            sequenceLabel.Size = new System.Drawing.Size(562, 421);
            sequenceLabel.TabIndex = 1;
            sequenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finishButton
            // 
            finishButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            finishButton.Location = new System.Drawing.Point(1122, 744);
            finishButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            finishButton.Name = "finishButton";
            finishButton.Size = new System.Drawing.Size(156, 52);
            finishButton.TabIndex = 2;
            finishButton.TabStop = false;
            finishButton.Text = "Finish";
            finishButton.UseVisualStyleBackColor = true;
            finishButton.Click += FinishButton_Click;
            // 
            // stageNameLabel
            // 
            stageNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            stageNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stageNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            stageNameLabel.Location = new System.Drawing.Point(695, 18);
            stageNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            stageNameLabel.Name = "stageNameLabel";
            stageNameLabel.Size = new System.Drawing.Size(583, 196);
            stageNameLabel.TabIndex = 3;
            stageNameLabel.Text = "Stage:";
            stageNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explanationLabel
            // 
            explanationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            explanationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            explanationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            explanationLabel.Location = new System.Drawing.Point(695, 351);
            explanationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            explanationLabel.MaximumSize = new System.Drawing.Size(687, 645);
            explanationLabel.Name = "explanationLabel";
            explanationLabel.Size = new System.Drawing.Size(583, 390);
            explanationLabel.TabIndex = 4;
            explanationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sequenceHeaderLabel
            // 
            sequenceHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            sequenceHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sequenceHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            sequenceHeaderLabel.Location = new System.Drawing.Point(67, 304);
            sequenceHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            sequenceHeaderLabel.MaximumSize = new System.Drawing.Size(697, 112);
            sequenceHeaderLabel.Name = "sequenceHeaderLabel";
            sequenceHeaderLabel.Size = new System.Drawing.Size(562, 71);
            sequenceHeaderLabel.TabIndex = 5;
            sequenceHeaderLabel.Text = "Sequence Of Moves:";
            sequenceHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explanationLabelHeader
            // 
            explanationHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            explanationHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            explanationHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            explanationHeaderLabel.Location = new System.Drawing.Point(695, 301);
            explanationHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            explanationHeaderLabel.MaximumSize = new System.Drawing.Size(264, 49);
            explanationHeaderLabel.Name = "explanationLabelHeader";
            explanationHeaderLabel.Size = new System.Drawing.Size(227, 49);
            explanationHeaderLabel.TabIndex = 6;
            explanationHeaderLabel.Text = "Explanation:";
            // 
            // menuButton
            // 
            menuButton.Location = new System.Drawing.Point(1760, 42);
            menuButton.Size = new System.Drawing.Size(264, 99);
            menuButton.TabIndex = 7;
            // 
            // OutputSolution
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1339, 859);
            Controls.Add(menuButton);
            Controls.Add(explanationHeaderLabel);
            Controls.Add(sequenceHeaderLabel);
            Controls.Add(explanationLabel);
            Controls.Add(stageNameLabel);
            Controls.Add(finishButton);
            Controls.Add(sequenceLabel);
            Controls.Add(cubeOrientationLabel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "OutputSolution";
            Text = "Output Solution";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label cubeOrientationLabel;
        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label stageNameLabel;
        private System.Windows.Forms.Label explanationLabel;
        private System.Windows.Forms.Label sequenceHeaderLabel;
        private System.Windows.Forms.Label explanationHeaderLabel;
        private System.Windows.Forms.Button menuButton;
    }
}