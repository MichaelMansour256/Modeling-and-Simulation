using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearingMachineModels;
using BearingMachineSimulation.NewFolder1;

namespace BearingMachineSimulation
{   
    public class ReadingData
    {
        public ReadingData(string filename)
        {
            simulationSystem = new SimulationSystem();
            readingData(filename);
            split_fill_Data();

            //HelperClass.BearingLifeDistribution = simulationSystem.BearingLifeDistribution;
            //HelperClass.DelayTimeDistribution = simulationSystem.DelayTimeDistribution;
            HelperClass.simulationSystem = simulationSystem;
        }

        public SimulationSystem simulationSystem { get; set; }
        private string data { get; set; }
        
        private void readingData(string fileName)
        {
            if (File.Exists(fileName))
            {
                data = File.ReadAllText(fileName);
            }
           
        }

        private void split_fill_Data()
        {
            string [] splitdata = data.Split('\n');
            simulationSystem.DowntimeCost = Int32.Parse(splitdata[1]) ;
            simulationSystem.RepairPersonCost = Int32.Parse(splitdata[4]);
            simulationSystem.BearingCost = Int32.Parse(splitdata[7]);
            simulationSystem.NumberOfHours = Int32.Parse(splitdata[10]);

            simulationSystem.NumberOfBearings = Int32.Parse(splitdata[13]);

            simulationSystem.RepairTimeForOneBearing = Int32.Parse(splitdata[16]);

            simulationSystem.RepairTimeForAllBearings = Int32.Parse(splitdata[19]);

            string[] tempsplitstrig = null;
            int index_splitdata = 22;
            for (int i=0; splitdata[index_splitdata] != "\r";i++, index_splitdata++)
            {

                tempsplitstrig = splitdata[index_splitdata].Split(',');
                TimeDistribution _timeDistribution = new TimeDistribution();
                _timeDistribution.Time = Int32.Parse(tempsplitstrig[0]);
                _timeDistribution.Probability = Convert.ToDecimal(tempsplitstrig[1]);
                if (i != 0)
                {
                        _timeDistribution.CummProbability = simulationSystem.DelayTimeDistribution[i - 1].CummProbability + _timeDistribution.Probability;
                    if (_timeDistribution.Probability != 0)
                    {
                        _timeDistribution.MinRange = simulationSystem.DelayTimeDistribution[i - 1].MaxRange + 1;
                        _timeDistribution.MaxRange = Convert.ToInt32(_timeDistribution.CummProbability * 100);
                    }
                    else
                    {                        
                        _timeDistribution.MinRange = 0;
                        _timeDistribution.MaxRange = 0;
                    }
                }
                else
                {
                    _timeDistribution.CummProbability = _timeDistribution.Probability;
                    if (_timeDistribution.Probability != 0)
                        _timeDistribution.MinRange = 1;
                    else
                        _timeDistribution.MinRange = 0;
                    _timeDistribution.MaxRange = Convert.ToInt32(_timeDistribution.CummProbability * 100);
                }
                simulationSystem.DelayTimeDistribution.Add(_timeDistribution);
            }
            index_splitdata += 2;
            for (int i =0; index_splitdata <splitdata.Length; i++,index_splitdata++)
            {

                tempsplitstrig = splitdata[index_splitdata].Split(',');
                TimeDistribution _timeDistribution = new TimeDistribution();

                _timeDistribution.Time = Int32.Parse(tempsplitstrig[0]);
                _timeDistribution.Probability = Convert.ToDecimal(tempsplitstrig[1]);
                if (i != 0)
                {
                    _timeDistribution.CummProbability = simulationSystem.BearingLifeDistribution[i - 1].CummProbability + _timeDistribution.Probability;

                    if (_timeDistribution.Probability != 0)
                    {
                        _timeDistribution.MinRange = simulationSystem.BearingLifeDistribution[i - 1].MaxRange + 1;
                        _timeDistribution.MaxRange = Convert.ToInt32(_timeDistribution.CummProbability * 100);
                    }
                    else
                    {
                        _timeDistribution.MinRange = 0;
                        _timeDistribution.MaxRange = 0;
                    }
                }
                else
                {
                    _timeDistribution.CummProbability = _timeDistribution.Probability;
                    if (_timeDistribution.Probability != 0)
                        _timeDistribution.MinRange = 1;
                    else
                        _timeDistribution.MinRange = 0;
                    _timeDistribution.MaxRange = Convert.ToInt32(_timeDistribution.CummProbability * 100);
                }
                simulationSystem.BearingLifeDistribution.Add(_timeDistribution);
            }

        }

       
    }        



}
