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
    public partial class Products : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public Products()
        {
            InitializeComponent();
            ProductsDataGridView.CellContentClick += ProductsDataGridView_CellContentClick;
            AddProductPanel.Hide();
            EditProductPanel.Hide();
            ProductsPanel.Show();
            LoadProductsTable();
        }

        private void LoadProductsTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM PRODUCT";                                      // Selects all of the data from the PRODUCT table

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection)) // Uses the data adapter to fill a DataTable with the results of the query
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);                                                     // Fill the DataTable with the data feched from the PRODUCT table

                    ProductsDataGridView.DataSource = table;                                 // Show results in DataGridView
                }

                if (!ProductsDataGridView.Columns.Contains("EditBtn"))
                {
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn(); // Creates a new button column
                    editButtonColumn.Name = "EditBtn";      // Properties of the column
                    editButtonColumn.HeaderText = "";
                    editButtonColumn.Text = "Edit Product";
                    editButtonColumn.UseColumnTextForButtonValue = true; // display the text
                    ProductsDataGridView.Columns.Add(editButtonColumn);
                }

            }
        }

        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "EditBtn" column
            if (ProductsDataGridView.Columns[e.ColumnIndex].Name == "EditBtn" && e.RowIndex >= 0)   // If the column is EditBtn and it is not a header
            {
                EditProductPanel.Show();

                string isActiveValue = ProductsDataGridView.Rows[e.RowIndex].Cells["is_active"].Value.ToString();  // Finds the is_active value of the selected row


                if (isActiveValue == "Active")          // Sets the checkbox to the corresponding on the is_active value
                {
                    is_activeCheckBox.Checked = true;
                }
                else
                {
                    is_activeCheckBox.Checked = false;

                }

            }
        }

        private void AddProductsBtn_Click_1(object sender, EventArgs e)
        {
            AddProductPanel.Show();
        }

        private void SaveProductBtn_Click_1(object sender, EventArgs e)
        {
            string ProductTitle = ProductTitleTxt.Text;
            string ProductBarcode = ProductBarcodeTxt.Text;                // Sets of the inputs to variables
            string ProductPrice = ProductPriceTxt.Text;
            string isActive = ProductStatusTxt.Text;

            string[] fields = { ProductTitle, ProductBarcode, ProductPrice, isActive };      // Puts the variables into an array to check if any are empty

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
                    string query = "INSERT INTO PRODUCT (title, barcode, price, is_active) VALUES (@title, @barcode, @price, @is_active)";   // SQL query to insert a record
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", ProductTitle);
                        command.Parameters.AddWithValue("@barcode", ProductBarcode);
                        command.Parameters.AddWithValue("@price", ProductPrice);
                        command.Parameters.AddWithValue("@is_active", isActive);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error saving product: " + error.Message);
            }


            ProductTitleTxt.Text = "";
            ProductBarcodeTxt.Text = "";
            ProductPriceTxt.Text = "";
            ProductStatusTxt.Text = "";   // Clears the text boxes 

            LoadProductsTable();
        }

        private void is_activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string productId = ProductsDataGridView.CurrentRow.Cells["product_id"].Value.ToString();

            string newStatus;
            if(is_activeCheckBox.Checked)
            {
                newStatus = "Active";
            }
            else
            {
                newStatus = "Inactive";
            }

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE PRODUCT SET is_active = @is_active WHERE product_id = @product_id";   // SQL query to update the is_active value
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@is_active", newStatus);     // Sets the newstatus based on the checkbox
                    command.Parameters.AddWithValue("@product_id", productId);    // Uses the product_id to update the correct record
                    command.ExecuteNonQuery();
                }
            }

            ProductsDataGridView.CurrentRow.Cells["is_active"].Value = newStatus; // Updates the DataGridView to show the new status
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
