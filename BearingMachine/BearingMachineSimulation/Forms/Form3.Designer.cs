namespace BearingMachineSimulation.Forms
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._tbc = new System.Windows.Forms.Label();
            this._td = new System.Windows.Forms.Label();
            this._tdc = new System.Windows.Forms.Label();
            this._tr = new System.Windows.Forms.Label();
            this._tc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Bearing Cost";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Delay Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Downtime Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total RepairPersonCost";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Cost";
            // 
            // _tbc
            // 
            this._tbc.AutoSize = true;
            this._tbc.Location = new System.Drawing.Point(329, 89);
            this._tbc.Name = "_tbc";
            this._tbc.Size = new System.Drawing.Size(46, 17);
            this._tbc.TabIndex = 5;
            this._tbc.Text = "label6";
            // 
            // _td
            // 
            this._td.AutoSize = true;
            this._td.Location = new System.Drawing.Point(329, 124);
            this._td.Name = "_td";
            this._td.Size = new System.Drawing.Size(46, 17);
            this._td.TabIndex = 6;
            this._td.Text = "label7";
            // 
            // _tdc
            // 
            this._tdc.AutoSize = true;
            this._tdc.Location = new System.Drawing.Point(329, 169);
            this._tdc.Name = "_tdc";
            this._tdc.Size = new System.Drawing.Size(46, 17);
            this._tdc.TabIndex = 7;
            this._tdc.Text = "label8";
            // 
            // _tr
            // 
            this._tr.AutoSize = true;
            this._tr.Location = new System.Drawing.Point(329, 206);
            this._tr.Name = "_tr";
            this._tr.Size = new System.Drawing.Size(46, 17);
            this._tr.TabIndex = 8;
            this._tr.Text = "label9";
            // 
            // _tc
            // 
            this._tc.AutoSize = true;
            this._tc.Location = new System.Drawing.Point(329, 247);
            this._tc.Name = "_tc";
            this._tc.Size = new System.Drawing.Size(54, 17);
            this._tc.TabIndex = 9;
            this._tc.Text = "label10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._tc);
            this.Controls.Add(this._tr);
            this.Controls.Add(this._tdc);
            this.Controls.Add(this._td);
            this.Controls.Add(this._tbc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _tbc;
        private System.Windows.Forms.Label _td;
        private System.Windows.Forms.Label _tdc;
        private System.Windows.Forms.Label _tr;
        private System.Windows.Forms.Label _tc;
        private System.Windows.Forms.Button button1;
    }
}