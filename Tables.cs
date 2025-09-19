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
    public partial class Tables : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public Tables()
        {
            InitializeComponent();
            LoadSeating();
        }

        private void Tables_Load(object sender, EventArgs e)
        {

        }
        private void tableButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;               // Casts the sender as a button
            int tableId = (int)btn.Tag;                // Stores the tableId an integer
            MessageBox.Show("TableID: " + tableId);   
        }


        private void LoadSeating()
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT table_id, table_number,status FROM SEATING";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int x = 20, y = 40;
                    int count = 0;          

                    while (reader.Read())
                    {
                        int tableId = reader.GetInt32(0);   // Gets table_id from first column
                        int tableNumber = reader.GetInt32(1);  // Gets table_number from second column
                        string status = reader.GetString(2); // Gets status from third column
                       

                        Button tableButton = new Button
                        {
                            Text = "Table" + tableNumber,
                            Size = new Size(200, 120),
                            Location = new Point(x, y),    // Sets properties of the button
                            Tag = tableId                  // Stores the table_id
                        };

                        
                        switch (status)
                        {
                            case "Available":
                                tableButton.BackColor = Color.LightGreen;
                                break;
                            case "Occupied":
                                tableButton.BackColor = Color.LightCoral;
                                break;
                            case "Reserved":
                                tableButton.BackColor = Color.Khaki;
                                break;
                        }

                        tableButton.Click += tableButton_Click;   // Attatches the button click to method tableButton_click
                        this.Controls.Add(tableButton);           // Adds the button to the form

                        // Layout: arrange buttons in a grid
                        x += 240;
                        count++;
                        if (count % 4 == 0) // move to next row after 4 buttons
                        {
                            x = 20;
                            y += 160;
                        }
                    }
                }
            }
        }
    }
}
