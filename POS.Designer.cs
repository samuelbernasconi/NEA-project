namespace NEA_project
{
    partial class POS
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
            this.ProductsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CurrentOrderPanel = new System.Windows.Forms.Panel();
            this.SaveOrder = new System.Windows.Forms.Button();
            this.orderTotalLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.currentorderDataGridView = new System.Windows.Forms.DataGridView();
            this.TableComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CurrentOrderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentorderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsFlowPanel
            // 
            this.ProductsFlowPanel.AutoScroll = true;
            this.ProductsFlowPanel.Location = new System.Drawing.Point(12, 103);
            this.ProductsFlowPanel.Name = "ProductsFlowPanel";
            this.ProductsFlowPanel.Size = new System.Drawing.Size(1170, 929);
            this.ProductsFlowPanel.TabIndex = 0;
            // 
            // CurrentOrderPanel
            // 
            this.CurrentOrderPanel.Controls.Add(this.SaveOrder);
            this.CurrentOrderPanel.Controls.Add(this.orderTotalLabel);
            this.CurrentOrderPanel.Location = new System.Drawing.Point(1188, 103);
            this.CurrentOrderPanel.Name = "CurrentOrderPanel";
            this.CurrentOrderPanel.Size = new System.Drawing.Size(771, 929);
            this.CurrentOrderPanel.TabIndex = 1;
            // 
            // SaveOrder
            // 
            this.SaveOrder.Location = new System.Drawing.Point(403, 648);
            this.SaveOrder.Name = "SaveOrder";
            this.SaveOrder.Size = new System.Drawing.Size(126, 63);
            this.SaveOrder.TabIndex = 1;
            this.SaveOrder.Text = "Save";
            this.SaveOrder.UseVisualStyleBackColor = true;
            this.SaveOrder.Click += new System.EventHandler(this.SaveOrder_Click);
            // 
            // orderTotalLabel
            // 
            this.orderTotalLabel.AutoSize = true;
            this.orderTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderTotalLabel.Location = new System.Drawing.Point(585, 659);
            this.orderTotalLabel.Name = "orderTotalLabel";
            this.orderTotalLabel.Size = new System.Drawing.Size(86, 32);
            this.orderTotalLabel.TabIndex = 0;
            this.orderTotalLabel.Text = "Total:";
            // 
            // currentorderDataGridView
            // 
            this.currentorderDataGridView.AllowUserToAddRows = false;
            this.currentorderDataGridView.AllowUserToDeleteRows = false;
            this.currentorderDataGridView.AllowUserToResizeColumns = false;
            this.currentorderDataGridView.AllowUserToResizeRows = false;
            this.currentorderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentorderDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.currentorderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentorderDataGridView.Location = new System.Drawing.Point(1191, 106);
            this.currentorderDataGridView.Name = "currentorderDataGridView";
            this.currentorderDataGridView.ReadOnly = true;
            this.currentorderDataGridView.RowHeadersVisible = false;
            this.currentorderDataGridView.RowHeadersWidth = 65;
            this.currentorderDataGridView.RowTemplate.Height = 28;
            this.currentorderDataGridView.Size = new System.Drawing.Size(765, 629);
            this.currentorderDataGridView.TabIndex = 0;
            // 
            // TableComboBox
            // 
            this.TableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableComboBox.FormattingEnabled = true;
            this.TableComboBox.ItemHeight = 20;
            this.TableComboBox.Location = new System.Drawing.Point(115, 38);
            this.TableComboBox.MaxDropDownItems = 50;
            this.TableComboBox.Name = "TableComboBox";
            this.TableComboBox.Size = new System.Drawing.Size(200, 28);
            this.TableComboBox.TabIndex = 2;
            this.TableComboBox.SelectedIndexChanged += new System.EventHandler(this.TableComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Table";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1880, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1978, 1044);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableComboBox);
            this.Controls.Add(this.currentorderDataGridView);
            this.Controls.Add(this.CurrentOrderPanel);
            this.Controls.Add(this.ProductsFlowPanel);
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            this.CurrentOrderPanel.ResumeLayout(false);
            this.CurrentOrderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentorderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ProductsFlowPanel;
        private System.Windows.Forms.Panel CurrentOrderPanel;
        private System.Windows.Forms.DataGridView currentorderDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label orderTotalLabel;
        private System.Windows.Forms.Button SaveOrder;
        private System.Windows.Forms.ComboBox TableComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}