using BMICalculator.Interfaces;
using BMICalculator.Models;

namespace BMICalculator.Manager
{
    internal class BMIManager
    {
        internal static double CalculateBMI(Measurement measurement)
        {
            double height = measurement.Height;

            double BMI = measurement.Weight / (height / 100 * height / 100);
            BMI = Math.Round(BMI, 2);
            return BMI;
        }
        internal static BMIDesignation GetDesignation(double bMI)
        {
            BMIDesignation designation = BMIDesignation.normalweight;
            if (bMI >= 40) { designation = BMIDesignation.AdipositasIII; }
            if (40 > bMI && bMI >= 35) { designation = BMIDesignation.AdipositasII; }
            if (35 > bMI && bMI >= 30) { designation = BMIDesignation.AdipositasI; }
            if (30 > bMI && bMI >= 25) { designation = BMIDesignation.overweight; }
            if (25 > bMI && bMI >= 18.5) { designation = BMIDesignation.normalweight; }
            if (18.8 > bMI) { designation = BMIDesignation.underweight; }
            return designation;
        }
        internal static Measurement CreateBMIMeasurement(Measurement measurement)
        {
            Console.Clear();

            Menu.Info("BMI-Measurements\n");

            measurement.Height = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Height in Centimeters")));
            measurement.Weight = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Weight in kilograms")));

            Console.Clear();

            measurement.BMI = BMIManager.CalculateBMI(measurement);
            measurement.Designation = BMIManager.GetDesignation((double)measurement.BMI);

            Menu.OutputMeasurement(measurement);
            Menu.InfoWait("Please press any Key to return to Selection");
            Console.Clear();
            return measurement;
        }
    }
}
