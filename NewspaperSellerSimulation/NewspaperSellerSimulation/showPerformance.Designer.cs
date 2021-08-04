namespace NewspaperSellerSimulation
{
    partial class showPerformance
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
            this.TotalSalesRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLostProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalScrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfDaysMoreDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfDaysUnsoldPapers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TotalSalesRevenue,
            this.TotalCost,
            this.TotalLostProfit,
            this.TotalScrap,
            this.NetProfit,
            this.NumberOfDaysMoreDemand,
            this.NumberOfDaysUnsoldPapers});
            this.dataGridView1.Location = new System.Drawing.Point(32, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(727, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // TotalSalesRevenue
            // 
            this.TotalSalesRevenue.HeaderText = "TotalSalesRevenue";
            this.TotalSalesRevenue.Name = "TotalSalesRevenue";
            // 
            // TotalCost
            // 
            this.TotalCost.HeaderText = "TotalCost";
            this.TotalCost.Name = "TotalCost";
            // 
            // TotalLostProfit
            // 
            this.TotalLostProfit.HeaderText = "TotalLostProfit";
            this.TotalLostProfit.Name = "TotalLostProfit";
            // 
            // TotalScrap
            // 
            this.TotalScrap.HeaderText = "TotalScrap";
            this.TotalScrap.Name = "TotalScrap";
            // 
            // NetProfit
            // 
            this.NetProfit.HeaderText = "NetProfit";
            this.NetProfit.Name = "NetProfit";
            // 
            // NumberOfDaysMoreDemand
            // 
            this.NumberOfDaysMoreDemand.HeaderText = "NumberOfDaysMoreDemand";
            this.NumberOfDaysMoreDemand.Name = "NumberOfDaysMoreDemand";
            // 
            // NumberOfDaysUnsoldPapers
            // 
            this.NumberOfDaysUnsoldPapers.HeaderText = "NumberOfDaysUnsoldPapers";
            this.NumberOfDaysUnsoldPapers.Name = "NumberOfDaysUnsoldPapers";
            // 
            // showPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "showPerformance";
            this.Text = "showPerformance";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSalesRevenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLostProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfDaysMoreDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfDaysUnsoldPapers;
    }
}