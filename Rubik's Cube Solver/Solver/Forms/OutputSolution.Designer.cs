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
            lblCubeOrientation = new System.Windows.Forms.Label();
            lblSequence = new System.Windows.Forms.Label();
            btnFinish = new System.Windows.Forms.Button();
            lblStageName = new System.Windows.Forms.Label();
            lblExplanation = new System.Windows.Forms.Label();
            lblSequenceHeader = new System.Windows.Forms.Label();
            lblExplanationHeader = new System.Windows.Forms.Label();
            btnMenu = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblCubeOrientation
            // 
            lblCubeOrientation.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblCubeOrientation.BackColor = System.Drawing.Color.Thistle;
            lblCubeOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCubeOrientation.Location = new System.Drawing.Point(67, 18);
            lblCubeOrientation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCubeOrientation.Name = "lblCubeOrientation";
            lblCubeOrientation.Size = new System.Drawing.Size(563, 196);
            lblCubeOrientation.TabIndex = 0;
            lblCubeOrientation.Text = "Hold your cube with the white face on top and the green face facing you.";
            lblCubeOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSequence
            // 
            lblSequence.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblSequence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            lblSequence.Location = new System.Drawing.Point(67, 375);
            lblSequence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSequence.Name = "lblSequence";
            lblSequence.Size = new System.Drawing.Size(562, 421);
            lblSequence.TabIndex = 1;
            lblSequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFinish
            // 
            btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            btnFinish.Location = new System.Drawing.Point(1122, 744);
            btnFinish.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new System.Drawing.Size(156, 52);
            btnFinish.TabIndex = 2;
            btnFinish.TabStop = false;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // lblStageName
            // 
            lblStageName.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblStageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblStageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            lblStageName.Location = new System.Drawing.Point(695, 18);
            lblStageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStageName.Name = "lblStageName";
            lblStageName.Size = new System.Drawing.Size(583, 196);
            lblStageName.TabIndex = 3;
            lblStageName.Text = "Stage:";
            lblStageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExplanation
            // 
            lblExplanation.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblExplanation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblExplanation.Location = new System.Drawing.Point(695, 351);
            lblExplanation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblExplanation.MaximumSize = new System.Drawing.Size(687, 645);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new System.Drawing.Size(583, 390);
            lblExplanation.TabIndex = 4;
            lblExplanation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSequenceHeader
            // 
            lblSequenceHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblSequenceHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblSequenceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            lblSequenceHeader.Location = new System.Drawing.Point(67, 304);
            lblSequenceHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSequenceHeader.MaximumSize = new System.Drawing.Size(697, 112);
            lblSequenceHeader.Name = "lblSequenceHeader";
            lblSequenceHeader.Size = new System.Drawing.Size(562, 71);
            lblSequenceHeader.TabIndex = 5;
            lblSequenceHeader.Text = "Sequence Of Moves:";
            lblSequenceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExplanationHeader
            // 
            lblExplanationHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblExplanationHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblExplanationHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblExplanationHeader.Location = new System.Drawing.Point(695, 301);
            lblExplanationHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblExplanationHeader.MaximumSize = new System.Drawing.Size(264, 49);
            lblExplanationHeader.Name = "lblExplanationHeader";
            lblExplanationHeader.Size = new System.Drawing.Size(227, 49);
            lblExplanationHeader.TabIndex = 6;
            lblExplanationHeader.Text = "Explanation:";
            // 
            // btnMenu
            // 
            btnMenu.BackColor = System.Drawing.Color.LightCyan;
            btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnMenu.Location = new System.Drawing.Point(1760, 42);
            btnMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new System.Drawing.Size(264, 99);
            btnMenu.TabIndex = 7;
            btnMenu.TabStop = false;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // OutputSolution
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1339, 859);
            Controls.Add(btnMenu);
            Controls.Add(lblExplanationHeader);
            Controls.Add(lblSequenceHeader);
            Controls.Add(lblExplanation);
            Controls.Add(lblStageName);
            Controls.Add(btnFinish);
            Controls.Add(lblSequence);
            Controls.Add(lblCubeOrientation);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "OutputSolution";
            Text = "Output_Solution";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCubeOrientation;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblStageName;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label lblSequenceHeader;
        private System.Windows.Forms.Label lblExplanationHeader;
        private System.Windows.Forms.Button btnMenu;
    }
}