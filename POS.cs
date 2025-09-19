using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_project
{
    public partial class POS : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public POS()
        {
            InitializeComponent();
            CurrentOrdersetup();
            currentorderDataGridView.CellContentClick += currentorderDataGridView_CellContentClick;
        }

        private void POS_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadTables();
         
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;               // Casts the sender as a button

            (int productId, string productName, int barcode, decimal price, string isActive) // Gets values from the button tag
            = ((int, string, int, decimal, string))btn.Tag;


            foreach (DataGridViewRow row in currentorderDataGridView.Rows)
            {
                if ((int)row.Cells["ProductID"].Value == productId)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value) + 1;
                    row.Cells["Quantity"].Value = qty;
                    UpdateOrderTotal();
                    return;
                }
            }

            currentorderDataGridView.Rows.Add(productId, productName, 1, price);
            UpdateOrderTotal();

        }

        /*

          if (!currentorderDataGridView.Columns.Contains("DeleteBtn"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn(); // Creates a new button column
        deleteButtonColumn.Name = "DeleteBtn";      // Properties of the button column
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.FillWeight = 10;
                currentorderDataGridView.Columns.Add(deleteButtonColumn);
            }

           */

        private void currentorderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "EditBtn" column
            if (currentorderDataGridView.Columns[e.ColumnIndex].Name == "DeleteBtn" && e.RowIndex >= 0)   // If the column is EditBtn and it is not a header
            {

                DataGridViewRow row = currentorderDataGridView.Rows[e.RowIndex];
                int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);

                if (currentQty > 1)
                {
                    row.Cells["Quantity"].Value = currentQty - 1;
                }
                else
                {
                    currentorderDataGridView.Rows.RemoveAt(e.RowIndex);
                }

                UpdateOrderTotal();
            }
        }


        private void UpdateOrderTotal()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in currentorderDataGridView.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                sum += qty * price;
            }

            orderTotalLabel.Text = "Total:" + sum.ToString("0.00");

        }

        private void LoadProducts()
        {

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT product_id, title,barcode, price, is_active FROM PRODUCT";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int product_id = reader.GetInt32(0);   // Gets properties from each column
                        string title = reader.GetString(1);
                        int barcode = reader.GetInt32(2);
                        decimal price = reader.GetDecimal(3);
                        string isActive = reader.GetString(4);


                        Button ProductButton = new Button
                        {
                            Text = title,
                            Size = new Size(150, 100),
                            Tag = (product_id, title, barcode, price, isActive)  // Sets properties of the button in a tuple

                        };

                        ProductButton.Click += ProductButton_Click;
                        this.Controls.Add(ProductButton);           // Adds the button to the form

                        ProductsFlowPanel.Controls.Add(ProductButton);
                    }
                }


            }
        }

        private void LoadTables()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT table_id, table_number FROM SEATING";  // Gets only available tables

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    DataTable tableData = new DataTable();  // Stores the data from the query
                    tableData.Load(reader);                 // Loads this data into the DataTable

                    TableComboBox.DataSource = tableData;         // Sets the DataTable as the data source for the ComboBox
                    TableComboBox.DisplayMember = "table_number";
                    TableComboBox.ValueMember = "table_id";
                }

            }
        }

        private void CurrentOrdersetup()

        {
            currentorderDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            currentorderDataGridView.RowTemplate.Height = 30;
            currentorderDataGridView.Columns.Clear();
            currentorderDataGridView.Columns.Add("ProductID", "ID");
            currentorderDataGridView.Columns.Add("ProductName", "Product");
            currentorderDataGridView.Columns.Add("Quantity", "Qty");
            currentorderDataGridView.Columns.Add("Price", "Price");

            currentorderDataGridView.Columns["ProductID"].FillWeight = 15;
            currentorderDataGridView.Columns["ProductName"].FillWeight = 45;
            currentorderDataGridView.Columns["Quantity"].FillWeight = 15;
            currentorderDataGridView.Columns["Price"].FillWeight = 25;
        }

        private void TableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            //           int selectedTableId = Convert.ToInt32(TableComboBox.SelectedValue);  put this in save button


        }

        private void SaveOrder_Click(object sender, EventArgs e)
        {

            int selectedTableId = Convert.ToInt32(TableComboBox.SelectedValue);
            int orderId;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    try
                    {

                        cmd.CommandText = "INSERT INTO ORDER_DETAILS (table_id, status) VALUES (@table_id, @status);";  // Insert new order into ORDER_DETAILS
                        cmd.Parameters.AddWithValue("@table_id", selectedTableId);
                        cmd.Parameters.AddWithValue("@status", "Open");
                        cmd.ExecuteNonQuery();
    
                        cmd.CommandText = "SELECT last_insert_rowid();";        // Get the order_id of the newly created order
                        orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (DataGridViewRow row in currentorderDataGridView.Rows)  // Iterates through each row in the DataGridView and inserts into ORDER_ITEMS
                        {
                            if (!row.IsNewRow) // skip the blank row at the bottom
                            {
                                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                                cmd.CommandText = "INSERT INTO ORDER_ITEMS (order_id, product_id, quantity) VALUES (@order_id, @product_id, @quantity);";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@order_id", orderId);
                                cmd.Parameters.AddWithValue("@product_id", productId);
                                cmd.Parameters.AddWithValue("@quantity", quantity);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        
                        cmd.CommandText = "UPDATE SEATING SET status = 'Occupied' WHERE table_id = @table_id;";   // Update table status
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@table_id", selectedTableId);
                        cmd.ExecuteNonQuery();

                      
                        transaction.Commit();

                        
                        currentorderDataGridView.Rows.Clear();
                        LoadTables(); 
                    } 
                    catch (Exception ex)                  // If any error occurs transaction is rolled back and error message is displayed
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving order: " + ex.Message);  
                    }
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            homepage homepage = new homepage(); 
            homepage.Show();
        }
    }
}