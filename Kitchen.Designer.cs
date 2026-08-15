namespace NEA_project
{
    partial class Kitchen
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
            this.KitchenFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // KitchenFlowPanel
            // 
            this.KitchenFlowPanel.AutoScroll = true;
            this.KitchenFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KitchenFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.KitchenFlowPanel.Name = "KitchenFlowPanel";
            this.KitchenFlowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.KitchenFlowPanel.Size = new System.Drawing.Size(1558, 1089);
            this.KitchenFlowPanel.TabIndex = 0;
            this.KitchenFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.KitchenFlowPanel_Paint);
            // 
            // Kitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 1089);
            this.ControlBox = false;
            this.Controls.Add(this.KitchenFlowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kitchen";
            this.Text = "Kitchen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel KitchenFlowPanel;
    }
}