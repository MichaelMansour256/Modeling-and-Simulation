namespace NewspaperSellerSimulation
{
    partial class showSimulationResult
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
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomDayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LossProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.RandomDayType,
            this.DayType,
            this.RandomDemand,
            this.Demand,
            this.SalesProfit,
            this.LossProfit,
            this.ScrapProfit,
            this.DailyProfit});
            this.dataGridView1.Location = new System.Drawing.Point(2, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(940, 425);
            this.dataGridView1.TabIndex = 0;
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            // 
            // RandomDayType
            // 
            this.RandomDayType.HeaderText = "RandomDayType";
            this.RandomDayType.Name = "RandomDayType";
            // 
            // DayType
            // 
            this.DayType.HeaderText = "DayType";
            this.DayType.Name = "DayType";
            // 
            // RandomDemand
            // 
            this.RandomDemand.HeaderText = "RandomDemand";
            this.RandomDemand.Name = "RandomDemand";
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Demand";
            this.Demand.Name = "Demand";
            // 
            // SalesProfit
            // 
            this.SalesProfit.HeaderText = "SalesProfit";
            this.SalesProfit.Name = "SalesProfit";
            // 
            // LossProfit
            // 
            this.LossProfit.HeaderText = "LossProfit";
            this.LossProfit.Name = "LossProfit";
            // 
            // ScrapProfit
            // 
            this.ScrapProfit.HeaderText = "ScrapProfit";
            this.ScrapProfit.Name = "ScrapProfit";
            // 
            // DailyProfit
            // 
            this.DailyProfit.HeaderText = "DailyProfit";
            this.DailyProfit.Name = "DailyProfit";
            // 
            // performance
            // 
            this.performance.Location = new System.Drawing.Point(110, 462);
            this.performance.Name = "performance";
            this.performance.Size = new System.Drawing.Size(267, 41);
            this.performance.TabIndex = 1;
            this.performance.Text = "performance Measure";
            this.performance.UseVisualStyleBackColor = true;
            this.performance.Click += new System.EventHandler(this.performance_Click);
            // 
            // showSimulationResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 538);
            this.Controls.Add(this.performance);
            this.Controls.Add(this.dataGridView1);
            this.Name = "showSimulationResult";
            this.Text = "showSimulationResult";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomDayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn LossProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyProfit;
        private System.Windows.Forms.Button performance;
    }
}