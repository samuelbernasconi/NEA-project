namespace NEA_project
{
    partial class Reports
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
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RetrieveBillsBtn = new System.Windows.Forms.Button();
            this.BillsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BillsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(73, 87);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(300, 26);
            this.StartDatePicker.TabIndex = 0;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(521, 87);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(300, 26);
            this.EndDatePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select End Date";
            // 
            // RetrieveBillsBtn
            // 
            this.RetrieveBillsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RetrieveBillsBtn.Location = new System.Drawing.Point(1017, 32);
            this.RetrieveBillsBtn.Name = "RetrieveBillsBtn";
            this.RetrieveBillsBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RetrieveBillsBtn.Size = new System.Drawing.Size(306, 81);
            this.RetrieveBillsBtn.TabIndex = 4;
            this.RetrieveBillsBtn.Text = "Retrieve Bills";
            this.RetrieveBillsBtn.UseVisualStyleBackColor = true;
            this.RetrieveBillsBtn.Click += new System.EventHandler(this.RetrieveBillsBtn_Click);
            // 
            // BillsDataGridView
            // 
            this.BillsDataGridView.AllowUserToAddRows = false;
            this.BillsDataGridView.AllowUserToDeleteRows = false;
            this.BillsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BillsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.BillsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BillsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillsDataGridView.Location = new System.Drawing.Point(62, 174);
            this.BillsDataGridView.Name = "BillsDataGridView";
            this.BillsDataGridView.ReadOnly = true;
            this.BillsDataGridView.RowHeadersWidth = 62;
            this.BillsDataGridView.RowTemplate.Height = 28;
            this.BillsDataGridView.Size = new System.Drawing.Size(1319, 793);
            this.BillsDataGridView.TabIndex = 5;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1558, 1089);
            this.ControlBox = false;
            this.Controls.Add(this.BillsDataGridView);
            this.Controls.Add(this.RetrieveBillsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RetrieveBillsBtn;
        private System.Windows.Forms.DataGridView BillsDataGridView;
    }
}