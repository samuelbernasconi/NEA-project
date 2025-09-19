namespace NEA_project
{
    partial class Products
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
            this.ProductsPanel = new System.Windows.Forms.Panel();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddProductsBtn = new System.Windows.Forms.Button();
            this.AddProductPanel = new System.Windows.Forms.Panel();
            this.SaveProductBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProductStatusTxt = new System.Windows.Forms.TextBox();
            this.ProductPriceTxt = new System.Windows.Forms.TextBox();
            this.ProductBarcodeTxt = new System.Windows.Forms.TextBox();
            this.ProductTitleTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EditProductPanel = new System.Windows.Forms.Panel();
            this.is_activeCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.AddProductPanel.SuspendLayout();
            this.EditProductPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductsPanel
            // 
            this.ProductsPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ProductsPanel.Controls.Add(this.ProductsDataGridView);
            this.ProductsPanel.Controls.Add(this.panel2);
            this.ProductsPanel.Controls.Add(this.AddProductPanel);
            this.ProductsPanel.Controls.Add(this.EditProductPanel);
            this.ProductsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductsPanel.Name = "ProductsPanel";
            this.ProductsPanel.Size = new System.Drawing.Size(1612, 1231);
            this.ProductsPanel.TabIndex = 2;
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.AllowUserToAddRows = false;
            this.ProductsDataGridView.AllowUserToDeleteRows = false;
            this.ProductsDataGridView.AllowUserToResizeColumns = false;
            this.ProductsDataGridView.AllowUserToResizeRows = false;
            this.ProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.ProductsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Location = new System.Drawing.Point(26, 89);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.ReadOnly = true;
            this.ProductsDataGridView.RowHeadersVisible = false;
            this.ProductsDataGridView.RowHeadersWidth = 90;
            this.ProductsDataGridView.RowTemplate.Height = 28;
            this.ProductsDataGridView.Size = new System.Drawing.Size(1100, 950);
            this.ProductsDataGridView.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.AddProductsBtn);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1605, 65);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1500, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products";
            // 
            // AddProductsBtn
            // 
            this.AddProductsBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.AddProductsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProductsBtn.FlatAppearance.BorderSize = 0;
            this.AddProductsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductsBtn.Location = new System.Drawing.Point(16, 3);
            this.AddProductsBtn.Name = "AddProductsBtn";
            this.AddProductsBtn.Size = new System.Drawing.Size(58, 68);
            this.AddProductsBtn.TabIndex = 1;
            this.AddProductsBtn.Text = "+";
            this.AddProductsBtn.UseVisualStyleBackColor = false;
            this.AddProductsBtn.Click += new System.EventHandler(this.AddProductsBtn_Click_1);
            // 
            // AddProductPanel
            // 
            this.AddProductPanel.Controls.Add(this.SaveProductBtn);
            this.AddProductPanel.Controls.Add(this.label8);
            this.AddProductPanel.Controls.Add(this.label7);
            this.AddProductPanel.Controls.Add(this.label6);
            this.AddProductPanel.Controls.Add(this.label5);
            this.AddProductPanel.Controls.Add(this.ProductStatusTxt);
            this.AddProductPanel.Controls.Add(this.ProductPriceTxt);
            this.AddProductPanel.Controls.Add(this.ProductBarcodeTxt);
            this.AddProductPanel.Controls.Add(this.ProductTitleTxt);
            this.AddProductPanel.Controls.Add(this.label4);
            this.AddProductPanel.Location = new System.Drawing.Point(1178, 297);
            this.AddProductPanel.Name = "AddProductPanel";
            this.AddProductPanel.Size = new System.Drawing.Size(418, 500);
            this.AddProductPanel.TabIndex = 4;
            // 
            // SaveProductBtn
            // 
            this.SaveProductBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveProductBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveProductBtn.FlatAppearance.BorderSize = 0;
            this.SaveProductBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveProductBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveProductBtn.Location = new System.Drawing.Point(278, 342);
            this.SaveProductBtn.Name = "SaveProductBtn";
            this.SaveProductBtn.Size = new System.Drawing.Size(134, 49);
            this.SaveProductBtn.TabIndex = 2;
            this.SaveProductBtn.Text = "Save";
            this.SaveProductBtn.UseVisualStyleBackColor = false;
            this.SaveProductBtn.Click += new System.EventHandler(this.SaveProductBtn_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 29);
            this.label8.TabIndex = 10;
            this.label8.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Barcode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Title";
            // 
            // ProductStatusTxt
            // 
            this.ProductStatusTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductStatusTxt.Location = new System.Drawing.Point(195, 294);
            this.ProductStatusTxt.Multiline = true;
            this.ProductStatusTxt.Name = "ProductStatusTxt";
            this.ProductStatusTxt.Size = new System.Drawing.Size(216, 42);
            this.ProductStatusTxt.TabIndex = 6;
            // 
            // ProductPriceTxt
            // 
            this.ProductPriceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPriceTxt.Location = new System.Drawing.Point(195, 218);
            this.ProductPriceTxt.Multiline = true;
            this.ProductPriceTxt.Name = "ProductPriceTxt";
            this.ProductPriceTxt.Size = new System.Drawing.Size(216, 44);
            this.ProductPriceTxt.TabIndex = 5;
            // 
            // ProductBarcodeTxt
            // 
            this.ProductBarcodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeTxt.Location = new System.Drawing.Point(195, 149);
            this.ProductBarcodeTxt.Multiline = true;
            this.ProductBarcodeTxt.Name = "ProductBarcodeTxt";
            this.ProductBarcodeTxt.Size = new System.Drawing.Size(216, 39);
            this.ProductBarcodeTxt.TabIndex = 4;
            // 
            // ProductTitleTxt
            // 
            this.ProductTitleTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTitleTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProductTitleTxt.Location = new System.Drawing.Point(195, 74);
            this.ProductTitleTxt.Multiline = true;
            this.ProductTitleTxt.Name = "ProductTitleTxt";
            this.ProductTitleTxt.Size = new System.Drawing.Size(216, 39);
            this.ProductTitleTxt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Add Product ";
            // 
            // EditProductPanel
            // 
            this.EditProductPanel.Controls.Add(this.is_activeCheckBox);
            this.EditProductPanel.Controls.Add(this.label2);
            this.EditProductPanel.Location = new System.Drawing.Point(1172, 74);
            this.EditProductPanel.Name = "EditProductPanel";
            this.EditProductPanel.Size = new System.Drawing.Size(424, 195);
            this.EditProductPanel.TabIndex = 2;
            // 
            // is_activeCheckBox
            // 
            this.is_activeCheckBox.AutoSize = true;
            this.is_activeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.is_activeCheckBox.Location = new System.Drawing.Point(22, 85);
            this.is_activeCheckBox.Name = "is_activeCheckBox";
            this.is_activeCheckBox.Size = new System.Drawing.Size(92, 29);
            this.is_activeCheckBox.TabIndex = 2;
            this.is_activeCheckBox.Text = "Active";
            this.is_activeCheckBox.UseVisualStyleBackColor = true;
            this.is_activeCheckBox.CheckedChanged += new System.EventHandler(this.is_activeCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Edit Product ";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 1231);
            this.Controls.Add(this.ProductsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Products";
            this.Text = "Products";
            this.ProductsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.AddProductPanel.ResumeLayout(false);
            this.AddProductPanel.PerformLayout();
            this.EditProductPanel.ResumeLayout(false);
            this.EditProductPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProductsPanel;
        private System.Windows.Forms.Panel AddProductPanel;
        private System.Windows.Forms.Button SaveProductBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ProductStatusTxt;
        private System.Windows.Forms.TextBox ProductPriceTxt;
        private System.Windows.Forms.TextBox ProductBarcodeTxt;
        private System.Windows.Forms.TextBox ProductTitleTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddProductsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel EditProductPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.CheckBox is_activeCheckBox;
    }
}