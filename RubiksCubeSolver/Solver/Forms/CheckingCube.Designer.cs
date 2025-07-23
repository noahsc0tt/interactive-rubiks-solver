namespace RubiksCubeSolver.Solver.Forms
{
    partial class CheckingCube
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            nextStageButton = new System.Windows.Forms.Button();
            chooseStageComboBox = new System.Windows.Forms.ComboBox();
            cubeLayoutLabel = new System.Windows.Forms.Label();
            whiteFace = new System.Windows.Forms.DataGridView();
            greenFace = new System.Windows.Forms.DataGridView();
            orangeFace = new System.Windows.Forms.DataGridView();
            yellowFace = new System.Windows.Forms.DataGridView();
            redFace = new System.Windows.Forms.DataGridView();
            blueFace = new System.Windows.Forms.DataGridView();
            instructionsLabel = new System.Windows.Forms.Label();
            menuButton = new RubiksCubeSolver.Forms.MenuButton();
            ((System.ComponentModel.ISupportInitialize)whiteFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)greenFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orangeFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yellowFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)redFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blueFace).BeginInit();
            SuspendLayout();
            // 
            // nextStageButton
            // 
            nextStageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            nextStageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            nextStageButton.Location = new System.Drawing.Point(896, 607);
            nextStageButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nextStageButton.MaximumSize = new System.Drawing.Size(321, 120);
            nextStageButton.MinimumSize = new System.Drawing.Size(321, 120);
            nextStageButton.Name = "nextStageButton";
            nextStageButton.Size = new System.Drawing.Size(321, 120);
            nextStageButton.TabIndex = 0;
            nextStageButton.TabStop = false;
            nextStageButton.Text = "Next Stage";
            nextStageButton.UseVisualStyleBackColor = true;
            nextStageButton.Click += NextStageButton_Click;
            // 
            // chooseStageComboBox
            // 
            chooseStageComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            chooseStageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            chooseStageComboBox.FormattingEnabled = true;
            chooseStageComboBox.Items.AddRange(new object[] { "Yellow Edges", "Yellow Corners", "Middle Layer Edges", "White Edges", "White Corners", "Corner Permutation", "Edge Permutation" });
            chooseStageComboBox.Location = new System.Drawing.Point(896, 733);
            chooseStageComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chooseStageComboBox.MaximumSize = new System.Drawing.Size(320, 0);
            chooseStageComboBox.MinimumSize = new System.Drawing.Size(320, 0);
            chooseStageComboBox.Name = "chooseStageComboBox";
            chooseStageComboBox.Size = new System.Drawing.Size(320, 39);
            chooseStageComboBox.TabIndex = 1;
            chooseStageComboBox.TabStop = false;
            chooseStageComboBox.Text = "     Choose Stage:";
            chooseStageComboBox.SelectionChangeCommitted += ChooseStageComboBox_SelectionChangeCommitted;
            // 
            // cubeLayoutLabel
            // 
            cubeLayoutLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            cubeLayoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            cubeLayoutLabel.Location = new System.Drawing.Point(59, 226);
            cubeLayoutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cubeLayoutLabel.Name = "cubeLayoutLabel";
            cubeLayoutLabel.Size = new System.Drawing.Size(264, 95);
            cubeLayoutLabel.TabIndex = 2;
            cubeLayoutLabel.Text = "Expected Cube Layout:";
            cubeLayoutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whiteFace
            // 
            whiteFace.AllowUserToAddRows = false;
            whiteFace.AllowUserToDeleteRows = false;
            whiteFace.AllowUserToResizeColumns = false;
            whiteFace.AllowUserToResizeRows = false;
            whiteFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            whiteFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            whiteFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            whiteFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            whiteFace.DefaultCellStyle = dataGridViewCellStyle2;
            whiteFace.Enabled = false;
            whiteFace.EnableHeadersVisualStyles = false;
            whiteFace.GridColor = System.Drawing.Color.Black;
            whiteFace.Location = new System.Drawing.Point(515, 91);
            whiteFace.Name = "whiteFace";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            whiteFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            whiteFace.RowHeadersVisible = false;
            whiteFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            whiteFace.RowTemplate.Height = 76;
            whiteFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            whiteFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            whiteFace.Size = new System.Drawing.Size(231, 231);
            whiteFace.TabIndex = 9;
            // 
            // greenFace
            // 
            greenFace.AllowUserToAddRows = false;
            greenFace.AllowUserToDeleteRows = false;
            greenFace.AllowUserToResizeColumns = false;
            greenFace.AllowUserToResizeRows = false;
            greenFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            greenFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            greenFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            greenFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            greenFace.DefaultCellStyle = dataGridViewCellStyle4;
            greenFace.Enabled = false;
            greenFace.EnableHeadersVisualStyles = false;
            greenFace.GridColor = System.Drawing.Color.Black;
            greenFace.Location = new System.Drawing.Point(515, 327);
            greenFace.Name = "greenFace";
            greenFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            greenFace.RowHeadersVisible = false;
            greenFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            greenFace.RowTemplate.Height = 76;
            greenFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            greenFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            greenFace.Size = new System.Drawing.Size(231, 231);
            greenFace.TabIndex = 10;
            // 
            // orangeFace
            // 
            orangeFace.AllowUserToAddRows = false;
            orangeFace.AllowUserToDeleteRows = false;
            orangeFace.AllowUserToResizeColumns = false;
            orangeFace.AllowUserToResizeRows = false;
            orangeFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            orangeFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            orangeFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            orangeFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            orangeFace.DefaultCellStyle = dataGridViewCellStyle5;
            orangeFace.Enabled = false;
            orangeFace.EnableHeadersVisualStyles = false;
            orangeFace.GridColor = System.Drawing.Color.Black;
            orangeFace.Location = new System.Drawing.Point(279, 327);
            orangeFace.Name = "orangeFace";
            orangeFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            orangeFace.RowHeadersVisible = false;
            orangeFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            orangeFace.RowTemplate.Height = 76;
            orangeFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            orangeFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            orangeFace.Size = new System.Drawing.Size(231, 231);
            orangeFace.TabIndex = 11;
            // 
            // yellowFace
            // 
            yellowFace.AllowUserToAddRows = false;
            yellowFace.AllowUserToDeleteRows = false;
            yellowFace.AllowUserToResizeColumns = false;
            yellowFace.AllowUserToResizeRows = false;
            yellowFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            yellowFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            yellowFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            yellowFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            yellowFace.DefaultCellStyle = dataGridViewCellStyle6;
            yellowFace.Enabled = false;
            yellowFace.EnableHeadersVisualStyles = false;
            yellowFace.GridColor = System.Drawing.Color.Black;
            yellowFace.Location = new System.Drawing.Point(515, 563);
            yellowFace.Name = "yellowFace";
            yellowFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            yellowFace.RowHeadersVisible = false;
            yellowFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            yellowFace.RowTemplate.Height = 76;
            yellowFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            yellowFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            yellowFace.Size = new System.Drawing.Size(231, 231);
            yellowFace.TabIndex = 12;
            // 
            // redFace
            // 
            redFace.AllowUserToAddRows = false;
            redFace.AllowUserToDeleteRows = false;
            redFace.AllowUserToResizeColumns = false;
            redFace.AllowUserToResizeRows = false;
            redFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            redFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            redFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            redFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            redFace.DefaultCellStyle = dataGridViewCellStyle7;
            redFace.Enabled = false;
            redFace.EnableHeadersVisualStyles = false;
            redFace.GridColor = System.Drawing.Color.Black;
            redFace.Location = new System.Drawing.Point(751, 327);
            redFace.Name = "redFace";
            redFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            redFace.RowHeadersVisible = false;
            redFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            redFace.RowTemplate.Height = 76;
            redFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            redFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            redFace.Size = new System.Drawing.Size(231, 231);
            redFace.TabIndex = 13;
            // 
            // blueFace
            // 
            blueFace.AllowUserToAddRows = false;
            blueFace.AllowUserToDeleteRows = false;
            blueFace.AllowUserToResizeColumns = false;
            blueFace.AllowUserToResizeRows = false;
            blueFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            blueFace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            blueFace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            blueFace.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            blueFace.DefaultCellStyle = dataGridViewCellStyle8;
            blueFace.Enabled = false;
            blueFace.EnableHeadersVisualStyles = false;
            blueFace.GridColor = System.Drawing.Color.Black;
            blueFace.Location = new System.Drawing.Point(987, 327);
            blueFace.Name = "blueFace";
            blueFace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            blueFace.RowHeadersVisible = false;
            blueFace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            blueFace.RowTemplate.Height = 76;
            blueFace.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            blueFace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            blueFace.Size = new System.Drawing.Size(231, 231);
            blueFace.TabIndex = 16;
            // 
            // instructionsLabel
            // 
            instructionsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            instructionsLabel.Location = new System.Drawing.Point(816, 91);
            instructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            instructionsLabel.Name = "instructionsLabel";
            instructionsLabel.Size = new System.Drawing.Size(602, 207);
            instructionsLabel.TabIndex = 17;
            instructionsLabel.Text = "If your cube matches this net, click 'Next Stage'.\r\n\r\nIf not, choose a stage to go back to using the drop-down list.\r\n";
            instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuButton
            // 
            menuButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            menuButton.BackColor = System.Drawing.Color.LightCyan;
            menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            menuButton.Location = new System.Drawing.Point(59, 91);
            menuButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            menuButton.Name = "menuButton";
            menuButton.Size = new System.Drawing.Size(264, 99);
            menuButton.TabIndex = 27;
            menuButton.TabStop = false;
            menuButton.Text = "Menu";
            menuButton.UseVisualStyleBackColor = false;
            // 
            // CheckingCube
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(menuButton);
            Controls.Add(instructionsLabel);
            Controls.Add(blueFace);
            Controls.Add(redFace);
            Controls.Add(yellowFace);
            Controls.Add(orangeFace);
            Controls.Add(greenFace);
            Controls.Add(whiteFace);
            Controls.Add(cubeLayoutLabel);
            Controls.Add(chooseStageComboBox);
            Controls.Add(nextStageButton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1468, 869);
            Name = "CheckingCube";
            Text = "Checking Cube";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += CheckingCube_Load;
            ((System.ComponentModel.ISupportInitialize)whiteFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)greenFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)orangeFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)yellowFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)redFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)blueFace).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nextStageButton;
        private System.Windows.Forms.ComboBox chooseStageComboBox;
        private System.Windows.Forms.Label cubeLayoutLabel;
        private System.Windows.Forms.DataGridView whiteFace;
        private System.Windows.Forms.DataGridView greenFace;
        private System.Windows.Forms.DataGridView orangeFace;
        private System.Windows.Forms.DataGridView yellowFace;
        private System.Windows.Forms.DataGridView redFace;
        private System.Windows.Forms.DataGridView blueFace;
        private System.Windows.Forms.Label instructionsLabel;
        private RubiksCubeSolver.Forms.MenuButton menuButton;
    }
}