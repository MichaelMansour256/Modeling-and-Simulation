using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationCase
    {
        public SimulationCase()
        {
            this.AssignedServer = new Server();
        }

        public int CustomerNumber { get; set; }
        public int RandomInterArrival { get; set; }
        public int InterArrival { get; set; }
        public int ArrivalTime { get; set; }
        public int RandomService { get; set; }
        public int ServiceTime { get; set; }
        public Server AssignedServer { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int TimeInQueue { get; set; }

        Random r = new Random();

       /* public int get_Random_InterArrival()
        {
            RandomInterArrival  = r.Next(1, 101);
            return RandomInterArrival;
        }

        public int get_RandomDigit_Service()
        {
            RandomService = r.Next(1, 101);
            return RandomService;
        }*/
        public int calculate_startService_Time(int end_last_service)
        {
            if(end_last_service - ArrivalTime> 0)
            {
                return end_last_service ;
            }
            else
            {
                return ArrivalTime;
            }
        }

    }
}
