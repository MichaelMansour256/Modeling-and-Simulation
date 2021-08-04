using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;

namespace NewspaperSellerSimulation
{
    public partial class showPerformance : Form
    {
        SimulationSystem simulationSystem;
        public showPerformance(SimulationSystem simulationSystem)
        {
            
            InitializeComponent();
            this.simulationSystem = simulationSystem;
            showPerformanceData();
        }
        public void showPerformanceData() {
            
            dataGridView1.Rows[0].Cells[0].Value= simulationSystem.PerformanceMeasures.TotalSalesProfit;
            dataGridView1.Rows[0].Cells[1].Value = simulationSystem.PerformanceMeasures.TotalCost;
            dataGridView1.Rows[0].Cells[2].Value = simulationSystem.PerformanceMeasures.TotalLostProfit;
            dataGridView1.Rows[0].Cells[3].Value = simulationSystem.PerformanceMeasures.TotalScrapProfit;
            dataGridView1.Rows[0].Cells[4].Value = simulationSystem.PerformanceMeasures.TotalNetProfit;
            dataGridView1.Rows[0].Cells[5].Value = simulationSystem.PerformanceMeasures.DaysWithMoreDemand;
            dataGridView1.Rows[0].Cells[6].Value = simulationSystem.PerformanceMeasures.DaysWithUnsoldPapers;
        }
    }
}
