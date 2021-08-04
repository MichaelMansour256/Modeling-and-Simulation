using BearingMachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingMachineSimulation.NewFolder1
{
    static class HelperClass
    {
    public static SimulationSystem simulationSystem { get; set; }
    //public static List<TimeDistribution> BearingLifeDistribution { get; set; }
    //public static List<TimeDistribution> DelayTimeDistribution { get; set; }
        public static Bearing getBearing(int randomLife)
        {
            if (randomLife == 0)
                randomLife = 1;
            Bearing bearing = new Bearing();
            foreach(TimeDistribution time in simulationSystem.BearingLifeDistribution)
            {
                if (randomLife <= time.MaxRange)
                {
                    bearing.RandomHours = randomLife;
                    bearing.Hours = time.Time;
                    break;
                }
            }
            return bearing;
        }

        public static int getDelay( int randmDelay)
        {            
            foreach (TimeDistribution time in simulationSystem.DelayTimeDistribution)            
                if (randmDelay <= time.MaxRange)
                    return  time.Time;
            
            return -1;
        }

    }
}
