using System;
using System.Windows.Forms;
using RubiksCubeSolver.Forms.Util;

namespace RubiksCubeSolver.Solver.Forms
{
    using Util;
    using Face = DataGridView;
    /// <summary>
    /// Form for user input of a Rubik's Cube piece's position.
    /// </summary>
    internal partial class InputPiece : Form
    {
        private readonly Stage stage;
        private CubeNetCellLocation selectedCellLocation;
        private DataGridViewCell selectedCell;

        public InputPiece(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }

        private void InputPiece_Load(object sender, EventArgs e)
        {
            new CubeNetColourer(new CubeNetFaces
            (
                whiteFace, yellowFace, greenFace, blueFace, redFace, orangeFace
            )).PopulateCubeNet();
            instructionsLabel.Text = StageInfo.GetInstructions(stage);
            finishButton.Visible = false;
        }

        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Face face = (Face)sender;
            face.ClearSelection(); // un-highlighting the cell button

            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);
            
            if (cellCoords == CubeNetFaces.CentrePieceCellCoords)
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedCell?.Style.BackColor = FaceColourExtension.DefaultCellColour; // un-colouring the previous cell
                //colouring the new cell
                selectedCellLocation = new CubeNetCellLocation(FaceColourExtension.FromFaceName(face.Name), cellCoords);
                selectedCell = face[cellCoords.col, cellCoords.row];
                selectedCell.Style.BackColor = StageInfo.GetInputColour(stage).ToColor();
                finishButton.Visible = true;
            }
        }

        private void FinishButton_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<OutputSolution>(this, stage, selectedCellLocation);
    }
}