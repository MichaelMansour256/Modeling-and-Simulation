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
    public partial class Form1 : Form
    {
       public SimulationSystem system = new SimulationSystem();
       List<int> ID_intervaltime = new List<int>();
       List<decimal> ID_prob = new List<decimal>();

       List<int> server_Time = new List<int>() ;
       List<decimal> server_prop = new List<decimal>() ;
       List<ArrayList> row = new List<ArrayList>();

       private bool general_data = false, distributed_time = false;
        private int number_of_server = 0;
        public Form1()
        {
            InitializeComponent();
            //clear all lists
            ID_intervaltime.Clear();
            ID_prob.Clear();
            server_Time.Clear();
            server_prop.Clear();
            row.Clear();

        }


        //--------------------<General data>--------------------\\
        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_numservers.Text == "" || txt_stopnum.Text == "" || cmb_selectmethod.Text == "" || cmb_stopmethod.Text == "")
            {
                MessageBox.Show("Please Enter vaild data", "Invaild data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(txt_numservers.Text) < 0)
            {
                MessageBox.Show("Please Enter vaild data", "Invaild data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(txt_stopnum.Text) < 0)
            {
                MessageBox.Show("Please Enter vaild data", "Invaild data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            system.StoppingNumber = Convert.ToInt32(txt_stopnum.Text);
            system.NumberOfServers = Convert.ToInt32(txt_numservers.Text);

            // < method of stopping >
            if (cmb_stopmethod.Text == "Number Of Customers") system.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            else if (cmb_stopmethod.Text == "Simulation End Time") system.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;

            //< method of server >
            if (cmb_selectmethod.Text == "HighestPriority") system.SelectionMethod = Enums.SelectionMethod.HighestPriority;
            else if (cmb_selectmethod.Text == "LeastUtilization") system.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
            else if (cmb_selectmethod.Text == "Random") system.SelectionMethod = Enums.SelectionMethod.Random;

            // < number of servers >
            for (int i = 1; i <= system.NumberOfServers; ++i)
            {
                Server server = new Server();
                server.ID = i;

                server.TotalWorkingTime = 0;
                server.FinishTime = 0;
                system.Servers.Add(server);
            }

            MessageBox.Show("Vaild data move for next tab >.< ");
            general_data = true;
        }

        //--------------------< InterArrival Distribution Time >--------------------\\
        private void button3_Click(object sender, EventArgs e)
        {
            if (general_data)
            {
                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value != null)
                        sum += double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    else
                        break;

                }
                if (sum != 1.0 || sum != 1 || sum != 1.0f)
                {
                    MessageBox.Show("the sum of probabilty must = 1", "beeeb beeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value != null)
                    {

                        ID_intervaltime.Add(int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()));
                        ID_prob.Add(decimal.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));

                    }


                }
                system.Fill_TimeDistributionOfCustomers_Table(ID_intervaltime, ID_prob);
                distributed_time = true;

                //veiw data
                ArrayList al;
                for (int i = 0; i < ID_intervaltime.Count; i++ )
                {
                    al = new ArrayList();
                    al.Add(system.InterarrivalDistribution[i].CummProbability);
                    al.Add(system.InterarrivalDistribution[i].MinRange);
                    al.Add(system.InterarrivalDistribution[i].MaxRange);
                    dataGridView3.Rows.Add(al.ToArray());
                }


                    MessageBox.Show("Vaild data move for next tab >.< ");
            }
        }

        //--------------------<Fill_Service_time>--------------------\\
        private void button1_Click(object sender, EventArgs e)
        {
            if (distributed_time)
            {
                double sum = 0;
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (dataGridView5.Rows[i].Cells[1].Value != null)
                        sum += double.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString());
                    else
                        break;

                }
                if (sum != 1.0 || sum != 1 || sum != 1.0f)
                {
                    MessageBox.Show("the sum of probabilty must = 1", "beeeb beeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (dataGridView5.Rows[i].Cells[1].Value != null)
                    {

                        server_Time.Add(int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString()));
                        server_prop.Add(decimal.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));

                    }
                }
                system.Fill_Service_time(number_of_server, server_Time, server_prop);
                number_of_server++;
                ArrayList al;
                for (int i = 0; i < ID_intervaltime.Count; i++)
                {
                    al = new ArrayList();
                    al.Add(system.Servers[number_of_server - 1].TimeDistribution[i].CummProbability);
                    al.Add(system.Servers[number_of_server - 1].TimeDistribution[i].MinRange);
                    al.Add(system.Servers[number_of_server - 1].TimeDistribution[i].MaxRange);
                    dataGridView4.Rows.Add(al.ToArray());
                }

                server_Time.Clear();
                server_prop.Clear();
                MessageBox.Show("For server number = " + (number_of_server).ToString(), "Vaild data", MessageBoxButtons.OK, MessageBoxIcon.None);
                dataGridView4.Rows.Clear();

                if (number_of_server == system.NumberOfServers)
                {
                    if (general_data && distributed_time)
                    {
                        system.Fill_SimulationTable();
                        SimulationTable st = new SimulationTable(system);
                        //this.Hide();
                        st.Show();
                    }

                }
            }
        }

    }
}
