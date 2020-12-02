using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Form1 f = new Form1();
            //SimulationSystem system = new SimulationSystem();//= f.system;

            //string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            //Random r_service = new Random();
            //for (int i = 0; i < 200; i++ )
            //{
            //    MessageBox.Show(r_service.Next(0, 101).ToString());
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Selection_input());
            //search for cal_sevese time i test
           
        }
    }
}
