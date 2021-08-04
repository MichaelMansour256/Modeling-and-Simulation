using BearingMachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingMachineSimulation.NewFolder1
{
    class BuildProposedMethod
    {
        public BuildProposedMethod(int NumberOfHours, List<CurrentSimCaseDataBearing> _currentSimCaseDataBearings)
        {
            BearingLifes = new List<List<int>>();
            currentSimCaseDataBearings = _currentSimCaseDataBearings;
            sumDelay = 0;
            proposedSimulationCasesList = new List<ProposedSimulationCase>();
            performanceMeasures = new PerformanceMeasures();
            fillBearingList(NumberOfHours);
            HelperClass.simulationSystem.ProposedSimulationTable.AddRange(proposedSimulationCasesList);
            calPerformanceMeasures();
            HelperClass.simulationSystem.ProposedPerformanceMeasures = performanceMeasures;

        }
        private PerformanceMeasures performanceMeasures { get; set; }
        List<List<int>> BearingLifes { get; set; }
         List<CurrentSimCaseDataBearing> currentSimCaseDataBearings { get; set; }
        List<ProposedSimulationCase> proposedSimulationCasesList { get; set; }
        Random random = new Random();
        public int sumDelay { get; set; }


        public void fillBearingList(int NumberOfHours)
        {

            ProposedSimulationCase proposedSimulationCase;
        
           for (int i =0; ; i++)
            {
                proposedSimulationCase = new ProposedSimulationCase();
                int minIndex=-1; 
                int minTime=1000000000;
                int index = 0;
                foreach(var currSimDataBear in currentSimCaseDataBearings)
                {
                   
                    if(i < currSimDataBear.totalNumberBearing)
                    {
                        proposedSimulationCase.Bearings.Add(currSimDataBear.currentSimulationCasesList[i].Bearing);
                        if ((minTime > currSimDataBear.currentSimulationCasesList[i].Bearing.Hours))
                        {
                            minIndex = index;
                            minTime = currSimDataBear.currentSimulationCasesList[i].Bearing.Hours;
                        }
                    }
                    else
                    {
                        int randomBearing = random.Next(1, HelperClass.simulationSystem.BearingLifeDistribution[HelperClass.simulationSystem.BearingLifeDistribution.Count-1].MaxRange + 1);
                        Bearing bearing = HelperClass.getBearing(randomBearing);
                        bearing.Index = currSimDataBear.Index;
                        proposedSimulationCase.Bearings.Add(bearing);
                        if ((minTime > bearing.Hours))
                        {
                            minIndex = index;
                            minTime = bearing.Hours;
                        }
                    }
                    index++;
                }
                proposedSimulationCase.FirstFailure = proposedSimulationCase.Bearings[minIndex].Hours;
                if (i == 0)
                    proposedSimulationCase.AccumulatedHours = proposedSimulationCase.FirstFailure;
                else
                    proposedSimulationCase.AccumulatedHours = proposedSimulationCasesList[proposedSimulationCasesList.Count-1].AccumulatedHours + proposedSimulationCase.FirstFailure;
                proposedSimulationCase.RandomDelay = random.Next(1, 101);

                //proposedSimulationCase.RandomDelay = random.Next(1, HelperClass.simulationSystem.DelayTimeDistribution[HelperClass.simulationSystem.DelayTimeDistribution.Count-1].MaxRange + 1);
                if (proposedSimulationCase.RandomDelay == 0)
                    proposedSimulationCase.RandomDelay = 1;
                proposedSimulationCase.Delay = HelperClass.getDelay(proposedSimulationCase.RandomDelay);
                sumDelay += proposedSimulationCase.Delay;
                proposedSimulationCasesList.Add(proposedSimulationCase);
                if (proposedSimulationCasesList[proposedSimulationCasesList.Count - 1].AccumulatedHours >= NumberOfHours)
                    break;
            }
        }


        public void calPerformanceMeasures()
        {
            int totalBearingInMach = proposedSimulationCasesList.Count * HelperClass.simulationSystem.NumberOfBearings;
            performanceMeasures.BearingCost = totalBearingInMach * HelperClass.simulationSystem.BearingCost;
            performanceMeasures.DelayCost = sumDelay * HelperClass.simulationSystem.DowntimeCost;
            performanceMeasures.DowntimeCost = proposedSimulationCasesList.Count * HelperClass.simulationSystem.RepairTimeForAllBearings * HelperClass.simulationSystem.DowntimeCost;
            performanceMeasures.RepairPersonCost = proposedSimulationCasesList.Count * HelperClass.simulationSystem.RepairTimeForAllBearings * HelperClass.simulationSystem.RepairPersonCost / 60;
            performanceMeasures.calculateTotalCost();
        }
    }
}
