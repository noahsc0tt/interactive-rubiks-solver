using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    using Face = DataGridView;
    internal partial class InputColours : Form
    {
        private static readonly (int, int) centrePieceCellCoords = (1, 1);
        private readonly Stage stage;
        private CubeNetCellLocation selectedCellLocation;
        private DataGridViewCell selectedCell;
        private readonly ImmutableDictionary<Face, FaceColour> faceColourDict;

        public InputColours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
            faceColourDict = InitialiseFaceColourDict();
        }

        private ImmutableDictionary<Face, FaceColour> InitialiseFaceColourDict()
        {
            var dictBuilder = ImmutableDictionary.CreateBuilder<Face, FaceColour>();

            dictBuilder[whiteFace] = FaceColour.White;
            dictBuilder[yellowFace] = FaceColour.Yellow;
            dictBuilder[greenFace] = FaceColour.Green;
            dictBuilder[blueFace] = FaceColour.Blue;
            dictBuilder[redFace] = FaceColour.Red;
            dictBuilder[orangeFace] = FaceColour.Orange;

            return dictBuilder.ToImmutable();
        }

        private void Solver_Input_Colours_Load(object sender, EventArgs e)
        {
            PopulateCubeNet();
            lblInstructions.Text = GetInstructions();
            btnFinish.Visible = false;
        }

        private void PopulateCubeFace(Face face)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = 0; i < 3; i++)
            {
                face.Rows.Add("", "", "");
            }
            face[1, 1].Style.BackColor = faceColourDict[face].ToColor();
            face.ClearSelection(); //un-highlighting buttons
        }

        private void PopulateCubeNet()
        {
            //populating each face of the cube
            foreach(KeyValuePair<Face, FaceColour> entry in faceColourDict)
                PopulateCubeFace(entry.Key);
        }

        private string GetInstructions() 
        {
            string requiredPiece = stage.GetRequiredPiece();
            string requiredColour = stage.Step == 2 ? requiredPiece.Split(' ')[0] : "yellow";
            return $"Input the position of the {requiredColour} square on the {requiredPiece}";
        }

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
                selectedCellLocation = new CubeNetCellLocation(cellCoords, faceColourDict[face]);
                selectedCell = face.Rows[cellCoords.row].Cells[cellCoords.col];
                selectedCell.Style.BackColor = stage.GetInputColour().ToColor();
                btnFinish.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<OutputSolution>(this, stage, selectedCellLocation);
    }
}