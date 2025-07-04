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


        public void ColourYellowEdges()
        {
            //colouring yellow edges
            greenFace[1, 2].Style.BackColor = Color.Green;
            yellowFace[1, 0].Style.BackColor = Color.Yellow;
            orangeFace[1, 2].Style.BackColor = Color.Orange;
            yellowFace[0, 1].Style.BackColor = Color.Yellow;
            blueFace[1, 2].Style.BackColor = Color.Blue;
            yellowFace[1, 2].Style.BackColor = Color.Yellow;
            redFace[1, 2].Style.BackColor = Color.Red;
            yellowFace[2, 1].Style.BackColor = Color.Yellow;
        }
        public void ColourYellowCorners()
        {
            //colouring yellow corners
            greenFace[2, 2].Style.BackColor = Color.Green;
            redFace[0, 2].Style.BackColor = Color.Red;
            yellowFace[2, 0].Style.BackColor = Color.Yellow;
            greenFace[0, 2].Style.BackColor = Color.Green;
            orangeFace[2, 2].Style.BackColor = Color.Orange;
            yellowFace[0, 0].Style.BackColor = Color.Yellow;
            orangeFace[0, 2].Style.BackColor = Color.Orange;
            blueFace[2, 2].Style.BackColor = Color.Blue;
            yellowFace[0, 2].Style.BackColor = Color.Yellow;
            blueFace[0, 2].Style.BackColor = Color.Blue;
            redFace[2, 2].Style.BackColor = Color.Red;
            yellowFace[2, 2].Style.BackColor = Color.Yellow;
        }

        public void ColourMiddleEdges()
        {
            //colouring middle layer edges
            greenFace[2, 1].Style.BackColor = Color.Green;
            redFace[0, 1].Style.BackColor = Color.Red;
            orangeFace[2, 1].Style.BackColor = Color.Orange;
            greenFace[0, 1].Style.BackColor = Color.Green;
            blueFace[2, 1].Style.BackColor = Color.Blue;
            orangeFace[0, 1].Style.BackColor = Color.Orange;
            redFace[2, 1].Style.BackColor = Color.Red;
            blueFace[0, 1].Style.BackColor = Color.Blue;
        }

        private void ColourCubeNet()
        {
            PopulateCubeNet();
            
            if (stage.Step == 1) //yellow edges
            {
                if (stage.SubStep >= 1) //yellow and green edge
                {
                    greenFace[1, 2].Style.BackColor = Color.Green;
                    yellowFace[1, 0].Style.BackColor = Color.Yellow;
                }
                if (stage.SubStep >= 2) //yellow and orange edge
                {
                    orangeFace[1, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 1].Style.BackColor = Color.Yellow;
                }
                if (stage.SubStep >= 3) //yellow and blue edge
                {
                    blueFace[1, 2].Style.BackColor = Color.Blue;
                    yellowFace[1, 2].Style.BackColor = Color.Yellow;
                }
                if (stage.SubStep == 4) //yellow and red edge
                {
                    redFace[1, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 1].Style.BackColor = Color.Yellow;
                }
            }
            else if (stage.Step == 2) //yellow corners
            {
                ColourYellowEdges();

                if (stage.SubStep >= 1) //yellow, green and red corner
                {
                    greenFace[2, 2].Style.BackColor = Color.Green;
                    redFace[0, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 0].Style.BackColor = Color.Yellow;
                }

                if (stage.SubStep >= 2) //yellow orange and green corner
                {
                    greenFace[0, 2].Style.BackColor = Color.Green;
                    orangeFace[2, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 0].Style.BackColor = Color.Yellow;
                }
                if (stage.SubStep >= 3) //yellow blue and orange corner
                {
                    orangeFace[0, 2].Style.BackColor = Color.Orange;
                    blueFace[2, 2].Style.BackColor = Color.Blue;
                    yellowFace[0, 2].Style.BackColor = Color.Yellow;
                }
                if (stage.SubStep == 4) //yellow red and blue corner
                {
                    blueFace[0, 2].Style.BackColor = Color.Blue;
                    redFace[2, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 2].Style.BackColor = Color.Yellow;
                }
            }
            else if (stage.Step == 3) //middle layer edges
            {
                ColourYellowEdges();
                ColourYellowCorners();

                if (stage.SubStep >= 1) //green and red edge
                {
                    greenFace[2, 1].Style.BackColor = Color.Green;
                    redFace[0, 1].Style.BackColor = Color.Red;
                }
                if (stage.SubStep >= 2) //orange and green edge
                {
                    orangeFace[2, 1].Style.BackColor = Color.Orange;
                    greenFace[0, 1].Style.BackColor = Color.Green;
                }
                if (stage.SubStep >= 3) //blue and orange edge
                {
                    blueFace[2, 1].Style.BackColor = Color.Blue;
                    orangeFace[0, 1].Style.BackColor = Color.Orange;
                }
                if (stage.SubStep == 4) //red and blue edge
                {
                    redFace[2, 1].Style.BackColor = Color.Red;
                    blueFace[0, 1].Style.BackColor = Color.Blue;
                }
            }
            else if (stage.Step == 4)
            {
                ColourYellowEdges();
                ColourYellowCorners();
                ColourMiddleEdges();

                if (stage.SubStep >= 1) //top layer edges
                {
                    whiteFace[0, 1].Style.BackColor = Color.White;
                    whiteFace[1, 0].Style.BackColor = Color.White;
                    whiteFace[2, 1].Style.BackColor = Color.White;
                    whiteFace[1, 2].Style.BackColor = Color.White;
                }
                if (stage.SubStep >= 2) //top layer corners
                {
                    whiteFace[0, 0].Style.BackColor = Color.White;
                    whiteFace[2, 0].Style.BackColor = Color.White;
                    whiteFace[0, 2].Style.BackColor = Color.White;
                    whiteFace[2, 2].Style.BackColor = Color.White;
                }
                if (stage.SubStep >= 3) //permuting corners
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
                if (stage.SubStep == 4) //permuting edges
                {
                    greenFace[1, 0].Style.BackColor = Color.Green;
                    orangeFace[1, 0].Style.BackColor = Color.Orange;
                    blueFace[1, 0].Style.BackColor = Color.Blue;
                    redFace[1, 0].Style.BackColor = Color.Red;
                }
            }
        }

        private void Checking_Moves_Load(object sender, EventArgs e)
        {
            //changing the text of the 'Next Stage' button if the user has completed the solve
            if (stage.Step == 4 && stage.SubStep == 4)
            {
                btnNextStage.Visible = false;
                lblButtonInstructions.Text = "If your cube is fully solved, congratulations! Click the 'Menu' button to return to the menu.\r\n\r\nIf your cube is not solved, choose a stage to go back to in the 'Choose Stage' drop-down list.";
            }
            ColourCubeNet();
        }

        private void btnMenu_Click(object sender, EventArgs e) =>
            FormNavigator.Navigate<Menu>(this);

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();
            if (stage.Step == 4)
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
