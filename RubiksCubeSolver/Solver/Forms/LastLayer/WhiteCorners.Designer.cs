namespace RubiksCubeSolver.Solver.Forms
{
    partial class WhiteCorners
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhiteCorners));
            finishButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            menuButton1 = new RubiksCubeSolver.Forms.MenuButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // finishButton
            // 
            finishButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            finishButton.Location = new System.Drawing.Point(1225, 739);
            finishButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            finishButton.MinimumSize = new System.Drawing.Size(133, 52);
            finishButton.Name = "finishButton";
            finishButton.Size = new System.Drawing.Size(188, 103);
            finishButton.TabIndex = 3;
            finishButton.TabStop = false;
            finishButton.Text = "Finish";
            finishButton.UseVisualStyleBackColor = true;
            finishButton.Click += FinishButton_Click;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(62, 119);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(1351, 106);
            label3.TabIndex = 15;
            label3.Text = "The aim of this stage is to have the whole white face completed. If this is already the case, click the 'Finish' button.\r\n\r\nRead this page carefully before making any moves on your cube.";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            titleLabel.Location = new System.Drawing.Point(342, -12);
            titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(790, 148);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "White Corners";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.completed_white_layer_corners;
            pictureBox2.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new System.Drawing.Point(867, 609);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(255, 233);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.oriented_corner;
            pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new System.Drawing.Point(342, 609);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(259, 233);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(62, 246);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(1351, 344);
            label4.TabIndex = 19;
            label4.Text = resources.GetString("label4.Text");
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuButton1
            // 
            menuButton1.BackColor = System.Drawing.Color.LightCyan;
            menuButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            menuButton1.Location = new System.Drawing.Point(62, 12);
            menuButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            menuButton1.Name = "menuButton1";
            menuButton1.Size = new System.Drawing.Size(264, 99);
            menuButton1.TabIndex = 20;
            menuButton1.TabStop = false;
            menuButton1.Text = "Menu";
            menuButton1.UseVisualStyleBackColor = false;
            // 
            // WhiteCorners
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 900);
            Controls.Add(menuButton1);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(titleLabel);
            Controls.Add(finishButton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "WhiteCorners";
            Text = "Top Layer Corners";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private RubiksCubeSolver.Forms.MenuButton menuButton1;
    }
}