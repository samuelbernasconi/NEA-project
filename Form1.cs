using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace NEA_project
{
    public partial class loginpage : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";  // connection string to the database file


        public loginpage()
        {
            InitializeComponent();
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
            string username_input = UsernameTxt.Text;
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            string password_input = PasswordTxt.Text;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))         // creates a connection to the database
            {
                connection.Open();

                string query = "SELECT Password FROM ACCOUNT WHERE username = @username_input";  // Defines the SQL query to get the stored password for the given username

                using (SQLiteCommand command = new SQLiteCommand(query, connection))             // Creates a new command which will run the SQL query 
                {

                    command.Parameters.AddWithValue("@username_input", UsernameTxt.Text);        // Adds the username input as a parameter, prevents SQL injection

                    using (SQLiteDataReader reader = command.ExecuteReader())                    // Executes the command and gets a data reader to read the results
                    {
                        if (reader.Read())                                                       // Checks if a record containing the inputted username exists
                        {
                            string password_stored = reader.GetString(reader.GetOrdinal("password")); // Gets the index of the password column and retrieves the stored password
                            string password_input = PasswordTxt.Text;

                            if (password_stored == password_input)          // Compares the stored password with the inputted password for the login check
                            {
                                MessageBox.Show("Login successful!");



                                homepage newform = new homepage();
                                newform.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Invalid password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found.");
                        }

                    }

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            homepage newform = new homepage();
            newform.Show();
            this.Hide();
        }

       
    }
          



         
}
