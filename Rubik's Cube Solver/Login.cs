using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rubik_s_Cube_Solver
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //declaring variables to store the values inputted by the user
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            //checking if either of the inputs are blank or are solely whitespace
            if (String.IsNullOrWhiteSpace(enteredUsername) || String.IsNullOrWhiteSpace(enteredPassword))
            {
                //displaying error message
                lblError.Text = "Enter a username and password.";

                //clearing the values entered, allowing the user to try again
                txtUsername.Clear();
                txtPassword.Clear();

            }

            else
            {

                //creating database connection 
                var selectConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rubiksCubeDB.accdb");
                selectConn.Open();

                //creating a variable to store the select SQL statement
                string selectString = "SELECT * FROM login";

                //executing the SQL statement and creating a reader object to search the selected values
                OleDbCommand selectCommand = new OleDbCommand(selectString, selectConn);
                OleDbDataReader selectReader = selectCommand.ExecuteReader();

                //iterating through the database values
                while (selectReader.Read())
                {
                    string username = (string)selectReader["username"];
                    string password = (string)selectReader["userPassword"];

                    //checking if the values entered by the user match a set of values in the database
                    if (enteredUsername == username && enteredPassword == password)
                    {
                        //if the values match, the user is granted access to the rest of the program
                        Menu menu = new Menu();
                        menu.Show();
                        Visible = false;
                    }
                }

                //if values do not match any data from the database, an error message is displayed
                lblError.Text = "Incorrect username or password.";

                //clearing the values entered, allowing the user to try again
                txtUsername.Clear();
                txtPassword.Clear();

                selectReader.Close();
                selectConn.Close();
            }

        }



        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //declaring variables to store the values inputted by the user
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            //checking if either of the inputs are blank or are solely whitespace
            if (String.IsNullOrWhiteSpace(enteredUsername) || String.IsNullOrWhiteSpace(enteredPassword))
            {
                //displaying error message
                lblError.Text = "Enter a username and password.";

                //clearing the values entered, allowing the user to try again
                txtUsername.Clear();
                txtPassword.Clear();
                
            }

            //checking if the username or password contain spaces
            else if (enteredUsername.Contains(" ") || enteredPassword.Contains(" "))
            {
                //displaying error message
                lblError.Text = "Username and password cannot contain spaces.";

                //clearing the values entered, allowing the user to try again
                txtUsername.Clear();
                txtPassword.Clear();
            }

            else if (enteredUsername.Length > 15 || enteredPassword.Length > 15)
            {                
                //displaying error message
                lblError.Text = "Username and password cannot be longer than 15 characters.";

                //clearing the values entered, allowing the user to try again
                txtUsername.Clear();
                txtPassword.Clear();
            }
        

            else //if the username and password are valid
            {
                //creating database connection 
                var selectConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rubiksCubeDB.accdb");
                selectConn.Open();

                //creating a variable to store the select SQL statement
                string selectString = "SELECT username FROM login";

                //executing the SQL statement and creating a reader object to search the selected values
                OleDbCommand selectCommand = new OleDbCommand(selectString, selectConn);
                OleDbDataReader selectReader = selectCommand.ExecuteReader();

                //creating a flag 
                Boolean duplicateUsername = false;

                //iterating through the database values (unless username is a duplicate one)
                while (selectReader.Read() && !duplicateUsername) 
                {
                    string username = (string)selectReader["username"];

                    //checking if the username is a duplicate
                    if (enteredUsername == username)
                    {
                        //displaying error message
                        lblError.Text = "Username taken.";

                        //clearing the values entered, allowing the user to try again
                        txtUsername.Clear();
                        txtPassword.Clear();

                        //flagging
                        duplicateUsername = true;

                    }
                }

                selectReader.Close();
                selectConn.Close();

                //if the username entered is not a duplicate
                if (!(duplicateUsername))
                {
                    //creating database connection 
                    var insertConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rubiksCubeDB.accdb");
                    insertConn.Open();

                    //creating a variable to store the insert SQL statement
                    string insertString = "INSERT INTO login(username,userPassword) values('" + enteredUsername + "', '" + enteredPassword + "')";

                    //executing the SQL statement and creating a reader object to insert the values
                    OleDbCommand insertCommand = new OleDbCommand(insertString, insertConn);
                    OleDbDataReader insertReader = insertCommand.ExecuteReader();

                    insertReader.Close();
                    insertConn.Close();

                    MessageBox.Show("Account created.");

                    //the user is granted access to the rest of the program
                    Menu menu = new Menu();
                    menu.Show();
                    Visible = false;
                }

            }
        }
    }
}
