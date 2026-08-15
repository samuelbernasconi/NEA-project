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
    public partial class Ingredients : Form
    {
        private int _productId;
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        public Ingredients(int productId)

        {       

            InitializeComponent();

            IngredientsDataGridView.Dock = DockStyle.Fill;
            IngredientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Size = new Size(600, 250);


            _productId = productId;
            this.Load += Ingredients_Load;
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                SELECT INGREDIENT.ingredient_name, RECIPE.quantity_required, INGREDIENT.unit
                FROM RECIPE
                JOIN INGREDIENT ON RECIPE.ingredient_id = INGREDIENT.ingredient_id
                WHERE RECIPE.product_id = @product_id;";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@product_id", _productId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    IngredientsDataGridView.DataSource = table;
                }
            }
        }

        private void IngredientsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
        }
    }


}
