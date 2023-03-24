using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    internal class Calculator
    {
        public Calculator() { }

        public double CalculateBMI(BMIMeasurement measurement)
        {
            double height = measurement.height;

            double BMI = measurement.weight / (height/100 * height/100);
            return BMI;
        }
    }
}
