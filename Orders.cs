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
    public partial class Orders : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";
        private int TableId;

        public Orders(int tableId)
        {
            InitializeComponent();
            
            OrdersDataGridView.Dock = DockStyle.Fill;
            OrdersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TableId = tableId;
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                SELECT 
                ORDER_DETAILS.order_id,
                PRODUCT.title AS product_name,
                ORDER_ITEMS.quantity,
                PRODUCT.price,
                ORDER_DETAILS.status
                FROM ORDER_DETAILS
                JOIN ORDER_ITEMS ON ORDER_DETAILS.order_id = ORDER_ITEMS.order_id
                JOIN PRODUCT ON ORDER_ITEMS.product_id = PRODUCT.product_id
                WHERE ORDER_DETAILS.table_id = @table_id
                AND ORDER_DETAILS.status = 'Open';";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@table_id", TableId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    OrdersDataGridView.DataSource = table;
                }
            }          
        }
    

        private void OrdersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
