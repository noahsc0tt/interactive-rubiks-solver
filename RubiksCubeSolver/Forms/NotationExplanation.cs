using System;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms
{
    using Util;

    internal partial class NotationExplanation : Form
    {
        private static NotationExplanation _instance;
        public static NotationExplanation Instance => _instance ??= new();

        public NotationExplanation()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void MenuButton_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);
    }
}
