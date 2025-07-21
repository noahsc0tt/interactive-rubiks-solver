using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
{
    using Util;

    /// <summary>
    /// Form for displaying the solution sequence and explanation for a specific Rubik's Cube piece.
    /// </summary>
    internal partial class OutputSolution : Form
    {
        private readonly Stage stage;
        private readonly PieceLocation piece;
        private readonly PieceSolution? solution;

        public OutputSolution(Stage currentStage, CubeNetCellLocation cell)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            piece = PieceRotator.RotatePiece(CellToPieceLocation.GetPieceConfig(cell), stage);
            solution = GetSolution(stage, piece);
            if (solution is not null) SetLabelText();
        }

        private void SetLabelText()
        {
            cubeOrientationLabel.Text = $"Hold your cube with the white centre piece on top and the {StageInfo.GetFrontFaceName(stage)} centre piece facing you.";
            stageNameLabel.Text = StageInfo.GetName(stage);
            sequenceLabel.Text = solution?.Sequence;
            explanationLabel.Text = solution?.Explanation;
        }

        private PieceSolution? GetSolution(Stage stage, PieceLocation piece)
        {
            try { return SolvePiece.GetSolution(stage, piece); }
            catch (ArgumentException) // if there is no match for the piece that the user inputted
            {
                // opening the 'Input Colours' form so the user can re-enter their input
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");
                FormNavigator.Navigate<InputPiece>(this, stage);
                return null;
            }
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, stage);
    }
}
