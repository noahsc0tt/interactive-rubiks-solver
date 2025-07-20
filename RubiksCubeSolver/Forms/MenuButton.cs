using RubiksCubeSolver.Forms.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms
{
    internal class MenuButton : Button
    {
        private readonly Form form;
        public MenuButton(Form form)
        {
            this.form = form;
            BackColor = System.Drawing.Color.LightCyan;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "menuButton";
            TabStop = false;
            Text = "Menu";
            UseVisualStyleBackColor = false;
            Click += MenuButton_Click;
        }

        private void MenuButton_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(form);

    }
}
