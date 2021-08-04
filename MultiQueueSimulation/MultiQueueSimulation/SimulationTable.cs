using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using System.Collections;

namespace MultiQueueSimulation
{
    public partial class SimulationTable : Form
    {
        public SimulationSystem system ;
        int s_ind; 
        ArrayList listDataSource;

        public SimulationTable(SimulationSystem s)
        {
            InitializeComponent();
            system = s;
            s_ind = 0;
            listDataSource = new ArrayList();
            fill_Simulation_table();
            Calculate_PerformanceMeasures();
            draw_chart_next_server();
            path_test();
        }
        private void path_test() //test based on file opend
        {
            if(Selection_input.path_test == 1)
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }
            else if(Selection_input.path_test == 2)
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }
            else if(Selection_input.path_test == 3)
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase3);
                MessageBox.Show(result);
            }
        }
        public void fill_Simulation_table()
        {
            //system.Fill_SimulationTable();
            for (int i = 0; i < system.SimulationTable.Count; ++i)
            {
                ArrayList row = new ArrayList();
                row.Add(system.SimulationTable[i].CustomerNumber);
                row.Add(system.SimulationTable[i].RandomInterArrival);
                row.Add(system.SimulationTable[i].InterArrival);
                row.Add(system.SimulationTable[i].ArrivalTime);
                row.Add(system.SimulationTable[i].RandomService);
                row.Add(system.SimulationTable[i].StartTime);
                row.Add(system.SimulationTable[i].ServiceTime);
                row.Add(system.SimulationTable[i].EndTime);
                row.Add(system.SimulationTable[i].TimeInQueue);
                row.Add(system.SimulationTable[i].AssignedServer.ID);
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        public void Calculate_PerformanceMeasures()
        {
            system.PerformanceMeasures_for_system();
            system.PerformanceMeasures_for_each_server();

            lbl_averageTime.Text = system.PerformanceMeasures.AverageWaitingTime.ToString();
            lbl_maxLength_Queue.Text = system.PerformanceMeasures.MaxQueueLength.ToString();
            lbl_WaitingProbability.Text = system.PerformanceMeasures.WaitingProbability.ToString();

            for (int i = 0; i < system.Servers.Count; i++ )
                dataGridView2.Rows.Add(system.row[i].ToArray());
        }

        private void draw_chart_next_server()
        {
            s_ind++;
            if (s_ind <= system.Servers.Count)
            {
                foreach (var series in chart1.Series)
                    series.Points.Clear();

                for (int i = 0; i < system.SimulationTable.Count; ++i)
                {
                    int value = 0;
                    if (system.SimulationTable[i].AssignedServer.ID == s_ind)
                        value = 1;
                    for (int j = system.SimulationTable[i].StartTime; j <= system.SimulationTable[i].EndTime; j++)
                        chart1.Series["Series1"].Points.AddXY(j, value);
                }
                lbl_num_server.Text = (s_ind).ToString();
            }
            else
            {
                foreach (var series in chart1.Series)
                    series.Points.Clear();

                lbl_num_server.Text = ":(";

            }
            
        }
        private void draw_chart_preveois_server()
        {
            s_ind--;
            if(s_ind>0)
            {
                foreach (var series in chart1.Series)
                    series.Points.Clear();

                for (int i = 0; i < system.SimulationTable.Count; ++i)
                {
                    int value = 0;
                    if (system.SimulationTable[i].AssignedServer.ID == s_ind )
                        value = 1;
                    for (int j = system.SimulationTable[i].StartTime; j <= system.SimulationTable[i].EndTime; j++)
                        chart1.Series["Series1"].Points.AddXY(j, value);
                }
                lbl_num_server.Text = (s_ind ).ToString();
             }
            else
            {
                foreach (var series in chart1.Series)
                    series.Points.Clear();

                lbl_num_server.Text = ":(";

            }

        }

        private void button1_Click(object sender, EventArgs e)//next server
        {
            draw_chart_next_server();
        }

        private void button2_Click(object sender, EventArgs e)//preveois
        {
            draw_chart_preveois_server();
        }

     

    

     

       
    }
}
