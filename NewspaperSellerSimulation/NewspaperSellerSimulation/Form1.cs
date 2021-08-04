using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        public SimulationSystem simulationSystem=new SimulationSystem();
        List<decimal> DayProb = new List<decimal>();
        public static int TestNumber;
        List<int> demandList = new List<int>();
        List<decimal> goodList = new List<decimal>();
        List<decimal> fairList = new List<decimal>();
        List<decimal> poorList = new List<decimal>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            enterDataManual enterDataManual = new enterDataManual();
            enterDataManual.ShowDialog();
            this.Close();
        }

        
        public void readFile(string path)
        {
            try
            {

                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();
                
                while (data != null)
                {
                    if (data == "NumOfNewspapers") {
                    
                    simulationSystem.NumOfNewspapers=Convert.ToInt32(sr.ReadLine());

                    }
                    else if (data== "NumOfRecords") {
                    
                    simulationSystem.NumOfRecords = Convert.ToInt32(sr.ReadLine());

                    }
                    else if (data == "PurchasePrice")
                    {
                    
                    simulationSystem.PurchasePrice = Convert.ToDecimal(sr.ReadLine());
                    }
                    else if (data == "ScrapPrice")
                    {
                    
                    simulationSystem.ScrapPrice = Convert.ToDecimal(sr.ReadLine());
                    }
                    else if (data == "SellingPrice")
                    {
                    
                    simulationSystem.SellingPrice = Convert.ToDecimal(sr.ReadLine());

                    }
                    else if (data == "DayTypeDistributions")
                    {
                        
                        string [] array = sr.ReadLine().Split(',');
                        
                        DayProb.Add(Convert.ToDecimal(array[0]));
                        DayProb.Add(Convert.ToDecimal(array[1]));
                        DayProb.Add(Convert.ToDecimal(array[2]));
                        simulationSystem.fillTypeOfNewsDay(DayProb);

                    }
                    else if (data == "DemandDistributions")
                    {
                    
                    int i = 0;
                        while (i<7) {
                            
                            String [] prob=sr.ReadLine().Split(',');
                            demandList.Add(Convert.ToInt32(prob[0]));
                            goodList.Add(Convert.ToDecimal(prob[1]));
                            fairList.Add(Convert.ToDecimal(prob[2]));
                            poorList.Add(Convert.ToDecimal(prob[3]));
                            i++;
                        }
                        
                    
                        
                        
                    }
                    data=sr.ReadLine();
                }
                sr.Close();
                simulationSystem.fillDemandDistribution(demandList, goodList, fairList, poorList);
                simulationSystem.fillSimulationTable();
                simulationSystem.fillPerformanceMeasure();
                showSimulationResult showSimulationResult = new showSimulationResult(simulationSystem);
                showSimulationResult.ShowDialog();
                this.Close();
            }
            catch
            {
                MessageBox.Show("error in read form file");
            }
        }
        private void btnauto_Click(object sender, EventArgs e)
        {
            string path = @"D:\4.1\sim and modeling\NewspaperSellerSimulation_Students\NewspaperSellerSimulation_Students\NewspaperSellerSimulation\TestCases\TestCase1.txt";
            TestNumber = 1;
            readFile(path);

        }
        private void btnauto2_Click(object sender, EventArgs e)
        {
            string path = @"D:\4.1\sim and modeling\NewspaperSellerSimulation_Students\NewspaperSellerSimulation_Students\NewspaperSellerSimulation\TestCases\TestCase2.txt";
            TestNumber = 2;
            readFile(path);
        }

        private void btnauto3_Click(object sender, EventArgs e)
        {
            string path = @"D:\4.1\sim and modeling\NewspaperSellerSimulation_Students\NewspaperSellerSimulation_Students\NewspaperSellerSimulation\TestCases\TestCase3.txt";
            TestNumber = 3;
            readFile(path);
        }
    }
}
