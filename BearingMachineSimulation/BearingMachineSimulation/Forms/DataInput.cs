using BearingMachineModels;
using BearingMachineSimulation.NewFolder1;
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
    public partial class DataInput : Form
    {
        public DataInput(SimulationSystem _simulationSystem)
        {
            InitializeComponent();
            simulationSystem= _simulationSystem;
        }
        private SimulationSystem simulationSystem { get; set; }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            BuildCurrentMethod buildCurrentMethod = new BuildCurrentMethod(HelperClass.simulationSystem.NumberOfBearings, HelperClass.simulationSystem.NumberOfHours);
            BuildProposedMethod buildProposedMethod = new BuildProposedMethod(HelperClass.simulationSystem.NumberOfHours, buildCurrentMethod.currentSimCaseDataBearingList);

            Form1 form1 = new Form1(HelperClass.simulationSystem, buildCurrentMethod);
            Form2 form2 = new Form2(HelperClass.simulationSystem, buildProposedMethod.sumDelay);
            DataTable table = new DataTable();
            table.Columns.Add("Bearing\r\nLife", typeof(int));           
            table.Columns.Add("Probability", typeof(decimal));
            table.Columns.Add("Comulative\r\nProbability", typeof(decimal));
            table.Columns.Add("RD\r\n Assignment", typeof(string));
            foreach(var temp in simulationSystem.BearingLifeDistribution)
            {
                table.Rows.Add(temp.Time, temp.Probability, temp.CummProbability, temp.MinRange.ToString() + '-' + temp.MaxRange.ToString());
            }
            dataGridView1.DataSource = table;

            DataTable table2 = new DataTable();
            table2.Columns.Add("Delay\r\nTime", typeof(int));
            table2.Columns.Add("Probability", typeof(decimal));
            table2.Columns.Add("Comulative\r\nProbability", typeof(decimal));
            table2.Columns.Add("RD\r\n Assignment", typeof(string));
            foreach (var temp in simulationSystem.DelayTimeDistribution)
            {
                table2.Rows.Add(temp.Time, temp.Probability, temp.CummProbability, temp.MinRange.ToString() + '-' + temp.MaxRange.ToString());
            }
            dataGridView2.DataSource = table2;

            _dc.Text = simulationSystem.DowntimeCost.ToString();
            _rbc.Text = simulationSystem.RepairPersonCost.ToString();
            _bc.Text = simulationSystem.BearingCost.ToString();
            _nh.Text = simulationSystem.NumberOfHours.ToString();
            _nb.Text = simulationSystem.NumberOfBearings.ToString();
            _rtob.Text = simulationSystem.RepairTimeForOneBearing.ToString();
            _rtab.Text = simulationSystem.RepairTimeForAllBearings.ToString();

            form1.Show();
            form2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void _tbc_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void _bc_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
