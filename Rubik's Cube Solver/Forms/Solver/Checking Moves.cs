using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal partial class Checking_Moves : Form
    {
        private Stage stage;

        public Checking_Moves(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();

            stage = currentStage;
        }

        public void colourYellowEdges()
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
        public void colourYellowCorners()
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
        public void colourMiddleEdges()
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

        private void populateDataGrids()
        {
            //populating the rubiks cube net and setting the colour of the centre pieces

            orangeFace.Rows.Add("", "", "");
            orangeFace.Rows.Add("", "", "");
            orangeFace.Rows.Add("", "", "");
            orangeFace.ClearSelection(); //un-highlighting buttons
            orangeFace[1, 1].Style.BackColor = Color.Orange;

            redFace.Rows.Add("", "", "");
            redFace.Rows.Add("", "", "");
            redFace.Rows.Add("", "", "");
            redFace.ClearSelection(); //un-highlighting buttons
            redFace[1, 1].Style.BackColor = Color.Red;

            whiteFace.Rows.Add("", "", "");
            whiteFace.Rows.Add("", "", "");
            whiteFace.Rows.Add("", "", "");
            whiteFace.ClearSelection(); //un-highlighting buttons
            whiteFace[1, 1].Style.BackColor = Color.White;

            yellowFace.Rows.Add("", "", "");
            yellowFace.Rows.Add("", "", "");
            yellowFace.Rows.Add("", "", "");
            yellowFace.ClearSelection(); //un-highlighting buttons
            yellowFace[1, 1].Style.BackColor = Color.Yellow;

            blueFace.Rows.Add("", "", "");
            blueFace.Rows.Add("", "", "");
            blueFace.Rows.Add("", "", "");
            blueFace.ClearSelection(); //un-highlighting buttons
            blueFace[1, 1].Style.BackColor = Color.Blue;

            greenFace.Rows.Add("", "", "");
            greenFace.Rows.Add("", "", "");
            greenFace.Rows.Add("", "", "");
            greenFace.ClearSelection(); //un-highlighting buttons
            greenFace[1, 1].Style.BackColor = Color.Green;


            //colouring the net based on the stage

            if (stage.step == 1) //yellow edges
            {
                if (stage.subStep >= 1) //yellow and green edge
                {
                    greenFace[1, 2].Style.BackColor = Color.Green;
                    yellowFace[1, 0].Style.BackColor = Color.Yellow;
                }
                if (stage.subStep >= 2) //yellow and orange edge
                {
                    orangeFace[1, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 1].Style.BackColor = Color.Yellow;
                }
                if (stage.subStep >= 3) //yellow and blue edge
                {
                    blueFace[1, 2].Style.BackColor = Color.Blue;
                    yellowFace[1, 2].Style.BackColor = Color.Yellow;
                }
                if (stage.subStep == 4) //yellow and red edge
                {
                    redFace[1, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 1].Style.BackColor = Color.Yellow;
                }
            }
            else if (stage.step == 2) //yellow corners
            {
                colourYellowEdges();

                if (stage.subStep >= 1) //yellow, green and red corner
                {
                    greenFace[2, 2].Style.BackColor = Color.Green;
                    redFace[0, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 0].Style.BackColor = Color.Yellow;
                }

                if (stage.subStep >= 2) //yellow orange and green corner
                {
                    greenFace[0, 2].Style.BackColor = Color.Green;
                    orangeFace[2, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 0].Style.BackColor = Color.Yellow;
                }
                if (stage.subStep >= 3) //yellow blue and orange corner
                {
                    orangeFace[0, 2].Style.BackColor = Color.Orange;
                    blueFace[2, 2].Style.BackColor = Color.Blue;
                    yellowFace[0, 2].Style.BackColor = Color.Yellow;
                }
                if (stage.subStep == 4) //yellow red and blue corner
                {
                    blueFace[0, 2].Style.BackColor = Color.Blue;
                    redFace[2, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 2].Style.BackColor = Color.Yellow;
                }
            }
            else if (stage.step == 3) //middle layer edges
            {
                colourYellowEdges();
                colourYellowCorners();

                if (stage.subStep >= 1) //green and red edge
                {
                    greenFace[2, 1].Style.BackColor = Color.Green;
                    redFace[0, 1].Style.BackColor = Color.Red;
                }
                if (stage.subStep >= 2) //orange and green edge
                {
                    orangeFace[2, 1].Style.BackColor = Color.Orange;
                    greenFace[0, 1].Style.BackColor = Color.Green;
                }
                if (stage.subStep >= 3) //blue and orange edge
                {
                    blueFace[2, 1].Style.BackColor = Color.Blue;
                    orangeFace[0, 1].Style.BackColor = Color.Orange;
                }
                if (stage.subStep == 4) //red and blue edge
                {
                    redFace[2, 1].Style.BackColor = Color.Red;
                    blueFace[0, 1].Style.BackColor = Color.Blue;
                }
            }
            else if (stage.step == 4)
            {
                colourYellowEdges();
                colourYellowCorners();
                colourMiddleEdges();

                if (stage.subStep >= 1) //top layer edges
                {
                    whiteFace[0, 1].Style.BackColor = Color.White;
                    whiteFace[1, 0].Style.BackColor = Color.White;
                    whiteFace[2, 1].Style.BackColor = Color.White;
                    whiteFace[1, 2].Style.BackColor = Color.White;
                }
                if (stage.subStep >= 2) //top layer corners
                {
                    whiteFace[0, 0].Style.BackColor = Color.White;
                    whiteFace[2, 0].Style.BackColor = Color.White;
                    whiteFace[0, 2].Style.BackColor = Color.White;
                    whiteFace[2, 2].Style.BackColor = Color.White;
                }
                if (stage.subStep >= 3) //permuting corners
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
                if (stage.subStep == 4) //permuting edges
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
            if (stage.step == 4 && stage.subStep == 4)
            {
                btnNextStage.Visible = false;

                lblButtonInstructions.Text = "If your cube is fully solved, congratulations! Click the 'Menu' button to return to the menu.\r\n\r\nIf your cube is not solved, choose a stage to go back to in the 'Choose Stage' drop-down list.";
            }

            populateDataGrids();
        }



        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            stage.Increment();

            if (stage.step == 4)
            {
                if (stage.subStep == 1)
                {
                    FormNavigator.Navigate<Top_Layer_Edges>(this);

                }
                else if (stage.subStep == 2)
                {
                    FormNavigator.Navigate<Top_Layer_Corners>(this);

                }
                else if (stage.subStep == 3)
                {
                    FormNavigator.Navigate<Permuting_Corners>(this);

                }
                else if (stage.subStep == 4)
                {
                    FormNavigator.Navigate<Permuting_Edges>(this);
                }
            }
            else
            {
                //opening the 'Input Colours' form
                FormNavigator.Navigate<Input_Colours>(this);

            }
            
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //setting the stage value and opening the correct form based on user input on the drop-down list

            if ((string)boxChooseStage.SelectedItem == "Yellow Edges")
            {
                stage = new Stage(1,1);

                FormNavigator.Navigate<Input_Colours>(this);
                
            }
            if ((string)boxChooseStage.SelectedItem == "Yellow Corners")
            {
                stage = new Stage(2,1);

                FormNavigator.Navigate<Input_Colours>(this);
                
            }
            if ((string)boxChooseStage.SelectedItem == "Middle Layer Edges")
            {
                stage = new Stage(3,1);

                FormNavigator.Navigate<Input_Colours>(this);
                
            }
            if ((string)boxChooseStage.SelectedItem == "White Edges")
            {
                stage = new Stage(4,1);

                FormNavigator.Navigate<Top_Layer_Edges>(this);
            }
            if ((string)boxChooseStage.SelectedItem == "White Corners")
            {
                stage = new Stage(4,2);

                FormNavigator.Navigate<Top_Layer_Corners>(this);
            }
            if ((string)boxChooseStage.SelectedItem == "Corner Permutation")
            {
                stage = new Stage(4,3);

                FormNavigator.Navigate<Top_Layer_Corners>(this);
            }
            if ((string)boxChooseStage.SelectedItem == "Edge Permutation")
            {
                stage = new Stage(4,4);

                FormNavigator.Navigate<Top_Layer_Edges>(this);
            }
        }


        private void whiteFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            whiteFace.ClearSelection(); //un-highlighting a button after it is clicked

        }

        private void orangeFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            orangeFace.ClearSelection(); //un-highlighting a button after it is clicked

        }

        private void greenFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            greenFace.ClearSelection(); //un-highlighting a button after it is clicked

        }

        private void redFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            redFace.ClearSelection(); //un-highlighting a button after it is clicked

        }

        private void blueFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            blueFace.ClearSelection(); //un-highlighting a button after it is clicked

        }

        private void yellowFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yellowFace.ClearSelection(); //un-highlighting a button after it is clicked
        }

        private void lblButtonInstructions_Click(object sender, EventArgs e)
        {

        }
    }
}
