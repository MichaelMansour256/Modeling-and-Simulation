using System;
using System.Collections.Generic;
using System.Collections; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; } //?
        public Enums.SelectionMethod SelectionMethod { get; set; }//?


        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }



      

        Random r_s = new Random();
        Random r_s_id = new Random();
        public List<ArrayList> row = new List<ArrayList>();

        //----------------------------------------<Fill All Tables>----------------------------------------\\
        public void Fill_TimeDistributionOfCustomers_Table(List<int> interval_time, List<decimal> probability)
        {
            int l = interval_time.Count;

            InterarrivalDistribution.Add(new TimeDistribution());
            InterarrivalDistribution[0].Time            = interval_time[0];
            InterarrivalDistribution[0].Probability     = probability[0];
            InterarrivalDistribution[0].CummProbability = InterarrivalDistribution[0].Probability;
            InterarrivalDistribution[0].MinRange        = 1;
            InterarrivalDistribution[0].MaxRange        = (int)(InterarrivalDistribution[0].CummProbability * 100);
            for(int i=1; i<l; i++)
            {
                InterarrivalDistribution.Add(new TimeDistribution());

                InterarrivalDistribution[i].Time            = interval_time[i];
                InterarrivalDistribution[i].Probability     = probability[i];
                InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i-1].CummProbability + InterarrivalDistribution[i].Probability;
                InterarrivalDistribution[i].MinRange        = ((int)(InterarrivalDistribution[i - 1].CummProbability * 100)) + 1;
                InterarrivalDistribution[i].MaxRange        = ((int)(InterarrivalDistribution[i].CummProbability * 100));
            }
        }
        public void Fill_Service_time(int j, List<int> interval_time, List<decimal> probability)
        {
            

            Servers[j].TimeDistribution.Add(new TimeDistribution());

            int l = interval_time.Count;
            Servers[j].TimeDistribution[0].Time            = interval_time[0];
            Servers[j].TimeDistribution[0].Probability     = probability[0];
            Servers[j].TimeDistribution[0].CummProbability = Servers[j].TimeDistribution[0].Probability;
            Servers[j].TimeDistribution[0].MinRange        = 1;
            Servers[j].TimeDistribution[0].MaxRange        = (int)(Servers[j].TimeDistribution[0].CummProbability * 100);
            for(int i=1; i<l; i++)
            {
                Servers[j].TimeDistribution.Add(new TimeDistribution());
                Servers[j].TimeDistribution[i].Time            = interval_time[i];
                Servers[j].TimeDistribution[i].Probability     = probability[i];
                Servers[j].TimeDistribution[i].CummProbability = Servers[j].TimeDistribution[i - 1].CummProbability + Servers[j].TimeDistribution[i].Probability;
                Servers[j].TimeDistribution[i].MinRange        = ((int)(Servers[j].TimeDistribution[i - 1].CummProbability * 100)) + 1;
                Servers[j].TimeDistribution[i].MaxRange        = ((int)(Servers[j].TimeDistribution[i].CummProbability * 100)) ;
            }
            

        }
        private int get_distribution_time(int value, List<TimeDistribution> distribution_list)
        {
            /// 
            int l = distribution_list.Count;
            for (int i = 0; i < l; i++)
            {
                if (value >= distribution_list[i].MinRange && value <= distribution_list[i].MaxRange)
                    return distribution_list[i].Time;
            }
            return 0;
        }
        private void calculate_customer_time(int i, ref SimulationCase next_customer, int r)
        {
            next_customer.CustomerNumber = i;
          

            if (i == 1)
            {
                next_customer.RandomInterArrival = 1; 
                next_customer.InterArrival = 0;
                next_customer.ArrivalTime = 0; 
            }
            else
            {
                next_customer.RandomInterArrival = r;
                
                for (int j = 0; j < InterarrivalDistribution.Count; ++j)
                {
                    if (next_customer.RandomInterArrival >=InterarrivalDistribution[j].MinRange
                        && next_customer.RandomInterArrival <= InterarrivalDistribution[j].MaxRange)
                    {
                        next_customer.InterArrival = InterarrivalDistribution[j].Time;
                        break;
                    }
                }
               
                next_customer.ArrivalTime = next_customer.InterArrival + SimulationTable[i - 2].ArrivalTime;
            }
        }
        private void calculate_service_time(ref SimulationCase next_customer)
        {

            next_customer.RandomService = r_s.Next(1, 100);
            int used_index = (next_customer.AssignedServer.ID)- 1;
            int l = Servers[used_index].TimeDistribution.Count;

            for (int i = 0; i < l; i++)
            {

                if (next_customer.RandomService >= Servers[next_customer.AssignedServer.ID - 1].TimeDistribution[i].MinRange &&
                    next_customer.RandomService <= Servers[next_customer.AssignedServer.ID - 1].TimeDistribution[i].MaxRange)
                {

                    next_customer.ServiceTime = Servers[next_customer.AssignedServer.ID - 1].TimeDistribution[i].Time;
                    break;
                }

            }

            next_customer.EndTime = next_customer.ServiceTime + next_customer.StartTime;
        }
        public void Fill_SimulationTable()
        {
            if (StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                
                SimulationCase nc;
                Random r = new Random();
                for(int i = 1; i<=StoppingNumber; ++i)       //calculate service time with usecase
                {
                
                    int num_rand = r.Next(1, 100);

                    nc  = new SimulationCase();;
                    calculate_customer_time(i, ref nc, num_rand);
                    
                    check_Priority(ref nc);
                    SimulationTable.Add(nc);
                   
                }
            }
            else if(StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
            {
                bool finsihed = false; 
                int simulation_time = 0;  
                int i = 1;   // customer number
                SimulationCase nc;
                Random r = new Random(); 
                while (simulation_time <= StoppingNumber)
                {
                    nc = new SimulationCase();  
                    int num_rand = r.Next(1, 100);
                    calculate_customer_time(i, ref nc, num_rand);  
                    if (i != 1)
                    {
                        if (nc.ArrivalTime > StoppingNumber)
                            finsihed = true;
                    }

                    check_Priority(ref nc);
                    simulation_time = nc.ArrivalTime; 

                   
                    if ((nc.ArrivalTime + nc.TimeInQueue + nc.ServiceTime) > StoppingNumber)
                        finsihed = true;

                    if (finsihed) 
                        break; 


                    SimulationTable.Add(nc);
                    i++;

                }
            }
        }
        private void check_Priority(ref SimulationCase next_customer)
        {
            //seach for current availble server 
                // if current servers cout == 0
                    // search for the nearst server will be available
                        // if nearset servers count == 1
                            //set customer in row of this server
                        // else if nersert servers count > 1
                            //select server by one of methods
                // if current servers cout == 1
                    //set customer in server
                //else if current server count > 1
                    //select server by one of methods
            List<int> Currently_available = new List<int>();
            for (int i = 0; i< Servers.Count; ++i)
            {
                bool foundService = false;

                for (int j = SimulationTable.Count - 1; j >= 0; j--)
                {
                    if (SimulationTable[j].AssignedServer.ID == i + 1)
                    {
                        foundService = true;
                        if (next_customer.ArrivalTime >= SimulationTable[j].EndTime)
                            Currently_available.Add(i + 1); 
                        
                         break; 
                    }
                }
                if (!foundService)
                    Currently_available.Add(i + 1); // the server is free
               
            }
            if (Currently_available.Count == 1) //only one server is free
                Only_one_server_available(ref next_customer, Currently_available, 1);

            else if (Currently_available.Count == 0) //search for the nearset server will be available   
            {
                int min_diffrence = SimulationTable[SimulationTable.Count - 1].EndTime - next_customer.ArrivalTime;
                int min_ID = SimulationTable[SimulationTable.Count - 1].AssignedServer.ID; 
                List<int> Nearset_will_be_available = new List<int>(); 
                for (int k = 0; k < Servers.Count; ++k)
                {
                    for (int i = SimulationTable.Count - 1; i >= 0; i--)
                    {
                        if (SimulationTable[i].AssignedServer.ID == k + 1)
                        {
                            if (SimulationTable[i].EndTime - next_customer.ArrivalTime < min_diffrence)
                            {
                                min_diffrence = SimulationTable[i].EndTime - next_customer.ArrivalTime;
                                min_ID = SimulationTable[i].AssignedServer.ID;
                            }
                            break; 
                        }
                        
                    }
                }

                Nearset_will_be_available.Add(min_ID);

                for (int k = 0; k < Servers.Count; k++)
                {
                    for (int i = SimulationTable.Count - 1; i >= 0; i--)
                    {
                        if (k + 1 == SimulationTable[i].AssignedServer.ID)
                        {
                            if (SimulationTable[i].EndTime - next_customer.ArrivalTime == min_diffrence &&
                                SimulationTable[i].AssignedServer.ID != min_ID)
                            { 
                                Nearset_will_be_available.Add(SimulationTable[i].AssignedServer.ID);
                            }
                            break;
                        }
                        
                    }
                }
                
                Nearset_will_be_available.Sort(); 
                next_customer.TimeInQueue = min_diffrence;
                next_customer.StartTime = next_customer.ArrivalTime + next_customer.TimeInQueue;  // get the time in the queue and the start time of the service  

                if (Nearset_will_be_available.Count == 1)
                    Only_one_server_available(ref next_customer, Nearset_will_be_available, 0); 

                else if (Nearset_will_be_available.Count > 1)
                {
                    Priority_methods(ref next_customer, Nearset_will_be_available);
                }
            }
             
            else if (Currently_available.Count > 1)
            {
                next_customer.TimeInQueue = 0; // No wait TimeInQueue 
                next_customer.StartTime = next_customer.ArrivalTime;// start time = the arrival time 
                Priority_methods(ref next_customer, Currently_available);
            }

        }
        
        private void Only_one_server_available(ref SimulationCase next_customer, List<int> Currently_available, int p)
        {
            if (p == 1) 
            {
                next_customer.TimeInQueue = 0; 
                next_customer.StartTime = next_customer.ArrivalTime;
                next_customer.AssignedServer.ID = Currently_available[0];
            }
            else
            {
                next_customer.AssignedServer.ID = Currently_available[0];
            }
            calculate_service_time(ref next_customer);
            Servers[next_customer.AssignedServer.ID - 1].TotalWorkingTime += next_customer.ServiceTime;
        }
        private void Priority_methods(ref SimulationCase next_customer, List<int> server)
        {
            // priority Selcetion Method   
                if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
                    select_HighestPriority(ref next_customer, server);

                //random genertate  
                else if (SelectionMethod == Enums.SelectionMethod.Random)
                    select_Random(ref next_customer, server);

                // utilization  
                else if (SelectionMethod == Enums.SelectionMethod.LeastUtilization)
                    select_LeastUtilization(ref next_customer, server);
        }
        private void select_HighestPriority(ref SimulationCase next_customer, List<int> server)
        {
            next_customer.AssignedServer.ID = server[0];
            calculate_service_time(ref next_customer);

            Servers[next_customer.AssignedServer.ID - 1].TotalWorkingTime += next_customer.ServiceTime;
        }
        private void select_Random(ref SimulationCase next_customer, List<int> server) //changed
        {
            next_customer.AssignedServer.ID = server[r_s_id.Next(0, server.Count)]; //-1
            calculate_service_time(ref next_customer);
            Servers[next_customer.AssignedServer.ID - 1].TotalWorkingTime += next_customer.ServiceTime;
            
        }
        private void select_LeastUtilization(ref SimulationCase next_customer, List<int> server)
        {
            int min_ID = Servers[server[0] - 1].ID;
            int min_Work = Servers[server[0] - 1].TotalWorkingTime;
            for (int i = 1; i < server.Count; ++i)
            {
               
                if (Servers[server[i] - 1].TotalWorkingTime < min_Work)
                {
                    min_Work = Servers[server[i] - 1].TotalWorkingTime;
                    min_ID = Servers[server[i] - 1].ID;
                }
            }
            next_customer.AssignedServer.ID = min_ID;
            calculate_service_time(ref next_customer);
            Servers[next_customer.AssignedServer.ID - 1].TotalWorkingTime += next_customer.ServiceTime;
        }

         int test_proirty(int EndTime1, int EndTime2, int ArrivalTime)
        {
            if (EndTime1 - ArrivalTime > 0 && EndTime2 - ArrivalTime > 0)
                return (EndTime1 > EndTime2) ? 1 : 0;
            else if (EndTime1 - ArrivalTime < 0 && EndTime2 - ArrivalTime < 0)
                return (EndTime1 > EndTime2) ? 1 : 0;
            else if (EndTime1 - ArrivalTime > 0)
                return 1;
            else if (EndTime2 - ArrivalTime > 0)
                return 0;
            else //equalty in all cases E1 = E2 = A
                return 1;

        }

         //----------------------------------------<PerformanceMeasures>----------------------------------------\\
        public void PerformanceMeasures_for_system()
        {
            PerformanceMeasures.AverageWaitingTime = calculate_AverageWaitingTime();//averageWaitingTime = (total time in queue / #customers)
            PerformanceMeasures.MaxQueueLength     = calculate_MaxQueueLength();
            PerformanceMeasures.WaitingProbability = calculate_WaitingProbability();///WaitingProbability = (#customers waited / #customers)
        }
        private decimal calculate_AverageWaitingTime()
         {
            
            decimal time_queue = 0;
            decimal l = SimulationTable.Count;
             for (int i = 0; i < l; ++i)
                 time_queue += SimulationTable[i].TimeInQueue;

             //decimal d = Math.Round((time_queue / l), 3);
             return (time_queue / l);
         }
        private int calculate_MaxQueueLength()
         {
             int max_length = 0;
             int l = SimulationTable.Count;
             for (int i = 0; i < l; ++i)
             {
                 if (SimulationTable[i].TimeInQueue != 0)
                 {
                     int temp_length = 1; 
                     for (int j = i + 1; j < l; ++j)
                     {
                         //arrival < startwork ----> waited in queue
                         if (SimulationTable[j].ArrivalTime < SimulationTable[i].StartTime) 
                             temp_length++;
                     }
                     if (temp_length > max_length) 
                         max_length = temp_length;
                 }
             }
             return max_length;
         }
        private decimal calculate_WaitingProbability()
        {
            decimal waited_customers = 0;
            decimal l = SimulationTable.Count;
            for (int i = 0; i < l; ++i)
            {
                if (SimulationTable[i].TimeInQueue != 0) 
                    waited_customers++;
            }
            return (waited_customers / l);
        }

        public void PerformanceMeasures_for_each_server()
        {
            //get Simulation Time (max time of work in whole process)
            int total_simulation_time = 0;
            int l = SimulationTable.Count;
            for (int i = 0; i < l; ++i)
            {
                if (SimulationTable[i].EndTime > total_simulation_time)
                    total_simulation_time = SimulationTable[i].EndTime;
            }

            //get acual time of service (the exact time of work)
            for (int i = 0; i < NumberOfServers; ++i)
            {
                int total_service_time = 0; 
                int server_customers = 0;
                for (int j = 0; j < l; j++)
                {
                    if (SimulationTable[j].AssignedServer.ID == i + 1)
                    {   
                        total_service_time +=SimulationTable[j].ServiceTime;
                        server_customers++;
                    }
                }

                //server was not work
                int idel_time = total_simulation_time - total_service_time;

                if (server_customers < 1) 
                    server_customers = 1;
                if (idel_time < 0) 
                    idel_time = 0;

                //Math.Round(,3)
                //average service time = total service time / #customer in this server
                Servers[i].AverageServiceTime = (Convert.ToDecimal(total_service_time) / server_customers);
                //utilization = total service time / total simulation time'time  process'
                Servers[i].Utilization = (Convert.ToDecimal(total_service_time) / total_simulation_time);
                //idel probabilty = idel time / total simulation time
                Servers[i].IdleProbability = (Convert.ToDecimal(idel_time) / total_simulation_time);

                ArrayList al = new ArrayList();

                al.Add(i + 1);
                al.Add(Servers[i].AverageServiceTime);
                al.Add(Servers[i].Utilization);
                al.Add(Servers[i].IdleProbability);
                row.Add(al);
                
            }
        }

        public void Reset_object()
        {
            
            //for (int i = 0; i < StoppingNumber; ++i)       
            //{
            //    SimulationTable[i] = null;
            //}
            Servers.Clear();
            InterarrivalDistribution.Clear();
            SimulationTable.Clear();


        }
    }
}
