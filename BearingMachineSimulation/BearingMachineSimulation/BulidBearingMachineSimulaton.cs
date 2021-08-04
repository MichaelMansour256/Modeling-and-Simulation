using BearingMachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingMachineSimulation
{
    class BulidBearingMachineSimulaton
    {
        private List<CurrentSimulationCase> currentSimulationCasesList = new List<CurrentSimulationCase>();
        
        private void addBearingToCurrentSimulationCasesList (CurrentSimulationCase currentSimulationCase)
        {
            currentSimulationCasesList.Add(currentSimulationCase);
        }

        

    }
}
