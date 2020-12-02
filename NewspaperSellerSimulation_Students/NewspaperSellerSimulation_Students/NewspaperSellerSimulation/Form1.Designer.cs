namespace NewspaperSellerSimulation
{
    partial class Form1
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
            this.btn_manual = new System.Windows.Forms.Button();
            this.btnauto = new System.Windows.Forms.Button();
            this.btnauto2 = new System.Windows.Forms.Button();
            this.btnauto3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_manual
            // 
            this.btn_manual.Location = new System.Drawing.Point(128, 53);
            this.btn_manual.Name = "btn_manual";
            this.btn_manual.Size = new System.Drawing.Size(205, 60);
            this.btn_manual.TabIndex = 0;
            this.btn_manual.Text = "Manual";
            this.btn_manual.UseVisualStyleBackColor = true;
            this.btn_manual.Click += new System.EventHandler(this.btn_manual_Click);
            // 
            // btnauto
            // 
            this.btnauto.Location = new System.Drawing.Point(27, 194);
            this.btnauto.Name = "btnauto";
            this.btnauto.Size = new System.Drawing.Size(128, 61);
            this.btnauto.TabIndex = 1;
            this.btnauto.Text = "testcase1";
            this.btnauto.UseVisualStyleBackColor = true;
            this.btnauto.Click += new System.EventHandler(this.btnauto_Click);
            // 
            // btnauto2
            // 
            this.btnauto2.Location = new System.Drawing.Point(178, 194);
            this.btnauto2.Name = "btnauto2";
            this.btnauto2.Size = new System.Drawing.Size(134, 61);
            this.btnauto2.TabIndex = 2;
            this.btnauto2.Text = "testcase2";
            this.btnauto2.UseVisualStyleBackColor = true;
            this.btnauto2.Click += new System.EventHandler(this.btnauto2_Click);
            // 
            // btnauto3
            // 
            this.btnauto3.Location = new System.Drawing.Point(331, 194);
            this.btnauto3.Name = "btnauto3";
            this.btnauto3.Size = new System.Drawing.Size(126, 61);
            this.btnauto3.TabIndex = 3;
            this.btnauto3.Text = "testcase3";
            this.btnauto3.UseVisualStyleBackColor = true;
            this.btnauto3.Click += new System.EventHandler(this.btnauto3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 322);
            this.Controls.Add(this.btnauto3);
            this.Controls.Add(this.btnauto2);
            this.Controls.Add(this.btnauto);
            this.Controls.Add(this.btn_manual);
            this.Name = "Form1";
            this.Text = "NewspaperSeller";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_manual;
        private System.Windows.Forms.Button btnauto;
        private System.Windows.Forms.Button btnauto2;
        private System.Windows.Forms.Button btnauto3;
    }
}