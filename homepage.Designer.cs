using System.Windows.Forms;

namespace NEA_project
{
    partial class homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SIdebarPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ReportsBtn = new System.Windows.Forms.Button();
            this.POSBtn = new System.Windows.Forms.Button();
            this.StaffBtn = new System.Windows.Forms.Button();
            this.KitchenBtn = new System.Windows.Forms.Button();
            this.TablesBtn = new System.Windows.Forms.Button();
            this.ProductsBtn = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.SIdebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SIdebarPanel
            // 
            this.SIdebarPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SIdebarPanel.Controls.Add(this.label3);
            this.SIdebarPanel.Controls.Add(this.ReportsBtn);
            this.SIdebarPanel.Controls.Add(this.POSBtn);
            this.SIdebarPanel.Controls.Add(this.StaffBtn);
            this.SIdebarPanel.Controls.Add(this.KitchenBtn);
            this.SIdebarPanel.Controls.Add(this.TablesBtn);
            this.SIdebarPanel.Controls.Add(this.ProductsBtn);
            this.SIdebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SIdebarPanel.Location = new System.Drawing.Point(0, 0);
            this.SIdebarPanel.Name = "SIdebarPanel";
            this.SIdebarPanel.Size = new System.Drawing.Size(398, 1044);
            this.SIdebarPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "Il Ristorante Italiano";
            // 
            // ReportsBtn
            // 
            this.ReportsBtn.Location = new System.Drawing.Point(42, 702);
            this.ReportsBtn.Name = "ReportsBtn";
            this.ReportsBtn.Size = new System.Drawing.Size(308, 85);
            this.ReportsBtn.TabIndex = 5;
            this.ReportsBtn.Text = "Reports";
            this.ReportsBtn.UseVisualStyleBackColor = true;
            this.ReportsBtn.Click += new System.EventHandler(this.ReportsBtn_Click);
            // 
            // POSBtn
            // 
            this.POSBtn.Location = new System.Drawing.Point(42, 571);
            this.POSBtn.Name = "POSBtn";
            this.POSBtn.Size = new System.Drawing.Size(308, 85);
            this.POSBtn.TabIndex = 4;
            this.POSBtn.Text = "POS";
            this.POSBtn.UseVisualStyleBackColor = true;
            this.POSBtn.Click += new System.EventHandler(this.POSBtn_Click);
            // 
            // StaffBtn
            // 
            this.StaffBtn.Location = new System.Drawing.Point(42, 440);
            this.StaffBtn.Name = "StaffBtn";
            this.StaffBtn.Size = new System.Drawing.Size(308, 85);
            this.StaffBtn.TabIndex = 3;
            this.StaffBtn.Text = "Staff";
            this.StaffBtn.UseVisualStyleBackColor = true;
            this.StaffBtn.Click += new System.EventHandler(this.StaffBtn_Click);
            // 
            // KitchenBtn
            // 
            this.KitchenBtn.Location = new System.Drawing.Point(42, 832);
            this.KitchenBtn.Name = "KitchenBtn";
            this.KitchenBtn.Size = new System.Drawing.Size(308, 85);
            this.KitchenBtn.TabIndex = 2;
            this.KitchenBtn.Text = "Kitchen";
            this.KitchenBtn.UseVisualStyleBackColor = true;
            this.KitchenBtn.Click += new System.EventHandler(this.KitchenBtn_Click);
            // 
            // TablesBtn
            // 
            this.TablesBtn.Location = new System.Drawing.Point(42, 309);
            this.TablesBtn.Name = "TablesBtn";
            this.TablesBtn.Size = new System.Drawing.Size(308, 85);
            this.TablesBtn.TabIndex = 1;
            this.TablesBtn.Text = "Tables";
            this.TablesBtn.UseVisualStyleBackColor = true;
            this.TablesBtn.Click += new System.EventHandler(this.TablesBtn_Click);
            // 
            // ProductsBtn
            // 
            this.ProductsBtn.Location = new System.Drawing.Point(42, 178);
            this.ProductsBtn.Name = "ProductsBtn";
            this.ProductsBtn.Size = new System.Drawing.Size(308, 85);
            this.ProductsBtn.TabIndex = 0;
            this.ProductsBtn.Text = "Products";
            this.ProductsBtn.UseVisualStyleBackColor = true;
            this.ProductsBtn.Click += new System.EventHandler(this.ProductsBtn_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(398, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1580, 1044);
            this.mainpanel.TabIndex = 5;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            // 
            // homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1978, 1044);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.SIdebarPanel);
            this.Name = "homepage";
            this.Text = "homepage";
            this.Load += new System.EventHandler(this.homepage_Load);
            this.SIdebarPanel.ResumeLayout(false);
            this.SIdebarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SIdebarPanel;
        private System.Windows.Forms.Button ReportsBtn;
        private System.Windows.Forms.Button POSBtn;
        private System.Windows.Forms.Button StaffBtn;
        private System.Windows.Forms.Button KitchenBtn;
        private System.Windows.Forms.Button TablesBtn;
        private System.Windows.Forms.Button ProductsBtn;
        private System.Windows.Forms.Label label3;
        private Panel mainpanel;
    }
}