using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_project
{
    public partial class ChangePassword : Form
    {

        private int userId;  // the ID of the user changing password
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";


        public ChangePassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string newPassword = NewPasswordTxt.Text;
        
            if (newPassword.Length < 10 || !newPassword.Any(ch => !char.IsLetterOrDigit(ch)))  // Ensures password is at least 10 characters and contains a special character
            {
                MessageBox.Show("Password must be at least 10 characters and include one or more special character.");
                return;
            }

         
            string hashedPassword = Encrypter.HashPassword(newPassword);

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "UPDATE ACCOUNT SET password=@password, MustChangePassword =0 WHERE user_id=@user_id";
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password updated successfully");
            this.Close(); 
        }
    }
}

