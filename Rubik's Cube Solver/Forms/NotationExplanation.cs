using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Forms
{
    public partial class NotationExplanation : Form
    {
        private static NotationExplanation _instance;
        public static NotationExplanation Instance => _instance ??= new();

        public NotationExplanation()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);
    }
}
