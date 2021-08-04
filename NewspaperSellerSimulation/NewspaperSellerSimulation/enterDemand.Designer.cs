namespace NewspaperSellerSimulation
{
    partial class enterDemand
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
            this.demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fairProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poorProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnterDemand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.demand,
            this.goodProb,
            this.fairProb,
            this.poorProb});
            this.dataGridView1.Location = new System.Drawing.Point(48, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(599, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // demand
            // 
            this.demand.HeaderText = "demandCol";
            this.demand.Name = "demand";
            // 
            // goodProb
            // 
            this.goodProb.HeaderText = "goodProbCol";
            this.goodProb.Name = "goodProb";
            // 
            // fairProb
            // 
            this.fairProb.HeaderText = "fairProbCol";
            this.fairProb.Name = "fairProb";
            // 
            // poorProb
            // 
            this.poorProb.HeaderText = "poorProbCol";
            this.poorProb.Name = "poorProb";
            // 
            // btnEnterDemand
            // 
            this.btnEnterDemand.Location = new System.Drawing.Point(127, 394);
            this.btnEnterDemand.Name = "btnEnterDemand";
            this.btnEnterDemand.Size = new System.Drawing.Size(75, 23);
            this.btnEnterDemand.TabIndex = 1;
            this.btnEnterDemand.Text = "simulate";
            this.btnEnterDemand.UseVisualStyleBackColor = true;
            this.btnEnterDemand.Click += new System.EventHandler(this.btnEnterDemand_Click);
            // 
            // enterDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnterDemand);
            this.Controls.Add(this.dataGridView1);
            this.Name = "enterDemand";
            this.Text = "enterDemand";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn fairProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn poorProb;
        private System.Windows.Forms.Button btnEnterDemand;
    }
}