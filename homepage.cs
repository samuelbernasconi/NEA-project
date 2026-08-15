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
    public partial class homepage : Form
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Samuel\NEA project\Files\RMSdatabase.db;Version=3;";

        private string Role;

        public homepage(string role)
        {
            InitializeComponent();
            Role = role;
            AccessLevel();
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)              // Remove any existing controls from the MainPanel
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;                              // Creates new instance of the form
            f.TopLevel = false;                                 // Sets properties of the form
            f.Dock = DockStyle.Fill;                            
            this.mainpanel.Controls.Add(f);                     // Add the form to the MainPanel
            this.mainpanel.Tag = f;
            f.Show();                                           
        }

        private void ProductsBtn_Click(object sender, EventArgs e)
        {


            loadform (new Products());   // Loads the Products form into the MainPanel


        }

        private void AccessLevel()
        {
            switch (Role)
            {
                case "Manager":
                    break;                        // Managers have full access

                case "Chef":                    
                    TablesBtn.Enabled = false;    // Disable access to Tables, Staff, and Reports
                    StaffBtn.Enabled = false; 
                    ReportsBtn.Enabled = false;
                    POSBtn.Enabled = false;
                    break;

                case "Waiter": 
                    KitchenBtn.Enabled = false;   // Disable access to Kitchen, Staff, and Reports
                    StaffBtn.Enabled = false;
                    ReportsBtn.Enabled = false;
                    break;
            }
        }



        private void KitchenBtn_Click(object sender, EventArgs e)
        {
            loadform (new Kitchen());

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TablesBtn_Click(object sender, EventArgs e)
        {
            loadform(new Tables());
        }

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            loadform(new Staff());
        }

        private void POSBtn_Click(object sender, EventArgs e)
        {
            new POS(Role).Show();
            this.Hide();
        }

        private void homepage_Load(object sender, EventArgs e)
        {

        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            loadform (new Reports());
        }
    }
}
