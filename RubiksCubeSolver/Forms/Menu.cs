using System;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms
{
    using Util;

    /// <summary>
    /// Singleton menu form for navigation.
    /// </summary>
    internal partial class Menu : Form
    {
        private static Menu _instance;
        public static Menu Instance => _instance ??= new();

        public Menu()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }

        private void SolverButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Solver.Forms.InputPiece>(this, Solver.Stage.MinStage);
        
        private void TimerButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Timer.Forms.BeforeSolve>(this, "N/A");

        private void NotationButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<NotationExplanation>(this);
    }
}