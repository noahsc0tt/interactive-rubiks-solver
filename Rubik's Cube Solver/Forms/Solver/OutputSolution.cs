using System;
using System.Windows.Forms;


namespace Rubiks_Cube_Solver
{
    internal partial class OutputSolution : Form
    {
        private readonly Stage stage;
        private PieceConfig piece;

        public OutputSolution(Stage currentStage, CubeNetCellLocation cell)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            piece = CellToPieceConfig.GetPieceConfig(cell);
        }

        private void OutputSolution_Load(object sender, EventArgs e)
        {
            // calling the 'rotatePieceLocation' procedure the correct number of times 
            for (int i = 0; i < stage.SubStep-1; i++)
                piece = RotatePiece.AntiClockwise(piece);

            lblCubeOrientation.Text = $"Hold your cube with the white centre piece on top and the {GetFrontFaceName()} centre piece facing you.";
            lblNameOfStage.Text = stage.GetName();

            PieceSolution solution = GetSolution();
            lblSequence.Text = solution.Sequence;
            lblExplanation.Text = solution.Explanation;
        }

        private PieceSolution GetSolution()
        {
            try { return SolvePiece.GetSolution(stage, piece); }
            catch // if there is no match for the piece that the user inputted
            {
                // opening the 'Input Colours' form so the user can re-enter their input
                FormNavigator.Navigate<InputColours>(this, stage);
                MessageBox.Show("Invalid piece position. Enter the position of your piece correctly.");
                return null;
            }
        }

        private string GetFrontFaceName() => stage.SubStep switch
        {
            0 => "green",
            1 => "orange",
            2 => "blue",
            3 => "red"
        };

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<CheckingMoves>(this);

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);
    }
}
