using BearingMachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingMachineSimulation.NewFolder1
{
     class BuildCurrentMethod
    {
        public BuildCurrentMethod(int NumberOfBearings, int NumberOfHours)
        {
            //dic 
            //loop 
            currentSimCaseDataBearingList = new  List<CurrentSimCaseDataBearing>();
            performanceMeasures = new PerformanceMeasures();
            build( NumberOfBearings,  NumberOfHours);
            calPerformanceMeasures();
            HelperClass.simulationSystem.CurrentPerformanceMeasures = performanceMeasures;
        }
        int sumDelay;
        public int totalBearingInMach = 0;
        public int totalDelayInMach = 0;
        private PerformanceMeasures performanceMeasures { get; set; }
        Random random = new Random();   
        public  List<CurrentSimCaseDataBearing> currentSimCaseDataBearingList { get; set; }
       
        private List<TimeDistribution> BearingLifeDistribution { get; set; }
        //List<CurrentSimulationCase> currentSimulationCasesList { get; set;}
        public  void build(int NumberOfBearings , int NumberOfHours)
        {
            
            CurrentSimCaseDataBearing currentSimCaseDataBearing ;
            for (int i=0; i< NumberOfBearings; i++)
            {
                currentSimCaseDataBearing = new CurrentSimCaseDataBearing();
                currentSimCaseDataBearing.currentSimulationCasesList = runCurrentMethodBearing(NumberOfHours, i+1);
                currentSimCaseDataBearing.totalNumberBearing = currentSimCaseDataBearing.currentSimulationCasesList.Count;
                currentSimCaseDataBearing.totalDelay = sumDelay;
                currentSimCaseDataBearingList.Add(currentSimCaseDataBearing);
            }
            
        }  
        public List<CurrentSimulationCase> runCurrentMethodBearing(int NumberOfHours , int NumberCurrentBearing)
        {
            sumDelay = 0;
            List<CurrentSimulationCase>  currentSimulationCasesList = new List<CurrentSimulationCase>();
            for (int j=1; ;j++)
            {
                //TODO find rand [1,max in table]

                int randomBearing = random.Next(1, HelperClass.simulationSystem.BearingLifeDistribution[HelperClass.simulationSystem.BearingLifeDistribution.Count-1].MaxRange + 1);
                    CurrentSimulationCase current = new CurrentSimulationCase();
                    current.Bearing = HelperClass.getBearing(randomBearing);
                if (current.Bearing.RandomHours < 1)
                    current.Bearing.RandomHours = 1;
                if (current.Bearing.RandomHours > 100)
                    current.Bearing.RandomHours = 100;
                    current.Bearing.Index = NumberCurrentBearing;

                if (currentSimulationCasesList.Count == 0)
                    current.AccumulatedHours = current.Bearing.Hours;
                else
                {
                    current.AccumulatedHours = currentSimulationCasesList[currentSimulationCasesList.Count - 1].AccumulatedHours;
                    current.AccumulatedHours += current.Bearing.Hours;
                }

                int randomDelay = random.Next(1, 101);

                // int randomDelay = random.Next(1, HelperClass.simulationSystem.DelayTimeDistribution[HelperClass.simulationSystem.DelayTimeDistribution.Count-1].MaxRange + 1);
                if (randomDelay == 0)
                    randomDelay = 1;
                    current.RandomDelay = randomDelay;
                    current.Delay = HelperClass.getDelay(randomDelay);
                    sumDelay += current.Delay;
                    currentSimulationCasesList.Add(current);
                if(currentSimulationCasesList[currentSimulationCasesList.Count - 1].AccumulatedHours >= NumberOfHours)
                   break;
                


            }

            return currentSimulationCasesList;
        }

        public void calPerformanceMeasures()
        {
            
            foreach (var temp in currentSimCaseDataBearingList)
            {
                temp.Index = temp.currentSimulationCasesList[0].Bearing.Index;
                totalBearingInMach += temp.totalNumberBearing;
                totalDelayInMach += temp.totalDelay;
                HelperClass.simulationSystem.CurrentSimulationTable.AddRange(temp.currentSimulationCasesList);
            }
            performanceMeasures.BearingCost = totalBearingInMach * HelperClass.simulationSystem.BearingCost;
            performanceMeasures.DelayCost = totalDelayInMach * HelperClass.simulationSystem.DowntimeCost;
            performanceMeasures.DowntimeCost = totalBearingInMach * HelperClass.simulationSystem.RepairTimeForOneBearing * HelperClass.simulationSystem.DowntimeCost;
            performanceMeasures.RepairPersonCost = totalBearingInMach * HelperClass.simulationSystem.RepairTimeForOneBearing * HelperClass.simulationSystem.RepairPersonCost / 60;
            performanceMeasures.calculateTotalCost(); 
            
        } 


    }

    class CurrentSimCaseDataBearing
    {
        public int totalDelay { get; set; }
        public List<CurrentSimulationCase> currentSimulationCasesList { get; set; }
        public int totalNumberBearing { get; set; }
        public int Index { get; set; }
    }
}
