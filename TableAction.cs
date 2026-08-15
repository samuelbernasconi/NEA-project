using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NEA_project
{
    public partial class TableAction : Form
    {
        public int TableId { get; private set; }
        private int currentBillId = -1;

        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public TableAction(int tableId, string tableNumber)
        {
            InitializeComponent();
            TableId = tableId;
            label1.Text = tableNumber;
        }

        private void TableAction_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateBillBtn_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.Transaction = transaction;
                    try
                    {                        
                        cmd.CommandText = @"
                            SELECT order_id                     
                            FROM ORDER_DETAILS 
                            WHERE table_id=@table_id 
                            AND status IN ('Open','Completed');"; // Selects all open or completed orders 
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@table_id", TableId); // Adds table ID parameter

                        List<int> openOrders = new List<int>();   // Creates a list to hold all open orders
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                openOrders.Add(reader.GetInt32(0));     
                        }

                        if (openOrders.Count == 0)
                        {
                            MessageBox.Show("No open orders for this table.");
                            return;
                        }

                      
                        decimal total = 0;
                        foreach (int orderId in openOrders)
                        {
                            cmd.CommandText = @"
                                SELECT SUM(ORDER_ITEMS.quantity * PRODUCT.price)
                                FROM ORDER_ITEMS
                                JOIN PRODUCT ON ORDER_ITEMS.product_id = PRODUCT.product_id
                                WHERE ORDER_ITEMS.order_id=@order_id;";   // Calculates total for each order
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            object result = cmd.ExecuteScalar();
                            if (result != DBNull.Value && result != null)
                                total += Convert.ToDecimal(result);
                        }


                        string NewDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.CommandText = "INSERT INTO BILL (total, status, bill_datetime) VALUES (@total, 'Open', @bill_datetime);";  // Inserts new field into BILL table
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@bill_datetime", NewDateTime);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";  // Gets the ID of new bill
                        currentBillId = Convert.ToInt32(cmd.ExecuteScalar());
                        
                        foreach (int orderId in openOrders)  // Links each open order to the new bill and closes the order
                        {
                            cmd.CommandText = "INSERT INTO ORDER_BILL (bill_id, order_id) VALUES (@bill_id, @order_id);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@bill_id", currentBillId);
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "UPDATE ORDER_DETAILS SET status='Closed' WHERE order_id=@order_id;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Bill "+ currentBillId + " generated successfully! Total: " + total);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error generating bill: " + ex.Message);
                    }
                }
            }
        }

        private void BillPaidBtn_Click(object sender, EventArgs e)
        {
            if (currentBillId == -1)
            {
                MessageBox.Show("No bill selected.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.Transaction = transaction;
                    try
                    {
                        
                        cmd.CommandText = "UPDATE BILL SET status='Paid' WHERE bill_id=@bill_id;"; // Marks bill as paid
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@bill_id", currentBillId);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE SEATING SET status='Available' WHERE table_id=@table_id;"; // Marks table as available
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@table_id", TableId);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Bill" + currentBillId + "marked as Paid.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating bill: " + ex.Message);
                    }
                }
            }
        }

        
        private void BillCancelledBtn_Click(object sender, EventArgs e)
        {
            if (currentBillId == -1)
            {
                MessageBox.Show("No bill selected.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText = "UPDATE BILL SET status='Cancelled' WHERE bill_id=@bill_id;";  // Marks bill as cancelled
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@bill_id", currentBillId);
                        cmd.ExecuteNonQuery();

                     
                        cmd.CommandText = @"
                            UPDATE ORDER_DETAILS
                            SET status='Open'
                            WHERE order_id IN (
                            SELECT order_id FROM ORDER_BILL WHERE bill_id=@bill_id
                            );";                                                   // Reopens all orders linked to the cancelled bill
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@bill_id", currentBillId);
                        cmd.ExecuteNonQuery();
                    
                        transaction.Commit();
                        MessageBox.Show("Bill"+ currentBillId + "cancelled and table is now Available.");
                      
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error cancelling bill: " + ex.Message);
                    }
                }
            }
        }

        private void ViewOrdersBtn_Click(object sender, EventArgs e)
        {
            Orders ordersForm = new Orders(TableId);
            ordersForm.Show();
        }
    }
}
