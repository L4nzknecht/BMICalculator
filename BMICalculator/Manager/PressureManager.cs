using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Manager
{
    internal class PressureManager
    {
        internal static Measurement CreatePressureMeasuement(Measurement measurement)
        {
            Console.Clear();

            Menu.Info("Bloddpressure-Measurements\n");

            measurement.BloodpressureSYS = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your SYS Pressure in mmHg")));
            measurement.BloodpressureDIA = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your DIA Pressure in mmHG")));

            Menu.InfoWait("Please press any Key to return to Selection");
            Console.Clear();
            return measurement;
        }
    }
}
