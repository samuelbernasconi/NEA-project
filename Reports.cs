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
    public partial class Reports : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void RetrieveBillsBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Value.Date;   
            DateTime endDate = EndDatePicker.Value;          // .AddDays(1).AddSeconds(-1); 

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                    SELECT bill_id, total, status, bill_datetime
                    FROM BILL
                    WHERE bill_datetime BETWEEN @startDate AND @endDate
                    ;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd HH:mm:ss"));  // Format to mach the database
                    command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss"));


                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))  // Fills the DataGridView
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BillsDataGridView.DataSource = table;
                    }
                }
            }
         
        }


    }
}

