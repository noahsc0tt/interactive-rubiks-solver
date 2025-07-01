using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    using Face = DataGridView;

    internal partial class Input_Colours : Form
    {
        private readonly Stage stage;
        private CubeNetCellLocation? selectedCell;
        private readonly ImmutableDictionary<DataGridView, FaceColour> faceColourDict;

        public Input_Colours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
            btnFinish.Visible = false;

            stage = currentStage;

            var dictBuilder = ImmutableDictionary.CreateBuilder<Face, FaceColour>();
            dictBuilder[orangeFace] = FaceColour.Orange;
            dictBuilder[redFace] = FaceColour.Red;
            dictBuilder[whiteFace] = FaceColour.White;
            dictBuilder[yellowFace] = FaceColour.Yellow;
            dictBuilder[blueFace] = FaceColour.Blue;
            dictBuilder[greenFace] = FaceColour.Green;
            faceColourDict = dictBuilder.ToImmutable();
        }

        private void Solver_Input_Colours_Load(object sender, EventArgs e)
        {
            PopulateCubeNet();
            lblInstructions.Text = GetInstructions();
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
            string requiredColour = stage.Step switch
            {
                0 or 1 => "yellow",
                2 => requiredPiece.Split(' ')[0]
            };
            return $"Input the position of the {requiredColour} square on the {requiredPiece}";
        }

        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Face face = (Face)sender;
            face.ClearSelection();

            (int col, int row) cellCoords = (e.ColumnIndex, e.RowIndex);
            if (cellCoords == (1,1)) //if a centre piece is clicked
                MessageBox.Show("Centre colours cannot be changed.");
            else
            {
                selectedCell = new CubeNetCellLocation(cellCoords, faceColourDict[face]);
                face.Rows[cellCoords.row].Cells[cellCoords.col].Style.BackColor = stage.GetInputColour().ToColor();
                btnFinish.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) => FormNavigator.Navigate<Menu>(this);

        private void btnFinish_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Output_Solution>(this, stage, selectedCell);
            
        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedCell = null;
            btnFinish.Visible = false;
        }
    }
}
