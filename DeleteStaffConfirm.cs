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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_project
{
    public partial class DeleteStaffConfirm : Form
    {

        private int UserId;
        private string connectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";


        public DeleteStaffConfirm(int userId, string username)
        {
            InitializeComponent();
            UserId = userId;


            ConfirmLbl.Text = "Are you sure you want to delete the staff member: " + username + "?";
        }

        private void DeleteStaffConfirm_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmDeleteBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ACCOUNT WHERE user_id = @user_id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", UserId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Staff member deleted successfully.");
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
