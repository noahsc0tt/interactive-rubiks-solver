using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubiks_Cube_Solver
{
    internal partial class Input_Colours : Form
    {
        private readonly Stage stage;
        private bool selectionMade = false;
        private PieceLocation selectedPiece;
        private bool? goodEdgeOrientation;

        public Input_Colours(Stage currentStage)
        {
            InitializeComponent();
            this.ApplyDefaultFormSettings();
            stage = currentStage;
        }

        private void PopulateFace(DataGridView face, Color colour)
        {
            // adding the cells to the face and colouring the centre cell
            for (int i = 0; i < 3; i++)
            {
                face.Rows.Add("", "", "");
            }
            face[1, 1].Style.BackColor = colour;
            face.ClearSelection(); //un-highlighting buttons
        }

        private void PopulateDataGrids()
        {
            //populating each face of the cube
            PopulateFace(orangeFace, Color.Orange);
            PopulateFace(redFace, Color.Red);
            PopulateFace(whiteFace, Color.White);
            PopulateFace(yellowFace, Color.Yellow);
            PopulateFace(blueFace, Color.RoyalBlue);
            PopulateFace(greenFace, Color.Green);
        }

        private void Solver_Input_Colours_Load(object sender, EventArgs e)
        {
            selectionMade = false;

            //creating variables to store information pertaining to the instructions to be output
            string requiredFace = string.Empty;
            string requiredPiece = string.Empty;
            
            //setting the value of these variables based on the value of Global.stage
            if (stage.Step == 1)
            {
                if (stage.SubStep == 1)
                {
                    requiredPiece = "green";
                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "orange";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "blue";

                }
                else if (stage.SubStep == 4)
                {
                    requiredPiece = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow and " + requiredPiece + " edge.";
            }
            else if (stage.Step == 2)
            {
                if (stage.SubStep == 1)
                {
                    requiredPiece = "green and red";

                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "orange and green";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "blue and orange";

                }
                else if (stage.SubStep == 4)
                {
                    requiredPiece = "red and blue";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the yellow square on the yellow, " + requiredPiece + " corner.";
            }
            else if (stage.Step == 3)
            {
                if (stage.SubStep == 1)
                {
                    requiredPiece = "green and red";
                    requiredFace = "green";

                }
                else if (stage.SubStep == 2)
                {
                    requiredPiece = "orange and green";
                    requiredFace = "orange";

                }
                else if (stage.SubStep == 3)
                {
                    requiredPiece = "blue and orange";
                    requiredFace = "blue";

                }
                else if (stage.SubStep == 4)
                {
                    requiredPiece = "red and blue";
                    requiredFace = "red";

                }
                //outputting the instructions
                lblInstructions.Text = "Input the position of the " + requiredFace + " square on the " + requiredPiece + " edge.";
            }

            PopulateDataGrids();


        }

        private void whiteFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            whiteFace.ClearSelection(); //un-highlighting a button after it is clicked

            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            //setting the values of Global.location and Global.orientation based on which cell has been clicked
            if (e.ColumnIndex == 0 && e.RowIndex == 0)
            {
                selectedPiece = new PieceLocation(1, 3, 3);
            }
            else if (e.ColumnIndex == 1 && e.RowIndex == 0)
            {
                selectedPiece = new PieceLocation(2,3,3);
                goodEdgeOrientation = true;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex == 0)
            {
                selectedPiece = new PieceLocation(3,3,3);
            }
            else if (e.ColumnIndex == 0 && e.RowIndex == 1)
            {
                selectedPiece = new PieceLocation(1,3,2);
                goodEdgeOrientation = true;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex == 1)
            {
                selectedPiece = new PieceLocation(3,3,2);
                goodEdgeOrientation = true;
            }
            else if (e.ColumnIndex == 0 && e.RowIndex == 2)
            {
                selectedPiece = new PieceLocation(1,3,1);
            }
            else if (e.ColumnIndex == 1 && e.RowIndex == 2)
            {
                selectedPiece = new PieceLocation(2,3,1);
                goodEdgeOrientation = true;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex == 2)
            {
                selectedPiece = new PieceLocation(3,3,1);
            }
            
          


        }

        private void orangeFace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            orangeFace.ClearSelection(); //un-highlighting a button after it is clicked
            
            if (e.ColumnIndex == 1 && e.RowIndex == 1) //if a centre piece is clicked
            {
                MessageBox.Show("Centre colours cannot be changed.");
            }

            else if (selectionMade) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                orangeFace[e.ColumnIndex, e.RowIndex].Style.BackColor = stage.GetColour();

                selectionMade = true; //the cell has now been coloured so coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,3,3);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,3,2);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,3,1);
                    }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(1,2,3);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(1,2,1);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,3);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,2);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,1);
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

            else if (selectionMade) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                greenFace[e.ColumnIndex, e.RowIndex].Style.BackColor = stage.GetColour();

                selectionMade = true; //the cell has now been coloured so coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,3,1);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(2,3,1);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,3,1);
                    }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(1,2,1);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(3,2,1);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,1);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(2,1,1);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,1);
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

            else if (selectionMade) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                redFace[e.ColumnIndex, e.RowIndex].Style.BackColor = stage.GetColour();

                selectionMade = true; //the cell has now been coloured so coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,3,1);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,3,2);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,3,3);
                    }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(3,2,1);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(3,2,3);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,1);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,2);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,3);
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

            else if (selectionMade) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                blueFace[e.ColumnIndex, e.RowIndex].Style.BackColor = stage.GetColour();

                selectionMade = true; //the cell has now been coloured so coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,3,3);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(2,3,3);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,3,3);
                    }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(3,2,3);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(1,2,3);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,3);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(2,1,3);
                    goodEdgeOrientation = false;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,3);
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
            else if (selectionMade) //if a piece has already been selected
            {
                MessageBox.Show("Cannot select more than one square.");
            }

            else //if a valid piece is clicked
            {
                //colouring the square
                yellowFace[e.ColumnIndex, e.RowIndex].Style.BackColor = stage.GetColour();

                selectionMade = true; //the cell has now been coloured so coloured is set to true

                //setting the values of Global.location and Global.orientation based on which cell has been clicked
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(1,1,1);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(2,1,1);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    selectedPiece = new PieceLocation(3,1,1);
                    }
                else if (e.ColumnIndex == 0 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(1,1,2);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 1)
                {
                    selectedPiece = new PieceLocation(3,1,2);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 0 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(1,1,3);
                    }
                else if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(2,1,3);
                    goodEdgeOrientation = true;
                }
                else if (e.ColumnIndex == 2 && e.RowIndex == 2)
                {
                    selectedPiece = new PieceLocation(3,1,3);
                    }
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormNavigator.Navigate<Menu>(this);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //checking if the user has inputted the position of the required piece
            if (selectionMade) 
            {
                //moving on to the output solution form
                FormNavigator.Navigate<Output_Solution>(this);
            }
            else
            {
                //error message telling the user to input the required information before moving on
                MessageBox.Show(lblInstructions.Text);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedPiece = null;
            goodEdgeOrientation = null;


        }
    }
}
