namespace BearingMachineSimulation.Forms
{
    partial class DataInput
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._dc = new System.Windows.Forms.Label();
            this.DW = new System.Windows.Forms.Label();
            this._rbc = new System.Windows.Forms.Label();
            this.RPC = new System.Windows.Forms.Label();
            this._bc = new System.Windows.Forms.Label();
            this.BC = new System.Windows.Forms.Label();
            this._nh = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._rtob = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._nb = new System.Windows.Forms.Label();
            this.NB = new System.Windows.Forms.Label();
            this._rtab = new System.Windows.Forms.Label();
            this.RTAB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(614, 266);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // _dc
            // 
            this._dc.AutoSize = true;
            this._dc.Location = new System.Drawing.Point(184, 19);
            this._dc.Name = "_dc";
            this._dc.Size = new System.Drawing.Size(46, 17);
            this._dc.TabIndex = 7;
            this._dc.Text = "label6";
            this._dc.Click += new System.EventHandler(this._tbc_Click);
            // 
            // DW
            // 
            this.DW.AutoSize = true;
            this.DW.Location = new System.Drawing.Point(0, 19);
            this.DW.Name = "DW";
            this.DW.Size = new System.Drawing.Size(105, 17);
            this.DW.TabIndex = 6;
            this.DW.Text = "DowntimeCost :";
            // 
            // _rbc
            // 
            this._rbc.AutoSize = true;
            this._rbc.Location = new System.Drawing.Point(530, 19);
            this._rbc.Name = "_rbc";
            this._rbc.Size = new System.Drawing.Size(46, 17);
            this._rbc.TabIndex = 9;
            this._rbc.Text = "label6";
            // 
            // RPC
            // 
            this.RPC.AutoSize = true;
            this.RPC.Location = new System.Drawing.Point(390, 19);
            this.RPC.Name = "RPC";
            this.RPC.Size = new System.Drawing.Size(131, 17);
            this.RPC.TabIndex = 8;
            this.RPC.Text = "RepairPersonCost :";
            this.RPC.Click += new System.EventHandler(this.label3_Click);
            // 
            // _bc
            // 
            this._bc.AutoSize = true;
            this._bc.Location = new System.Drawing.Point(184, 58);
            this._bc.Name = "_bc";
            this._bc.Size = new System.Drawing.Size(46, 17);
            this._bc.TabIndex = 11;
            this._bc.Text = "label6";
            // 
            // BC
            // 
            this.BC.AutoSize = true;
            this.BC.Location = new System.Drawing.Point(0, 56);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(93, 17);
            this.BC.TabIndex = 10;
            this.BC.Text = "BearingCost :";
            this.BC.Click += new System.EventHandler(this._bc_Click);
            // 
            // _nh
            // 
            this._nh.AutoSize = true;
            this._nh.Location = new System.Drawing.Point(530, 56);
            this._nh.Name = "_nh";
            this._nh.Size = new System.Drawing.Size(46, 17);
            this._nh.TabIndex = 13;
            this._nh.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "NumberOfHours :";
            // 
            // _rtob
            // 
            this._rtob.AutoSize = true;
            this._rtob.Location = new System.Drawing.Point(184, 92);
            this._rtob.Name = "_rtob";
            this._rtob.Size = new System.Drawing.Size(46, 17);
            this._rtob.TabIndex = 15;
            this._rtob.Text = "label6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "RepairTimeForOneBearing :";
            // 
            // _nb
            // 
            this._nb.AutoSize = true;
            this._nb.Location = new System.Drawing.Point(530, 92);
            this._nb.Name = "_nb";
            this._nb.Size = new System.Drawing.Size(46, 17);
            this._nb.TabIndex = 17;
            this._nb.Text = "label6";
            // 
            // NB
            // 
            this.NB.AutoSize = true;
            this.NB.Location = new System.Drawing.Point(390, 92);
            this.NB.Name = "NB";
            this.NB.Size = new System.Drawing.Size(137, 17);
            this.NB.TabIndex = 16;
            this.NB.Text = "NumberOfBearings :";
            this.NB.Click += new System.EventHandler(this.label11_Click);
            // 
            // _rtab
            // 
            this._rtab.AutoSize = true;
            this._rtab.Location = new System.Drawing.Point(363, 132);
            this._rtab.Name = "_rtab";
            this._rtab.Size = new System.Drawing.Size(46, 17);
            this._rtab.TabIndex = 19;
            this._rtab.Text = "label6";
            // 
            // RTAB
            // 
            this.RTAB.AutoSize = true;
            this.RTAB.Location = new System.Drawing.Point(184, 132);
            this.RTAB.Name = "RTAB";
            this.RTAB.Size = new System.Drawing.Size(181, 17);
            this.RTAB.TabIndex = 18;
            this.RTAB.Text = "RepairTimeForAllBearings :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rtab);
            this.groupBox1.Controls.Add(this.RTAB);
            this.groupBox1.Controls.Add(this._nb);
            this.groupBox1.Controls.Add(this.NB);
            this.groupBox1.Controls.Add(this._rtob);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._nh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._bc);
            this.groupBox1.Controls.Add(this.BC);
            this.groupBox1.Controls.Add(this._rbc);
            this.groupBox1.Controls.Add(this.RPC);
            this.groupBox1.Controls.Add(this._dc);
            this.groupBox1.Controls.Add(this.DW);
            this.groupBox1.Location = new System.Drawing.Point(12, 574);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 159);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(614, 241);
            this.dataGridView2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 288);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bearing-Life Distribution";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(12, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(646, 259);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delay-Time Distribution";
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 745);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataInput";
            this.Text = "Data Input";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label _dc;
        private System.Windows.Forms.Label DW;
        private System.Windows.Forms.Label _rbc;
        private System.Windows.Forms.Label RPC;
        private System.Windows.Forms.Label _bc;
        private System.Windows.Forms.Label BC;
        private System.Windows.Forms.Label _nh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _rtob;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _nb;
        private System.Windows.Forms.Label NB;
        private System.Windows.Forms.Label _rtab;
        private System.Windows.Forms.Label RTAB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}