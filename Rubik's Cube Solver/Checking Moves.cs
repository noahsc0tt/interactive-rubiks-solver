using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Checking_Moves : Form
    {
        public Checking_Moves()
        {
            InitializeComponent();
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

            if (Global.stage[0] == 1) //yellow edges
            {
                if (Global.stage[1] >= 1) //yellow and green edge
                {
                    greenFace[1, 2].Style.BackColor = Color.Green;
                    yellowFace[1, 0].Style.BackColor = Color.Yellow;
                }
                if (Global.stage[1] >= 2) //yellow and orange edge
                {
                    orangeFace[1, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 1].Style.BackColor = Color.Yellow;
                }
                if (Global.stage[1] >= 3) //yellow and blue edge
                {
                    blueFace[1, 2].Style.BackColor = Color.Blue;
                    yellowFace[1, 2].Style.BackColor = Color.Yellow;
                }
                if (Global.stage[1] == 4) //yellow and red edge
                {
                    redFace[1, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 1].Style.BackColor = Color.Yellow;
                }
            }
            else if (Global.stage[0] == 2) //yellow corners
            {
                colourYellowEdges();

                if (Global.stage[1] >= 1) //yellow, green and red corner
                {
                    greenFace[2, 2].Style.BackColor = Color.Green;
                    redFace[0, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 0].Style.BackColor = Color.Yellow;
                }

                if (Global.stage[1] >= 2) //yellow orange and green corner
                {
                    greenFace[0, 2].Style.BackColor = Color.Green;
                    orangeFace[2, 2].Style.BackColor = Color.Orange;
                    yellowFace[0, 0].Style.BackColor = Color.Yellow;
                }
                if (Global.stage[1] >= 3) //yellow blue and orange corner
                {
                    orangeFace[0, 2].Style.BackColor = Color.Orange;
                    blueFace[2, 2].Style.BackColor = Color.Blue;
                    yellowFace[0, 2].Style.BackColor = Color.Yellow;
                }
                if (Global.stage[1] == 4) //yellow red and blue corner
                {
                    blueFace[0, 2].Style.BackColor = Color.Blue;
                    redFace[2, 2].Style.BackColor = Color.Red;
                    yellowFace[2, 2].Style.BackColor = Color.Yellow;
                }
            }
            else if (Global.stage[0] == 3) //middle layer edges
            {
                colourYellowEdges();
                colourYellowCorners();

                if (Global.stage[1] >= 1) //green and red edge
                {
                    greenFace[2, 1].Style.BackColor = Color.Green;
                    redFace[0, 1].Style.BackColor = Color.Red;
                }
                if (Global.stage[1] >= 2) //orange and green edge
                {
                    orangeFace[2, 1].Style.BackColor = Color.Orange;
                    greenFace[0, 1].Style.BackColor = Color.Green;
                }
                if (Global.stage[1] >= 3) //blue and orange edge
                {
                    blueFace[2, 1].Style.BackColor = Color.Blue;
                    orangeFace[0, 1].Style.BackColor = Color.Orange;
                }
                if (Global.stage[1] == 4) //red and blue edge
                {
                    redFace[2, 1].Style.BackColor = Color.Red;
                    blueFace[0, 1].Style.BackColor = Color.Blue;
                }
            }
            else if (Global.stage[0] == 4)
            {
                colourYellowEdges();
                colourYellowCorners();
                colourMiddleEdges();

                if (Global.stage[1] >= 1) //top layer edges
                {
                    whiteFace[0, 1].Style.BackColor = Color.White;
                    whiteFace[1, 0].Style.BackColor = Color.White;
                    whiteFace[2, 1].Style.BackColor = Color.White;
                    whiteFace[1, 2].Style.BackColor = Color.White;
                }
                if (Global.stage[1] >= 2) //top layer corners
                {
                    whiteFace[0, 0].Style.BackColor = Color.White;
                    whiteFace[2, 0].Style.BackColor = Color.White;
                    whiteFace[0, 2].Style.BackColor = Color.White;
                    whiteFace[2, 2].Style.BackColor = Color.White;
                }
                if (Global.stage[1] >= 3) //permuting corners
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
                if (Global.stage[1] == 4) //permuting edges
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
            if (Global.stage[0] == 4 && Global.stage[1] == 4)
            {
                btnNextStage.Visible = false;

                lblButtonInstructions.Text = "If your cube is fully solved, congratulations! Click the 'Menu' button to return to the menu.\r\n\r\nIf your cube is not solved, choose a stage to go back to in the 'Choose Stage' drop-down list.";
            }

            populateDataGrids();
        }



        private void btnMenu_Click(object sender, EventArgs e)
        {
            //opening menu
            Menu menu = new Menu();
            menu.Show();
            Visible = false;
        }

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            Global.incrementStage();

            if (Global.stage[0] == 4)
            {
                if (Global.stage[1] == 1)
                {
                    //opening the 'Top Layer Edges' form
                    Top_Layer_Edges tle = new Top_Layer_Edges();
                    tle.Show();
                    Visible = false;
                    
                }
                else if (Global.stage[1] == 2)
                {
                    //opening the 'Top Layer Corners' form
                    Top_Layer_Corners tlc = new Top_Layer_Corners();
                    tlc.Show();
                    Visible = false;
                    
                }
                else if (Global.stage[1] == 3)
                {
                    //opening the 'Permuting Corners' form
                    Permuting_Corners pc = new Permuting_Corners();
                    pc.Show();
                    Visible = false;
                    
                }
                else if (Global.stage[1] == 4)
                {
                    //opening the 'Permuting Edges' form
                    Permuting_Edges pe = new Permuting_Edges();
                    pe.Show();
                    Visible = false;
                }
            }
            else
            {
                //opening the 'Input Colours' form
                Input_Colours ic = new Input_Colours();
                ic.Show();
                Visible = false;
            }
            
        }

        private void boxChooseStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //setting the stage value and opening the correct form based on user input on the drop-down list

            if ((string)boxChooseStage.SelectedItem == "Yellow Edges")
            {
                Global.stage[0] = 1;
                Global.stage[1] = 1;

                //opening the 'Input Colours' form
                Input_Colours ic = new Input_Colours();
                ic.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "Yellow Corners")
            {
                Global.stage[0] = 2;
                Global.stage[1] = 1;

                //opening the 'Input Colours' form
                Input_Colours ic = new Input_Colours();
                ic.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "Middle Layer Edges")
            {
                Global.stage[0] = 3;
                Global.stage[1] = 1;

                //opening the 'Input Colours' form
                Input_Colours ic = new Input_Colours();
                ic.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "White Edges")
            {
                Global.stage[0] = 4;
                Global.stage[1] = 1;

                //opening the 'Top Layer Edges' form
                Top_Layer_Edges tle = new Top_Layer_Edges();
                tle.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "White Corners")
            {
                Global.stage[0] = 4;
                Global.stage[1] = 2;

                //opening the 'Top Layer Corners' form
                Top_Layer_Corners tlc = new Top_Layer_Corners();
                tlc.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "Corner Permutation")
            {
                Global.stage[0] = 4;
                Global.stage[1] = 3;

                //opening the 'Permuting Corners' form
                Permuting_Corners pc = new Permuting_Corners();
                pc.Show();
                Visible = false;
            }
            if ((string)boxChooseStage.SelectedItem == "Edge Permutation")
            {
                Global.stage[0] = 4;
                Global.stage[1] = 4;

                //opening the 'Permuting Edges' form
                Permuting_Edges pe = new Permuting_Edges();
                pe.Show();
                Visible = false;
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
    }
}
