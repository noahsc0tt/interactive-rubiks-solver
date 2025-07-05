using System;
using System.Drawing;
using System.Windows.Forms;
using Rubiks_Cube_Solver.Forms.Util;

namespace Rubiks_Cube_Solver.Solver.Forms
{
    using Face = DataGridView;
    internal partial class InputPiece : Form
    {
        private static readonly (int, int) centrePieceCellCoords = (1, 1);
        private readonly Stage stage;
        private CubeNetCellLocation selectedCellLocation;
        private DataGridViewCell selectedCell;

        public InputPiece(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }

        private void InputColours_Load(object sender, EventArgs e)
        {
            PopulateCubeNet();
            lblInstructions.Text = GetInstructions();
            btnFinish.Visible = false;
        }

        private void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = 0; i < 3; i++)
                face.Rows.Add("", "", "");
            face[1, 1].Style.BackColor = FaceColourExtension.FromFaceName(face.Name).ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        private void PopulateCubeNet() =>
            Array.ForEach([whiteFace, yellowFace, greenFace, blueFace, redFace, orangeFace], PopulateCubeFace);

        private string GetInstructions() =>
            $"Input the position of the {stage.GetInputColour().ToString().ToLower()} square on the {stage.GetRequiredPiece()}";

        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Face face = (Face)sender;
            face.ClearSelection();

            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);
            
            if (cellCoords == centrePieceCellCoords) // if a centre piece is clicked
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedCell?.Style.BackColor = Color.Silver; // un-colouring the previous cell
                //colouring the new cell
                selectedCellLocation = new CubeNetCellLocation(cellCoords, FaceColourExtension.FromFaceName(face.Name));
                selectedCell = face[cellCoords.col, cellCoords.row];
                selectedCell.Style.BackColor = stage.GetInputColour().ToColor();
                btnFinish.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Menu(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<OutputSolution>(this, stage, selectedCellLocation);
    }
}