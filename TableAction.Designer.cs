namespace NEA_project
{
    partial class TableAction
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
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateBillBtn = new System.Windows.Forms.Button();
            this.BillPaidBtn = new System.Windows.Forms.Button();
            this.BillCancelledBtn = new System.Windows.Forms.Button();
            this.ViewOrdersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table ";
            // 
            // GenerateBillBtn
            // 
            this.GenerateBillBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateBillBtn.Location = new System.Drawing.Point(38, 123);
            this.GenerateBillBtn.Name = "GenerateBillBtn";
            this.GenerateBillBtn.Size = new System.Drawing.Size(410, 114);
            this.GenerateBillBtn.TabIndex = 1;
            this.GenerateBillBtn.Text = "Generate Bill";
            this.GenerateBillBtn.UseVisualStyleBackColor = true;
            this.GenerateBillBtn.Click += new System.EventHandler(this.GenerateBillBtn_Click);
            // 
            // BillPaidBtn
            // 
            this.BillPaidBtn.Location = new System.Drawing.Point(469, 123);
            this.BillPaidBtn.Name = "BillPaidBtn";
            this.BillPaidBtn.Size = new System.Drawing.Size(181, 54);
            this.BillPaidBtn.TabIndex = 2;
            this.BillPaidBtn.Text = "Mark Bill Paid";
            this.BillPaidBtn.UseVisualStyleBackColor = true;
            this.BillPaidBtn.Click += new System.EventHandler(this.BillPaidBtn_Click);
            // 
            // BillCancelledBtn
            // 
            this.BillCancelledBtn.Location = new System.Drawing.Point(469, 183);
            this.BillCancelledBtn.Name = "BillCancelledBtn";
            this.BillCancelledBtn.Size = new System.Drawing.Size(181, 54);
            this.BillCancelledBtn.TabIndex = 3;
            this.BillCancelledBtn.Text = "Mark Bill Cancelled";
            this.BillCancelledBtn.UseVisualStyleBackColor = true;
            this.BillCancelledBtn.Click += new System.EventHandler(this.BillCancelledBtn_Click);
            // 
            // ViewOrdersBtn
            // 
            this.ViewOrdersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewOrdersBtn.Location = new System.Drawing.Point(38, 266);
            this.ViewOrdersBtn.Name = "ViewOrdersBtn";
            this.ViewOrdersBtn.Size = new System.Drawing.Size(612, 114);
            this.ViewOrdersBtn.TabIndex = 4;
            this.ViewOrdersBtn.Text = "View Orders";
            this.ViewOrdersBtn.UseVisualStyleBackColor = true;
            this.ViewOrdersBtn.Click += new System.EventHandler(this.ViewOrdersBtn_Click);
            // 
            // TableAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 444);
            this.Controls.Add(this.ViewOrdersBtn);
            this.Controls.Add(this.BillCancelledBtn);
            this.Controls.Add(this.BillPaidBtn);
            this.Controls.Add(this.GenerateBillBtn);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableAction";
            this.ShowIcon = false;
            this.Text = "TableAction";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TableAction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GenerateBillBtn;
        private System.Windows.Forms.Button BillPaidBtn;
        private System.Windows.Forms.Button BillCancelledBtn;
        private System.Windows.Forms.Button ViewOrdersBtn;
    }
}