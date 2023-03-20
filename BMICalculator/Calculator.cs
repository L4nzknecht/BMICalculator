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

        public double CalculateBMI(double height, double weight)
        {
            return weight / (height * height);
        }
    }
}
