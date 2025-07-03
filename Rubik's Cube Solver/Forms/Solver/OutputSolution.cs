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
            piece = RotatePiece(piece, stage);
            SetLabelText();
        }

        private static PieceConfig RotatePiece(PieceConfig piece, Stage stage)
        {
            // calling the 'rotatePieceLocation' method the correct number of times 
            for (int i = 0; i < stage.SubStep-1; i++)
                piece = PieceRotator.AntiClockwise(piece);
            return piece;
        }

        private void SetLabelText()
        {
            lblCubeOrientation.Text = $"Hold your cube with the white centre piece on top and the {GetFrontFaceName(stage)} centre piece facing you.";
            lblStageName.Text = stage.GetName();

            PieceSolution solution = GetSolution(stage, piece);
            lblSequence.Text = solution.Sequence;
            lblExplanation.Text = solution.Explanation;
        }

        private PieceSolution GetSolution(Stage stage, PieceConfig piece)
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

        private string GetFrontFaceName(Stage stage) => stage.SubStep switch
        {
            0 => "green",
            1 => "orange",
            2 => "blue",
            3 => "red"
        };

        private void btnFinish_Click(object sender, EventArgs e)
        {
            stage.Increment();
            FormNavigator.Navigate<InputColours>(this, stage);
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);
    }
}
