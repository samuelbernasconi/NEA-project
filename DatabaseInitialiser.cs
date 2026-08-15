using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;  // The NuGet package which was installed
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace NEA_project
{
    public static class DatabaseInitialiser
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";  // This creates the connection string from the 
                                                                                                                                       // program to the file location on my computer
        public static void InitialiseDatabase()
        
        {
            if (!File.Exists(@"C:\Users\Samuel\NEA project\Files\RMSdatabase.db"))                                                     // Checks if the file exists before writing to it
            {
                SQLiteConnection.CreateFile(@"C:\Users\Samuel\NEA project\Files\RMSdatabase.db");
                
            }

                using (var connection = new SQLiteConnection(ConnectionString))                                                             
                {
                connection.Open();

                
                string CreateUserTableQuery = @"                                                                                        

                     CREATE TABLE IF NOT EXISTS ACCOUNT (
                     user_id INTEGER PRIMARY KEY AUTOINCREMENT,
                     username TEXT NOT NULL,
                     password TEXT NOT NULL, 
                     role NOT NULL CHECK (role IN ('Waiter', 'Chef', 'Manager')),
                     name TEXT NOT NULL, 
                     email TEXT NOT NULL,
                     must_change_password INTEGER DEFAULT 1
                     );";                                                                                                               // Creates the ACCOUNT table

                string CreateProductTableQuery = @"                                                                                        

                     CREATE TABLE IF NOT EXISTS PRODUCT (
                     product_id INTEGER PRIMARY KEY AUTOINCREMENT,
                     title TEXT NOT NULL,
                     barcode INTEGER NOT NULL UNIQUE, 
                     price TEXT NOT NULL, 
                     is_active TEXT NOT NULL CHECK (is_active IN ('Active','Inactive'))
                     );";

                string CreateIngredientTableQuery = @"
                     CREATE TABLE IF NOT EXISTS INGREDIENT (
                     ingredient_id INTEGER PRIMARY KEY AUTOINCREMENT,
                     ingredient_name TEXT NOT NULL,
                     stock_level REAL NOT NULL,
                     unit TEXT NOT NULL
                     );";

                string CreateRecipeTableQuery = @"
                     CREATE TABLE IF NOT EXISTS RECIPE (
                     recipe_id INTEGER PRIMARY KEY AUTOINCREMENT,
                     product_id INTEGER NOT NULL,
                     ingredient_id INTEGER NOT NULL,
                     quantity_required REAL NOT NULL,
                     FOREIGN KEY (product_id) REFERENCES PRODUCT(product_id),
                     FOREIGN KEY (ingredient_id) REFERENCES INGREDIENT(ingredient_id)
                     );";

                string CreateSeatingTableQuery = @"     

                     CREATE TABLE IF NOT EXISTS SEATING (   
                     table_id INTEGER PRIMARY KEY AUTOINCREMENT,
                     table_number INTEGER NOT NULL UNIQUE,
                     status TEXT NOT NULL CHECK (status IN ('Available', 'Occupied', 'Reserved'))
                     );";

                string CreateOrderItemsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ORDER_ITEMS (
                    order_item_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    order_id INTEGER NOT NULL,
                    product_id INTEGER NOT NULL,
                    quantity INTEGER NOT NULL,
                    FOREIGN KEY (order_id) REFERENCES ORDER_DETAILS(order_id),
                    FOREIGN KEY (product_id) REFERENCES PRODUCT(product_id)
                    );";

                string CreateOrderTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ORDER_DETAILS (
                    order_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    table_id INTEGER NOT NULL,
                    status TEXT NOT NULL CHECK (status IN ('Open', 'Closed', 'Cancelled', 'Completed')),
                    order_datetime DATETIME NOT NULL,   
                    allergens TEXT DEFAULT 'NULL',
                    FOREIGN KEY (table_id) REFERENCES SEATING(table_id)                   
                    );";

                string CreateBillTableQuery = @"
                    CREATE TABLE IF NOT EXISTS BILL (
                    bill_id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    total REAL NOT NULL,
                    status TEXT NOT NULL DEFAULT 'Open',
                    bill_datetime TEXT DEFUALT 'NULL'
                    );";

                string createBillTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS ORDER_BILL (
                    bill_id INTEGER NOT NULL,
                    order_id INTEGER NOT NULL,
                    FOREIGN KEY (bill_id) REFERENCES BILL(bill_id),
                    FOREIGN KEY (order_id) REFERENCES ORDER_DETAILS(order_id)
                    );";




                using (var command = new SQLiteCommand(connection))    // Runs the query
                    {
                        command.CommandText = CreateIngredientTableQuery;
                        command.ExecuteNonQuery();
                        
                        command.CommandText = CreateRecipeTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateUserTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateProductTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateSeatingTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateOrderItemsTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateOrderTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = CreateBillTableQuery;
                        command.ExecuteNonQuery();
                      
                        command.CommandText = createBillTablesQuery;    
                        command.ExecuteNonQuery();
                }

                  

                }
                


            

           


        }
    }
}
