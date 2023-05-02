using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Helpers
{
    internal static class PressureHelper
    {
        internal static Measurement CreatePressureMeasuement(Measurement measurement)
        {
            Console.Clear();

            Menu.Info("Bloodpressure-Measurements\n");

            measurement.Bloodpressure.BloodpressureSYS = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your SYS Pressure in mmHg")));
            measurement.Bloodpressure.BloodpressureDIA = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your DIA Pressure in mmHG")));

            Menu.InfoWait("Please press any Key to return to Selection");
            Console.Clear();
            return measurement;
        }
    }
}
