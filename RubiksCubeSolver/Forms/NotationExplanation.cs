using System;
using System.Windows.Forms;

namespace RubiksCubeSolver.Forms
{
    using Util;

    /// <summary>
    /// Singleton form displaying explanations and visual aids for Rubik's Cube notation and terminology.
    /// </summary>
    internal partial class NotationExplanation : Form
    {
        private static NotationExplanation _instance;
        public static NotationExplanation Instance => _instance ??= new();

        private NotationExplanation()
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
        }
    }
}
