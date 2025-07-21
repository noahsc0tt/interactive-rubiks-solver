using RubiksCubeSolver.Forms.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms
{
    /// <summary>
    /// Custom button for returning to the main menu from any form in the RubiksCubeSolver application.
    /// </summary>
    public class MenuButton : Button
    {
        public MenuButton()
        {
            BackColor = Color.LightCyan;
            Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "menuButton";
            TabStop = false;
            Text = "Menu";
            UseVisualStyleBackColor = false;
            Click += MenuButton_Click;
        }

        private void MenuButton_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(FindForm());
    }
}
