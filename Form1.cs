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
            bool passwordMatch = false;
            bool mustChangePassword = false;
            int  currentUserId = -1;
            string Role = "";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))         // creates a connection to the database
            {
                connection.Open();

                string query = "SELECT Password, MustChangePassword, user_id, role FROM ACCOUNT WHERE username = @username_input";  // Defines the SQL query to get the stored password for the given username

                using (SQLiteCommand command = new SQLiteCommand(query, connection))             // Creates a new command which will run the SQL query 
                {

                    command.Parameters.AddWithValue("@username_input", UsernameTxt.Text);        // Adds the username input as a parameter, prevents SQL injection

                    using (SQLiteDataReader reader = command.ExecuteReader())                    // Executes the command and gets a data reader to read the results
                    {
                        if (reader.Read())
                        {
                            string password_stored = reader.GetString(reader.GetOrdinal("password"));  // Gets the index of the password column and retrieves the stored password
                            string password_input = PasswordTxt.Text;                                       

                            passwordMatch = Encrypter.VerifyPassword(password_input, password_stored);  // Uses the Encrypter class to verify the password

                            if (passwordMatch)
                            {
                                mustChangePassword = reader.GetInt32(reader.GetOrdinal("MustChangePassword")) == 1;  // Checks if the user must change their password
                                currentUserId = reader.GetInt32(reader.GetOrdinal("user_id"));                                // Gets the user ID
                                Role = reader.GetString(reader.GetOrdinal("role"));
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

            if (passwordMatch)
            {
                if (mustChangePassword)
                {
                    MessageBox.Show("Password change required.");
                    ChangePassword changeForm = new ChangePassword(currentUserId);   // Opens the ChangePassword form

                    changeForm.ShowDialog();  
                }

                MessageBox.Show("Login successful!");

                homepage newform = new homepage(Role);
                newform.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            homepage newform = new homepage("Manager");
            newform.Show();
            this.Hide();
        }

       
    }
}
