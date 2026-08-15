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

        private readonly string Role;
        public POS(string Role)
        {
            InitializeComponent();
            CurrentOrdersetup();
            currentorderDataGridView.CellContentClick += currentorderDataGridView_CellContentClick;
        }

        private void POS_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadAllergens();
            LoadTables();
         
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var (productId, productName, barcode, price, isActive) = ((int, string, int, decimal, string))btn.Tag;

            List<string> selectedAllergens = AllergenCheckedListBox.CheckedItems.Cast<string>().ToList(); // Stored selected allergens in a list
            if (selectedAllergens.Count > 0)
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT INGREDIENT.ingredient_name
                    FROM RECIPE
                    JOIN INGREDIENT ON RECIPE.ingredient_id = INGREDIENT.ingredient_id
                    WHERE RECIPE.product_id = @product_id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        List<string> allergensInProduct = new List<string>();  // Stores allergents found in the product in a list

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string ingredient = reader.GetString(0);       // Gets ingredient name
                                if (selectedAllergens.Contains(ingredient))    // Checks if ingredient is in the selected allergens list
                                    allergensInProduct.Add(ingredient);        // Adds allergen to the allergensInProduct list
                            }
                        }

                        if (allergensInProduct.Count > 0)
                        {
                            string allergenList = string.Join(", ", allergensInProduct);
                            DialogResult result = MessageBox.Show(
                                "Warning! This product contains the following allergens: "+ allergenList +". Continue?",
                                "Allergen Warning",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                            );
                            if (result == DialogResult.No) return; // stop adding
                        }
                    }
                }
            }

            
            foreach (DataGridViewRow row in currentorderDataGridView.Rows)
            {
                if (!row.IsNewRow && Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value) + 1;
                    row.Cells["Quantity"].Value = qty;
                    UpdateOrderTotal();
                    return;
                }
            }

            // 3) Product not found — add as new row
            currentorderDataGridView.Rows.Add(productId, productName, 1, price);
            UpdateOrderTotal();
        }


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

         //int selectedTableId = Convert.ToInt32(TableComboBox.SelectedValue);  put this in save button


        }

        private void SaveOrder_Click(object sender, EventArgs e)
        {

            int selectedTableId = Convert.ToInt32(TableComboBox.SelectedValue);
            int orderId;

            List<string> selectedAllergens = AllergenCheckedListBox.CheckedItems.Cast<string>().ToList();  // Creates a list of selected allergens 

            string allergensStr;

            if (selectedAllergens.Count > 0)
            {
                allergensStr = string.Join(", ", selectedAllergens); // Joins all allergens separated by commas
            }
            else
            {
                allergensStr = "NULL"; // No allergens 
            }

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    try
                    {

                        cmd.CommandText = "INSERT INTO ORDER_DETAILS (table_id, status, order_datetime, allergens) VALUES (@table_id, @status, @order_datetime, @allergens);";  // Insert new order into ORDER_DETAILS
                        cmd.Parameters.AddWithValue("@table_id", selectedTableId);
                        cmd.Parameters.AddWithValue("@status", "Open");
                        cmd.Parameters.AddWithValue("@order_datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Adds current date and time
                        cmd.Parameters.AddWithValue("@allergens", allergensStr);
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

                                DeductIngredients(connection, productId, quantity);
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
            homepage homepage = new homepage(Role); 
            homepage.Show();
        }

        private void DeductIngredients(SQLiteConnection connection, int productId, int orderQuantity)  // Takes in the connection, productId and order quantity as parameters
        {
            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ingredient_id, quantity_required FROM RECIPE WHERE product_id = @product_id;";  // Selects all ingredients and quantities required for the given product
                cmd.Parameters.AddWithValue("@product_id", productId);                                                    // Adds productId as a parameter

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ingredientId = reader.GetInt32(0);             // Gets ingredient ID
                        decimal quantityRequired = reader.GetDecimal(1);   // Gets quantity required per product

                        decimal totalDeduction = quantityRequired * orderQuantity; // Calculates total deduction based on order quantity by doing quantity required * order quantity

                        using (SQLiteCommand updateCmd = new SQLiteCommand(connection))
                        {
                            updateCmd.CommandText = "UPDATE INGREDIENT SET stock_level = stock_level - @deduction WHERE ingredient_id = @ingredient_id;"; 
                            updateCmd.Parameters.AddWithValue("@deduction", totalDeduction);  // Adds total deduction as a parameter
                            updateCmd.Parameters.AddWithValue("@ingredient_id", ingredientId);// Adds ingredient ID as a parameter
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void LoadAllergens()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ingredient_name FROM INGREDIENT";         // Gets all ingredient names 
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllergenCheckedListBox.Items.Add(reader.GetString(0));   // Adds each ingredient name to the CheckedListBox
                    }
                }
            }
        }





    }
}