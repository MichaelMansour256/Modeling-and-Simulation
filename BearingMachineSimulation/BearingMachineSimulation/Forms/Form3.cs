using BearingMachineModels;
using BearingMachineTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BearingMachineSimulation.Forms
{
    public partial class Form3 : Form
    {
        public Form3(PerformanceMeasures _performanceMeasures,SimulationSystem _simulation)
        {
            InitializeComponent();
            performanceMeasures = _performanceMeasures;
            simulation = _simulation;
        }
        SimulationSystem simulation;
        PerformanceMeasures performanceMeasures { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            _tbc.Text = performanceMeasures.BearingCost.ToString();
            _td.Text = performanceMeasures.DelayCost.ToString();
            _tdc.Text = performanceMeasures.DowntimeCost.ToString();
            _tr.Text = performanceMeasures.RepairPersonCost.ToString();
            _tc.Text = performanceMeasures.TotalCost.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string testResult = TestingManager.Test(simulation, Constants.FileNames.TestCase1);
            MessageBox.Show(testResult);

        }
    }
}
