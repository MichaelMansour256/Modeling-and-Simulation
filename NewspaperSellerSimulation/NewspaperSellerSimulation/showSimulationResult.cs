using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;


namespace NewspaperSellerSimulation
{
    public partial class showSimulationResult : Form
    {
        SimulationSystem simulationSystem;
        public showSimulationResult(SimulationSystem simulationSystem)
        {
            InitializeComponent();
            this.simulationSystem = simulationSystem;
            showSimulationData();
            if (Form1.TestNumber == 1)
            {
                string result = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
                MessageBox.Show(result);

            }
            else if (Form1.TestNumber == 2)
            {
                string result = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }
            else if (Form1.TestNumber == 3)
            {
                string result = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase3);
                MessageBox.Show(result);
            }
            else
            {
                string result = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }
            
        }
        public void showSimulationData()
        {
            dataGridView1.Rows.Add(simulationSystem.NumOfRecords);
            for (int i=0;i<simulationSystem.NumOfRecords;i++) {
                dataGridView1.Rows[i].Cells[0].Value=simulationSystem.SimulationTable[i].DayNo;
                
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = simulationSystem.SimulationTable[i].RandomNewsDayType;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = simulationSystem.SimulationTable[i].NewsDayType;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = simulationSystem.SimulationTable[i].RandomDemand;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = simulationSystem.SimulationTable[i].Demand;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[5].Value = simulationSystem.SimulationTable[i].SalesProfit;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[6].Value = simulationSystem.SimulationTable[i].LostProfit;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[7].Value = simulationSystem.SimulationTable[i].ScrapProfit;
            }
            for (int i = 0; i < simulationSystem.NumOfRecords; i++)
            {
                dataGridView1.Rows[i].Cells[8].Value = simulationSystem.SimulationTable[i].DailyNetProfit;
            }
            
        }

        private void performance_Click(object sender, EventArgs e)
        {
            showPerformance showPerformance = new showPerformance(simulationSystem);
            showPerformance.ShowDialog();
            this.Close();

        }
    }
}
