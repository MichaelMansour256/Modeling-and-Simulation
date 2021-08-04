using BearingMachineModels;
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
    public partial class Form2 : Form
    {
        public Form2(SimulationSystem _simulationSystem , int _totaldelay)
        {
            InitializeComponent();
            simulationSystem = _simulationSystem;
            totaldelay = _totaldelay;
        }
        int totaldelay;
        private SimulationSystem simulationSystem { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Bearing\r\tNumber", typeof(int));
            for (int bearingCount = 0; bearingCount < simulationSystem.ProposedSimulationTable[0].Bearings.Count; bearingCount++)
                table.Columns.Add("Beaing" + bearingCount + "\r\nLife", typeof(int));
            table.Columns.Add("First\r\nFailure", typeof(int));
            table.Columns.Add("Accumulated\r\nLife", typeof(int));
            table.Columns.Add("RD\r\n Delay", typeof(int));
            table.Columns.Add("Delay", typeof(int));
            int j = 0;
            int i=1;
            foreach (var temp in simulationSystem.ProposedSimulationTable)
            {
                table.Rows.Add(j+1);
                for ( i = 1; i <= temp.Bearings.Count; i++) 
                    table.Rows[j][i] = temp.Bearings[i - 1].Hours;
                table.Rows[j][i++] = temp.FirstFailure;
                table.Rows[j][i++] = temp.AccumulatedHours;
                table.Rows[j][i++] = temp.RandomDelay;
                table.Rows[j][i++] = temp.Delay;
                j++;
            }
            table.Rows.Add();
            table.Rows[j][--i] = totaldelay;
            dataGridView1.DataSource = table;

            for(int z=0; i<dataGridView1.ColumnCount;i++)
            {
                dataGridView1.Columns[z].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[z].Frozen = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(simulationSystem.ProposedPerformanceMeasures , simulationSystem);
            form3.Text = "Proposed Performance Measures";
            form3.Show();

        }
    }
}
