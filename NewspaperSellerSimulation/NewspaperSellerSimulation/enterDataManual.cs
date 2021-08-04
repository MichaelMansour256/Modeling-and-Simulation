using NewspaperSellerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperSellerSimulation
{
    public partial class enterDataManual : Form
    {
        SimulationSystem simulationSystem = new SimulationSystem();
        public enterDataManual()
        {
            InitializeComponent();
            //SimulationSystem simulationSystem;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void enterData_Click(object sender, EventArgs e)
        {
            // Check if the user did leave any one empty
            if (NumOfNewspapers.Text == "" || NumOfRecords.Text == "" || PurchasePrice.Text == "" ||
                ScrapPrice.Text == "" || SellingPrice.Text == "" || goodProbability.Text == "" || fairProbability.Text == "" || poorProbability.Text == "")
            {
                MessageBox.Show("Please Enter All Data", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int iNumOfNewspapers = Convert.ToInt32(NumOfNewspapers.Text);
            int iNumOfRecords = Convert.ToInt32(NumOfRecords.Text);
            decimal dPurchasePrice = Convert.ToDecimal(PurchasePrice.Text);
            decimal dScrapPrice = Convert.ToDecimal(ScrapPrice.Text);
            decimal dSellingPrice = Convert.ToDecimal(SellingPrice.Text);
            decimal dgoodProbability = Convert.ToDecimal(goodProbability.Text);
            decimal dfairProbability = Convert.ToDecimal(fairProbability.Text);
            decimal dpoorProbability = Convert.ToDecimal(poorProbability.Text);

            if (iNumOfNewspapers <= 0) {
                MessageBox.Show("NumOfNewspapers must be large than zero", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (iNumOfRecords <= 0)
            {
                MessageBox.Show("NumOfRecords must be large than zero", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dPurchasePrice <= 0)
            {
                MessageBox.Show("PurchasePrice must be large than zero", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dScrapPrice <= 0)
            {
                MessageBox.Show("ScrapPrice must be large than zero", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dSellingPrice <= 0)
            {
                MessageBox.Show("SellingPrice must be large than zero", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dPurchasePrice > dSellingPrice)
            {
                MessageBox.Show("SellingPrice must be large than PurchasePrice", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgoodProbability+dpoorProbability+dfairProbability != 1) {
                MessageBox.Show("sum of fair and good and poor should be 1", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            simulationSystem.NumOfNewspapers = iNumOfNewspapers;
            simulationSystem.NumOfRecords = iNumOfRecords;
            simulationSystem.PurchasePrice = dPurchasePrice;
            simulationSystem.ScrapPrice = dScrapPrice;
            simulationSystem.SellingPrice = dSellingPrice;
            simulationSystem.UnitProfit = simulationSystem.SellingPrice - simulationSystem.PurchasePrice;
            var DayProb = new List<decimal>();
            DayProb.Add(dgoodProbability);
            DayProb.Add(dfairProbability);
            DayProb.Add(dpoorProbability);
            simulationSystem.fillTypeOfNewsDay(DayProb);
            enterDemand enterDemand = new enterDemand(simulationSystem);
            enterDemand.ShowDialog();
            this.Close();






        }

        private void enterDataManual_Load(object sender, EventArgs e)
        {
             
        }
    }
}
