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
    public partial class Kitchen : Form
    {
        
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public Kitchen()
        {
            InitializeComponent();
            LoadKitchenOrders();

        }

        private void KitchenFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CompleteOrder_Click(object sender, EventArgs e)
        {
            int orderId = (int)((Button)sender).Tag;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "UPDATE ORDER_DETAILS SET status = 'Completed' WHERE order_id = @order_id;";  // Sets the order status to completed
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.ExecuteNonQuery();
                }
                string setTableStatus = "UPDATE SEATING SET status = 'Available';";

                using (var cmd = new SQLiteCommand(setTableStatus, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            
            MessageBox.Show("Order" + orderId + " completed.");  
            LoadKitchenOrders(); // refresh the display 
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            int orderId = (int)((Button)sender).Tag;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "UPDATE ORDER_DETAILS SET status = 'Cancelled' WHERE order_id = @order_id;"; // Sets the order status to cancelled
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.ExecuteNonQuery();
                }
                string setTableStatus = "UPDATE SEATING SET status = 'Available';";

                using (var cmd = new SQLiteCommand(setTableStatus, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Order" + orderId + " cancelled.");
            LoadKitchenOrders(); // Refreshes the display

        }

        private void LoadKitchenOrders()
        {
            KitchenFlowPanel.Controls.Clear();

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query =

                @"
                SELECT ORDER_DETAILS.order_id, 
                PRODUCT.title, 
                ORDER_ITEMS.quantity,
                ORDER_DETAILS.order_datetime,
                ORDER_DETAILS.allergens
                FROM ORDER_DETAILS
                JOIN ORDER_ITEMS ON ORDER_DETAILS.order_id = ORDER_ITEMS.order_id
                JOIN PRODUCT ON ORDER_ITEMS.product_id = PRODUCT.product_id
                WHERE ORDER_DETAILS.status = 'Open'
                ORDER BY ORDER_DETAILS.order_id;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    var orders = new Dictionary<int, (DateTime OrderDateTime, string Allergens, List<(string product, int quantity)> items)>();                    // Stores order items grouped by order_id

                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(0);        // Gets properties
                        string product = reader.GetString(1);
                        int quantity = reader.GetInt32(2);
                        string OrderDateTimeStr = reader.GetString(3);
                        DateTime OrderDateTime = DateTime.Parse(OrderDateTimeStr);
                        string Allergens = reader.GetString(4);

                        if (!orders.ContainsKey(orderId))
                            orders[orderId] = (OrderDateTime, Allergens, new List<(string product, int quantity)>());

                        orders[orderId].items.Add((product, quantity));
                    }

                   
                    foreach (var orderEntry in orders)               
                    {
                        int orderId = orderEntry.Key;
                        var orderData = orderEntry.Value;                 // orderData is a tuple (DateTime, List<...>)
                        DateTime orderDateTime = orderData.OrderDateTime; // extract the datetime
                        List<(string product, int quantity)> items = orderData.items;  // extract the list of items

                        Panel orderPanel = new Panel          // Creates a new panel for each order
                        {
                            Size = new Size(300, 200),
                            BorderStyle = BorderStyle.FixedSingle,   // Properties of the panel
                            Margin = new Padding(10)
                        };

                        Label OrderTitlelbl = new Label                    // Order title label
                        {
                            Text = "Order #" + orderId,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),              
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(OrderTitlelbl);

                        Label OrderDateTimeLbl = new Label
                        {
                            Text = "Time: " + orderDateTime.ToString("yyyy-MM-dd HH:mm"),
                            Location = new Point(100,0),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold)
                        };
                        orderPanel.Controls.Add(OrderDateTimeLbl);

                        Label AllergensLbl = new Label
                        {
                            Text = "Allergens: " + orderData.Allergens,
                            Location = new Point(0, 17), 
                            AutoSize = true,
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            ForeColor = Color.Red 
                        };
                        orderPanel.Controls.Add(AllergensLbl);



                        int y = 40;
                        foreach (var item in items)
                        {
                            Label lblItem = new Label
                            {
                                Text = item.product + " - " + item.quantity,   // Formats the order items and quantities in the panel
                                Location = new Point(10, y),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblItem);
                            y += 25;
                        }

                       
                        Button btnComplete = new Button
                        {
                            Text = "Complete Order",
                            Size = new Size(120, 30),
                            Location = new Point(10, orderPanel.Height - 40),      // Properties of the button
                            Tag = orderId
                        };
                        btnComplete.Click += CompleteOrder_Click;
                        orderPanel.Controls.Add(btnComplete);

                       
                        Button btnCancel = new Button
                        {
                            Text = "Cancel Order",
                            Size = new Size(120, 30),
                            Location = new Point(140, orderPanel.Height - 40),     // Properties of the button
                            Tag = orderId
                        };

                        btnCancel.Click += CancelOrder_Click;  // Attaches the click event to the a method
                        orderPanel.Controls.Add(btnCancel);

                        KitchenFlowPanel.Controls.Add(orderPanel); // Adds the panel to the flow panel
                    }


                }
            }
        }

    }
}
