using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    using Face = DataGridView;

    internal partial class CheckingMoves : Form
    {
        private Stage stage;

        public CheckingMoves(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
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


        public void ColourYellowEdges(int subStep)
        {
            if (subStep >= 0)
            {
                greenFace[1, 2].Style.BackColor = Color.Green;
                yellowFace[1, 0].Style.BackColor = Color.Yellow;
            }
            if (subStep >= 1)
            {
                orangeFace[1, 2].Style.BackColor = Color.Orange;
                yellowFace[0, 1].Style.BackColor = Color.Yellow;
            }
            if (subStep >= 2)
            {
                blueFace[1, 2].Style.BackColor = Color.Blue;
                yellowFace[1, 2].Style.BackColor = Color.Yellow;
            }
            if (subStep == 3)
            {
                redFace[1, 2].Style.BackColor = Color.Red;
                yellowFace[2, 1].Style.BackColor = Color.Yellow;
            }
        }

        public void ColourYellowCorners(int subStep)
        {
            if (subStep >= 0)
            {
                redFace[0, 2].Style.BackColor = Color.Red;
                greenFace[2, 2].Style.BackColor = Color.Green;
                yellowFace[2, 0].Style.BackColor = Color.Yellow;
            }
            if (subStep >= 1)
            {
                greenFace[0, 2].Style.BackColor = Color.Green;
                orangeFace[2, 2].Style.BackColor = Color.Orange;
                yellowFace[0, 0].Style.BackColor = Color.Yellow;
            }
            if (subStep >= 2)
            {
                orangeFace[0, 2].Style.BackColor = Color.Orange;
                blueFace[2, 2].Style.BackColor = Color.Blue;
                yellowFace[0, 2].Style.BackColor = Color.Yellow;
            }
            if (subStep == 3)
            {
                blueFace[0, 2].Style.BackColor = Color.Blue;
                redFace[2, 2].Style.BackColor = Color.Red;
                yellowFace[2, 2].Style.BackColor = Color.Yellow;
            }
        }

        public void ColourMiddleLayerEdges(int subStep)
        {
            if (subStep >= 0)
            {
                redFace[0, 1].Style.BackColor = Color.Red;
                greenFace[2, 1].Style.BackColor = Color.Green;
            }
            if (subStep >= 1)
            {
                greenFace[0, 1].Style.BackColor = Color.Green;
                orangeFace[2, 1].Style.BackColor = Color.Orange;
            }
            if (subStep >= 2)
            {
                orangeFace[0, 1].Style.BackColor = Color.Orange;
                blueFace[2, 1].Style.BackColor = Color.Blue;
            }
            if (subStep == 3)
            {
                blueFace[0, 1].Style.BackColor = Color.Blue;
                redFace[2, 1].Style.BackColor = Color.Red;
            }
        }

        private void ColourLastLayer(int subStep)
        {
            if (stage.SubStep >= 1) // white edges
            {
                whiteFace[0, 1].Style.BackColor = Color.White;
                whiteFace[1, 0].Style.BackColor = Color.White;
                whiteFace[2, 1].Style.BackColor = Color.White;
                whiteFace[1, 2].Style.BackColor = Color.White;
            }
            if (stage.SubStep >= 2) // white corners
            {
                whiteFace[0, 0].Style.BackColor = Color.White;
                whiteFace[2, 0].Style.BackColor = Color.White;
                whiteFace[0, 2].Style.BackColor = Color.White;
                whiteFace[2, 2].Style.BackColor = Color.White;
            }
            if (stage.SubStep >= 3) // permuting corners
            {
                greenFace[0, 0].Style.BackColor = Color.Green;
                greenFace[2, 0].Style.BackColor = Color.Green;
                orangeFace[0, 0].Style.BackColor = Color.Orange;
                orangeFace[2, 0].Style.BackColor = Color.Orange;
                blueFace[0, 0].Style.BackColor = Color.Blue;
                blueFace[2, 0].Style.BackColor = Color.Blue;
                redFace[0, 0].Style.BackColor = Color.Red;
                redFace[2, 0].Style.BackColor = Color.Red;

            }
            if (stage.SubStep == 4) // permuting edges
            {
                greenFace[1, 0].Style.BackColor = Color.Green;
                orangeFace[1, 0].Style.BackColor = Color.Orange;
                blueFace[1, 0].Style.BackColor = Color.Blue;
                redFace[1, 0].Style.BackColor = Color.Red;
            }
        }

        private void ColourCubeNet()
        {
            PopulateCubeNet();
            
            switch (stage.Step)
            {
                case 0:
                    ColourYellowEdges(stage.SubStep); 
                    break;
                case 1:
                    ColourYellowEdges(4);
                    ColourYellowCorners(stage.SubStep);
                    break;
                case 2:
                    ColourYellowEdges(4);
                    ColourYellowCorners(4);
                    ColourMiddleLayerEdges(stage.SubStep);
                    break;
                case 3:
                    ColourYellowEdges(4);
                    ColourYellowCorners(4);
                    ColourMiddleLayerEdges(stage.SubStep);
                    ColourLastLayer(stage.SubStep);
                    break;

            };
        }

        private void Checking_Moves_Load(object sender, EventArgs e)
        {
            ColourCubeNet();

            //changing the text of the 'Next Stage' button if the user has completed the solve
            if (stage.GetStage() == (3,3))
            {
                btnNextStage.Visible = false;
                lblButtonInstructions.Text = "If your cube is fully solved, congratulations! Click the 'Menu' button to return to the menu.\r\n\r\nIf your cube is not solved, choose a stage to go back to in the 'Choose Stage' drop-down list.";
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();
            if (stage.Step == 3)
            {
                switch (stage.SubStep)
                {
                    case 0: FormNavigator.Navigate<TopLayerEdges>(this); break;
                    case 1: FormNavigator.Navigate<TopLayerCorners>(this); break;
                    case 2: FormNavigator.Navigate<PermutingCorners>(this); break;
                    case 3: FormNavigator.Navigate<PermutingEdges>(this); break;
                }
            }
            else
                FormNavigator.Navigate<InputColours>(this, stage);
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (int step, int subStep) = (string)boxChooseStage.SelectedItem switch
            {
                "Yellow Edges" => (0,0),
                "Yellow Corners" => (1,0),
                "Middle Layer Edges" => (2,0),
                "White Edges" => (3,0),
                "White Corners" => (3,1),
                "Corner Permutation" => (3,2),
                "Edge Permutation" => (3,3)
            };
            FormNavigator.Navigate<InputColours>(this, new Stage(step, subStep));
        }
    }
}
