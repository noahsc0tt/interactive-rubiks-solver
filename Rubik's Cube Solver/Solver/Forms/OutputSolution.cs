using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;
using Rubiks_Cube_Solver.Solver.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    internal partial class OutputSolution : Form
    {
        private readonly Stage stage;
        private PieceConfig piece;
        private PieceSolution solution;

        public OutputSolution(Stage currentStage, CubeNetCellLocation cell)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            piece = CellToPieceConfig.GetPieceConfig(cell);
        }

        private void OutputSolution_Load(object sender, EventArgs e)
        {
            piece = PieceRotator.RotatePiece(piece, stage);
            solution = GetSolution(stage, piece);
            if (solution is not null) SetLabelText();
        }

        private void SetLabelText()
        {
            lblCubeOrientation.Text = $"Hold your cube with the white centre piece on top and the {GetFrontFaceName(stage)} centre piece facing you.";
            lblStageName.Text = StageInfo.GetName(stage);
            lblSequence.Text = solution.Sequence;
            lblExplanation.Text = solution.Explanation;
        }

        private PieceSolution GetSolution(Stage stage, PieceConfig piece)
        {
            try { return SolvePiece.GetSolution(stage, piece); }
            catch (ArgumentException) // if there is no match for the piece that the user inputted
            {
                // opening the 'Input Colours' form so the user can re-enter their input
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");
                BeginInvoke(() => FormNavigator.Navigate<InputPiece>(this, stage));
                return null;
            }
        }

        private string GetFrontFaceName(Stage stage) => stage.SubStep switch
        {
            0 => "green",
            1 => "orange",
            2 => "blue",
            3 => "red"
        };

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingCube>(this, stage);

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);
    }
}
