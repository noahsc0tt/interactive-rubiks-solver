using System;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;
using Rubiks_Cube_Solver.Solver.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    using Face = DataGridView;
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
            new CubeNetColourer(new CubeNet
            (
                whiteFace, yellowFace, greenFace, blueFace, redFace, orangeFace
            )).PopulateCubeNet();
            lblInstructions.Text = StageInfo.GetInstructions(stage);
            btnFinish.Visible = false;
        }

        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Face face = (Face)sender;
            face.ClearSelection();

            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);
            
            if (cellCoords == CubeNet.CentrePieceCellCoords)
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedCell?.Style.BackColor = FaceColourExtension.DefaultCellColour; // un-colouring the previous cell
                //colouring the new cell
                selectedCellLocation = new CubeNetCellLocation(cellCoords, FaceColourExtension.FromFaceName(face.Name));
                selectedCell = face[cellCoords.col, cellCoords.row];
                selectedCell.Style.BackColor = StageInfo.GetInputColour(stage).ToColor();
                btnFinish.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<OutputSolution>(this, stage, selectedCellLocation);
    }
}