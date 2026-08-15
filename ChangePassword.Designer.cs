namespace NEA_project
{
    partial class ChangePassword
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
            this.NewPasswordTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(80, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter new password";
            // 
            // NewPasswordTxt
            // 
            this.NewPasswordTxt.Location = new System.Drawing.Point(376, 76);
            this.NewPasswordTxt.Multiline = true;
            this.NewPasswordTxt.Name = "NewPasswordTxt";
            this.NewPasswordTxt.Size = new System.Drawing.Size(326, 38);
            this.NewPasswordTxt.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaveBtn.Location = new System.Drawing.Point(85, 174);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(617, 70);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 303);
            this.ControlBox = false;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NewPasswordTxt);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewPasswordTxt;
        private System.Windows.Forms.Button SaveBtn;
    }
}