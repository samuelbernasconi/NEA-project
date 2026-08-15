namespace NEA_project
{
    partial class Ingredients
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
            this.IngredientsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // IngredientsDataGridView
            // 
            this.IngredientsDataGridView.AllowUserToAddRows = false;
            this.IngredientsDataGridView.AllowUserToDeleteRows = false;
            this.IngredientsDataGridView.AllowUserToResizeColumns = false;
            this.IngredientsDataGridView.AllowUserToResizeRows = false;
            this.IngredientsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IngredientsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.IngredientsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.IngredientsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IngredientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientsDataGridView.Location = new System.Drawing.Point(1, 2);
            this.IngredientsDataGridView.Name = "IngredientsDataGridView";
            this.IngredientsDataGridView.ReadOnly = true;
            this.IngredientsDataGridView.RowHeadersWidth = 62;
            this.IngredientsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.IngredientsDataGridView.RowTemplate.Height = 28;
            this.IngredientsDataGridView.ShowEditingIcon = false;
            this.IngredientsDataGridView.Size = new System.Drawing.Size(1872, 959);
            this.IngredientsDataGridView.TabIndex = 0;
            this.IngredientsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IngredientsDataGridView_CellContentClick);
            // 
            // Ingredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 973);
            this.Controls.Add(this.IngredientsDataGridView);
            this.Name = "Ingredients";
            this.Text = "Ingredients";
            this.Load += new System.EventHandler(this.Ingredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IngredientsDataGridView;
    }
}