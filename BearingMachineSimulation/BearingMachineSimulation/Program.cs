using BearingMachineSimulation.Forms;
using BearingMachineSimulation.NewFolder1;
using BearingMachineTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BearingMachineSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string filename = "D:\\4.1\\sim and modeling\\Task 3\\[Students]_Template\\BearingMachineSimulation\\TestCases\\TestCase1.txt";
            ReadingData readingData = new ReadingData(filename);
           
            // BuildCurrentMethod buildCurrentMethod = new BuildCurrentMethod(HelperClass.simulationSystem.NumberOfBearings, HelperClass.simulationSystem.NumberOfHours);
            //BuildProposedMethod buildProposedMethod = new BuildProposedMethod(HelperClass.simulationSystem.NumberOfHours, buildCurrentMethod.currentSimCaseDataBearingList);
            //string testResult = TestingManager.Test(HelperClass.simulationSystem, Constants.FileNames.TestCase1);
            //MessageBox.Show(testResult);

            Application.Run(new DataInput(HelperClass.simulationSystem));
            //Application.Run(new Form1(HelperClass.simulationSystem,  buildCurrentMethod));
            //Application.Run(new Form2(HelperClass.simulationSystem, buildProposedMethod.sumDelay));

        }
    }
}
