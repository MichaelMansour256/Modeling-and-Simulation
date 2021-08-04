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
    public partial class enterDemand : Form
    {
        SimulationSystem simulationSystem;
      
        public enterDemand(SimulationSystem simulationSystem )
        {

            InitializeComponent();
            this.simulationSystem = simulationSystem;
        }

        private void btnEnterDemand_Click(object sender, EventArgs e)
        {
            List<int> demandList = new List<int>();
            List<decimal> goodList=new List<decimal>();
            List<decimal> fairList = new List<decimal>();
            List<decimal> poorList = new List<decimal>();

            for (int i=0;i<dataGridView1.Rows.Count;i++) {
                if (dataGridView1.Rows[i].Cells[0].Value != null) //value is not null
                {
                    demandList.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                    //MessageBox.Show(demandList[i].ToString());
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null) //value is not null
                {
                    goodList.Add(Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    //MessageBox.Show(demandList[i].ToString());
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value != null) //value is not null
                {
                    fairList.Add(Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                    //MessageBox.Show(demandList[i].ToString());
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value != null) //value is not null
                {
                    poorList.Add(Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    //MessageBox.Show(demandList[i].ToString());
                }
            }
            decimal totalgood = goodList.Sum();
            decimal totalfair = fairList.Sum();
            decimal totalpoor = poorList.Sum();


            if (totalgood != 1 || totalfair != 1 || totalpoor != 1 ) {
                 MessageBox.Show("total probapility should be equal to 1");
                return ;
            }

            simulationSystem.fillDemandDistribution(demandList, goodList, fairList, poorList);
            simulationSystem.fillSimulationTable();
            simulationSystem.fillPerformanceMeasure();
            showSimulationResult showSimulationResult = new showSimulationResult(simulationSystem);
            showSimulationResult.ShowDialog();
            this.Close();

        }
    }
}
