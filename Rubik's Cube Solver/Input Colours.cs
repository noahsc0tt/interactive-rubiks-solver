using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    public partial class Input_Colours : Form
    {


        public Input_Colours()
        {
            InitializeComponent();
        }

        private void populateDataGrids()
        {
            //adding the cells to the colour selector

            colourSelector.Rows.Add("", "");

            //colouring the first cell based on the value of selected colour
            if (Global.selectedColour == "White")
            {
                colourSelector[0, 0].Style.BackColor = Color.White;
            }
            else if (Global.selectedColour == "Yellow")
            {
                colourSelector[0, 0].Style.BackColor = Color.Yellow;
            }
            else if (Global.selectedColour == "Green")
            {
                colourSelector[0, 0].Style.BackColor = Color.Green;
            }
            else if (Global.selectedColour == "Blue")
            {
                colourSelector[0, 0].Style.BackColor = Color.RoyalBlue;
            }
            else if (Global.selectedColour == "Red")
            {
                colourSelector[0, 0].Style.BackColor = Color.Red;
            }
            else if (Global.selectedColour == "Orange")
            {
                colourSelector[0, 0].Style.BackColor = Color.Orange;
            }

            //colouring the 'clear' cell
            colourSelector[1, 0].Style.BackColor = Color.Silver;

            //setting the text of the two cells
            colourSelector[0, 0].Value = Global.selectedColour; 
            colourSelector[1, 0].Value = "Clear";

            colourSelector.ClearSelection();//un-highlighting buttons


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

        }

        private void Solver_Input_Colours_Load(object sender, EventArgs e)
        {
            Global.coloured = false;

            //creating variables to store information pertaining to the instructions to be output
            string requiredFace = string.Empty;
            string requiredPiece = string.Empty;
            
            //setting the value of these variables based on the value of Global.stage
            if (Global.stage[0] == 1)
            {
                if (Global.stage[1] == 1)
                {
                    requiredPiece = "green";
                }
                else if (Global.stage[1] == 2)
                {
                    requiredPiece = "orange";

                }
                else if (Global.stage[1] == 3)
                {
                    requiredPiece = "blue";

                }
                else if (Global.stage[1] == 4)
                {
                    requiredPiece = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow and " + requiredPiece + " edge.";

                //setting Global.selectedColour to the correct value for this stage
                Global.selectedColour = "Yellow";

            }
            else if (Global.stage[0] == 2)
            {
                if (Global.stage[1] == 1)
                {
                    requiredPiece = "green and red";

                }
                else if (Global.stage[1] == 2)
                {
                    requiredPiece = "orange and green";

                }
                else if (Global.stage[1] == 3)
                {
                    requiredPiece = "blue and orange";

                }
                else if (Global.stage[1] == 4)
                {
                    requiredPiece = "red and blue";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow, " + requiredPiece + " corner.";

                //setting Global.selectedColour to the correct value for this stage
                Global.selectedColour = "Yellow";
            }
            else if (Global.stage[0] == 3)
            {
                if (Global.stage[1] == 1)
                {
                    requiredPiece = "green and red";
                    requiredFace = "green";

                }
                else if (Global.stage[1] == 2)
                {
                    requiredPiece = "orange and green";
                    requiredFace = "orange";

                }
                else if (Global.stage[1] == 3)
                {
                    requiredPiece = "blue and orange";
                    requiredFace = "blue";

                }
                else if (Global.stage[1] == 4)
                {
                    requiredPiece = "red and blue";
                    requiredFace = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the " + requiredFace + " square on the " + requiredPiece + " edge.";

                //setting Global.selectedColour to the correct value for this stage
                Global.selectedColour = (char.ToUpper(requiredFace[0]) + requiredFace.Substring(1));

            }

            populateDataGrids();


        }


        private void colourSelector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colourSelector.ClearSelection(); //un-highlighting buttons

            
            //updating the value of selectedColour based on which cell in the colour selector is clicked

            if (e.RowIndex == 0 && e.ColumnIndex == 0)
            {
                if(colourSelector[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.RoyalBlue)
                {
                    Global.selectedColour = "Blue";
                }
                else
                {
                    Global.selectedColour = colourSelector[e.ColumnIndex, e.RowIndex].Style.BackColor.Name;
                }
            }
            else if(e.RowIndex == 0 && e.ColumnIndex == 1)
            {
                Global.selectedColour = null;
            }
        }

        private void whiteFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            whiteFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && whiteFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && whiteFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }

            else if (Global.selectedColour == null) //if the user wants to clear a coloured cell
            {
                //default colour applied to cell
                whiteFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver;

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            }

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    whiteFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    whiteFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 2;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 2;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
            }
          


        }

        private void orangeFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            orangeFace.ClearSelection(); //un-highlighting a button after it is clicked
            
            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }

            else if (Global.selectedColour == null) //if the user wants to clear a coloured cell
            {
                //default colour applied to cell
                orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver;

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            }

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 2;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 2;
                    Global.location[2] = 3;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 2;
                    Global.location[2] = 1;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 2;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
            }


        }

        private void greenFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            greenFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }

            else if (Global.selectedColour == null) //if the user wants to clear a coloured cell
            {
                //default colour applied to cell
                greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver;

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            }

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 2;
                    Global.location[2] = 1;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 2;
                    Global.location[2] = 1;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
            }
        }

        private void redFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            redFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && redFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && redFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }

            else if (Global.selectedColour == null) //if the user wants to clear a coloured cell
            {
                //default colour applied to cell
                redFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver;

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            }

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    redFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    redFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 2;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 2;
                    Global.location[2] = 1;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 2;
                    Global.location[2] = 3;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 2;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
            }
        }

        private void blueFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            blueFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }

            else if (Global.selectedColour == null) //if the user wants to clear a coloured cell
            {
                //default colour applied to cell
                blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver;

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            }

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 3;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 2;
                    Global.location[2] = 3;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 2;
                    Global.location[2] = 3;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = "bad";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
            }

        }

        private void yellowFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yellowFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //if the user wants to clear a cell that is already clear
            else if (Global.selectedColour == null && yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor != colourSelector[0, 0].Style.BackColor && yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Blue)
            {
                MessageBox.Show("Square is already clear.");
            }
            
            else if(Global.selectedColour == null) //if the user wants to clear a coloured cell
            {                
                yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Silver; //default colour applied to cell

                Global.coloured = false; //the cell has now been cleared so Global.coloured is set to false
            } 

            else if (Global.coloured) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                if (Global.selectedColour == "Blue")
                {
                    yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Blue;
                }
                else
                {
                    yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor = colourSelector[0, 0].Style.BackColor;
                }

                Global.coloured = true; //the cell has now been coloured so Global.coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 1;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 2;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 2;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    Global.location[0] = 1;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    Global.location[0] = 2;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = "good";
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    Global.location[0] = 3;
                    Global.location[1] = 1;
                    Global.location[2] = 3;
                    Global.orientation = null;
                }
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            //opening menu
            Menu menu = new Menu();
            menu.Show();
            Visible = false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //checking if the user has inputted the position of the reqiured piece
            if (Global.coloured) 
            {
                //moving on to the output solution form
                Output_Solution os = new Output_Solution();
                os.Show();
                Visible = false;
            }
            else //if the user has not inputted the position of the piece
            {
                //error message telling the user to input the required information before moving on
                MessageBox.Show(lblInstructions.Text);
            }

        }

    }
}
