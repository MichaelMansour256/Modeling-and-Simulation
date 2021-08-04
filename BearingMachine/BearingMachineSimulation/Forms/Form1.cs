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
using BearingMachineModels;
using BearingMachineSimulation.Forms;
using BearingMachineSimulation.NewFolder1;
using BearingMachineTesting;


namespace BearingMachineSimulation
{
    partial class Form1 : Form
    {
        public Form1(SimulationSystem _simulationSystem, BuildCurrentMethod _buildCurrentMethod)
        {
            InitializeComponent();
            simulationSystem = _simulationSystem;
            buildCurrentMethod= _buildCurrentMethod;


        }
        private BuildCurrentMethod buildCurrentMethod { get; set; }
        private SimulationSystem simulationSystem { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            

            Form3 form3 = new Form3(simulationSystem.CurrentPerformanceMeasures , simulationSystem);
            form3.Text = "Current Performance Measures";
            form3.Show();


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Index", typeof(int));
            table.Columns.Add("RD", typeof(int));
            table.Columns.Add("Bearing\r\nLife", typeof(int));
            table.Columns.Add("Accumulated\r\nLife", typeof(int));
            table.Columns.Add("RD\r\n Delay", typeof(int));
            table.Columns.Add("Delay", typeof(int));
            int currentIndex = 1;
            foreach (var temp in simulationSystem.CurrentSimulationTable)
            {
                if(currentIndex != temp.Bearing.Index)
                {
                    table.Rows.Add();                    
                    table.Rows[table.Rows.Count - 1][5] = buildCurrentMethod.currentSimCaseDataBearingList[currentIndex - 1].totalDelay;
                    currentIndex++;
                }
                table.Rows.Add(temp.Bearing.Index,
                                temp.Bearing.RandomHours,
                                temp.Bearing.Hours,
                                temp.AccumulatedHours,
                                temp.RandomDelay,
                                temp.Delay);
            }
            table.Rows.Add();
            table.Rows[table.Rows.Count - 1][5] = buildCurrentMethod.currentSimCaseDataBearingList[currentIndex -1].totalDelay;

            table.Rows.Add();
            table.Rows[table.Rows.Count - 1][5] = buildCurrentMethod.totalDelayInMach;


            dataGridView1.DataSource = table;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[i].Frozen = false;
            }
        }
    }
}
