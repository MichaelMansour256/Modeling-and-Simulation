using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MultiQueueModels;
using MultiQueueTesting;
using System.Collections;


namespace MultiQueueSimulation
{
    public partial class Selection_input : Form
    {
        public SimulationSystem system = new SimulationSystem();
        List<int> ID_intervaltime = new List<int>();
        List<decimal> ID_prob = new List<decimal>();

        List<int> server_Time = new List<int>();
        List<decimal> server_prop = new List<decimal>();

        private bool general_data = false, distributed_time = false;

        private int number_of_server = 0;
        TimeDistribution time_disribution_obj;
        Server server_obj;

        public static string path;
        public static int path_test;
        public Selection_input()
        {
            InitializeComponent();

            path = @"D:\University\Study Years\4th Year\First Term\Modeling and Simulation\Labs\Lab 2\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase1.txt";
            path_test = 1;
            ID_intervaltime.Clear();
            ID_prob.Clear();
            server_Time.Clear();
            server_prop.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        //--------------------<Read from file>--------------------\\
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine(); 
                while (data != null)
                {
                    //--------------------<Number Of Servers>--------------------\\

                    if (data == "NumberOfServers")
                    {
                       
                        data = sr.ReadLine(); 
                        system.NumberOfServers = Convert.ToInt32(data); 


                    }
                    //--------------------<Stopping Number>--------------------\\
                    else if (data == "StoppingNumber")
                    {
                        data = sr.ReadLine();
                        system.StoppingNumber = Convert.ToInt32(data);

                    }
                    //--------------------<Stopping Criteria>--------------------\\
                    else if (data == "StoppingCriteria")
                    {
                        data = sr.ReadLine();
                        if (data == "1")
                            system.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                        else if (data == "2")
                            system.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                    }
                    //--------------------<Selection Method>--------------------\\
                    else if (data == "SelectionMethod")
                    {
                        data = sr.ReadLine();
                        if (data == "1")
                            system.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                        else if (data == "2")
                            system.SelectionMethod = Enums.SelectionMethod.Random;
                        else if (data == "3")
                            system.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                    }
                    //--------------------< InterArrival Distribution Time >--------------------\\
                    else if (data == "InterarrivalDistribution")
                    {
                        data = sr.ReadLine();

                        while (data != "")
                        {
                            string[] s = data.Split(',');

                            ID_intervaltime.Add(int.Parse(s[0].ToString()));
                            ID_prob.Add(decimal.Parse(s[1].ToString()));

                            
                            data = sr.ReadLine();
                        }
                        system.Fill_TimeDistributionOfCustomers_Table(ID_intervaltime, ID_prob);

                    }
                    //--------------------<Fill_Service_time>--------------------\\
                    else if (data.Contains("ServiceDistribution_Server"))
                    {
                        int count_list = 0;
                        server_obj = new Server();
                        server_obj.ID = number_of_server + 1;
                        system.Servers.Add(server_obj);  
                        number_of_server++; 
                        data = sr.ReadLine();  
                        while (data != "") 
                        {
                            time_disribution_obj = new TimeDistribution();

                            string[] s_server = data.Split(',');
                            time_disribution_obj.Time = Convert.ToInt32(s_server[0]);
                            time_disribution_obj.Probability = Decimal.Parse(s_server[1].ToString());
                            if (count_list == 0)
                            {
                                time_disribution_obj.CummProbability = time_disribution_obj.Probability;
                                time_disribution_obj.MinRange = 1;
                                time_disribution_obj.MaxRange = Convert.ToInt32(time_disribution_obj.CummProbability * 100);
                            }
                            else
                            {
                                time_disribution_obj.CummProbability = time_disribution_obj.Probability + system.Servers[number_of_server - 1].TimeDistribution[count_list - 1].CummProbability;
                                time_disribution_obj.MinRange = system.Servers[number_of_server - 1].TimeDistribution[count_list - 1].MaxRange + 1;
                                time_disribution_obj.MaxRange = Convert.ToInt32(time_disribution_obj.CummProbability * 100);
                            }
                            server_obj.TimeDistribution.Add(time_disribution_obj);
                            count_list++;
                            data = sr.ReadLine();
                            if (data == null) break;
                        }


                    }
                    

                    data = sr.ReadLine();
                }
                sr.Close();
                number_of_server = 0;
                system.Fill_SimulationTable();
                SimulationTable st = new SimulationTable(system);
                st.Show();
                //this.Hide();
            }
            catch
            {
                MessageBox.Show("مش عارفه فيه ... والله لو اعرف هاقولك .. علشان انت دخلت ف الكاتش اللي انا حاطها منظر مش اكتر :( ظظظ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            path = @"D:\University\Study Years\4th Year\First Term\Modeling and Simulation\Labs\Lab 2\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase1.txt";
            path_test = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            path = @"D:\University\Study Years\4th Year\First Term\Modeling and Simulation\Labs\Lab 2\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase2.txt";
            path_test = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            path = @"D:\University\Study Years\4th Year\First Term\Modeling and Simulation\Labs\Lab 2\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase3.txt";
            path_test = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ID_intervaltime.Clear();
            ID_prob.Clear();
            server_Time.Clear();
            server_prop.Clear();

            system.Reset_object();
        }
    }
}
