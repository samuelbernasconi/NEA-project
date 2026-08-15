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
    public partial class Staff : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";
        

        public Staff()
        {

            InitializeComponent();
                     
            AddStaffPanel.Hide();

            LoadStaffTable();
        }

 
        private void LoadStaffTable()
        {
            StaffDataGridView.CellContentClick += StaffDataGridView_CellContentClick;




            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                    connection.Open();
                                                                                                // Selects the needed fields from the  ACCOUNT table
                    string query = @"SELECT user_id, username, role, email, name                                 
                                   FROM ACCOUNT";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))     // Uses the data adapter to fill a DataTable with the results of the query
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);                                                     // Fill the DataTable with the data feched from the PRODUCT table

                        StaffDataGridView.DataSource = table;                                    // Show results in DataGridView
                    }

                   

            }



            if (!StaffDataGridView.Columns.Contains("DeleteBtn"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "DeleteBtn";
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                StaffDataGridView.Columns.Add(deleteButtonColumn);
            }


        }

        private void StaffDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StaffDataGridView.Columns[e.ColumnIndex].Name == "DeleteBtn" && e.RowIndex >= 0) // Checks that the Delete button column was clicked
            {
                int userId = Convert.ToInt32(StaffDataGridView.Rows[e.RowIndex].Cells["user_id"].Value);  // Gets the user ID of the selected row
                string username = StaffDataGridView.Rows[e.RowIndex].Cells["username"].Value.ToString();  // Gets the username of the selected row

                DeleteStaffConfirm confirmForm = new DeleteStaffConfirm(userId, username);  // Opens the confirmation form
                confirmForm.ShowDialog(); 
              
                LoadStaffTable();
            }
        }


        private void SaveStaffBtn_Click(object sender, EventArgs e)
        {
            AddStaffPanel.Show();

            string StaffUsername = StaffUsernameTxt.Text;
            string StaffPassword = StaffPasswordTxt.Text;                // Sets of the inputs to variables
            string StaffName = StaffNameTxt.Text;
            string StaffRole = StaffRoleTxt.Text;
            string StaffEmail = StaffEmailTxt.Text;

            string[] fields = { StaffUsername, StaffPassword, StaffRole, StaffEmail };      // Puts the variables into an array to check if any are empty

            foreach (string field in fields)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
            }

            try                                                                                       // Try statement catches any errors without crashing the program
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ACCOUNT (username, password, role, name, email) VALUES (@username, @password, @role, @name, @email)";   // SQL query to insert a record
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", StaffUsername);
                        command.Parameters.AddWithValue("@password", StaffPassword);
                        command.Parameters.AddWithValue("@role", StaffRole);
                        command.Parameters.AddWithValue("@name", StaffName);
                        command.Parameters.AddWithValue("@email", StaffEmail);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error saving product: " + error.Message);
            }

            
            StaffUsernameTxt.Text = "";
            StaffPasswordTxt.Text = "";
            StaffNameTxt.Text = "";
            StaffRoleTxt.Text = "";
            StaffEmailTxt.Text = "";   // Clears the text boxes 

            LoadStaffTable();
        }

        private void AddStaffBtn_Click(object sender, EventArgs e)
        {
            AddStaffPanel.Show();
        }

        private void StaffDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
