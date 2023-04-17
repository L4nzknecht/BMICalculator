using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    internal class Generator
    {
        internal static void GenerateBMIMeasurements()
        {
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                BMIMeasurement measurement = new BMIMeasurement { };

                measurement.Lastname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
                measurement.Firstname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
                measurement.Birthday = DateOnly.FromDateTime(
                    DateTime.Now.AddYears(rnd.Next(-100, -18))
                                .AddMonths(rnd.Next(-11, 0))
                                .AddDays(rnd.Next(-31, 0)));
                measurement.Gender = (Gender)rnd.Next(Enum.GetNames(typeof(Gender)).Length);
                measurement.Height = 175 + (int)rnd.Next(-50, 50);
                measurement.Weight = 80 + (int)rnd.Next(-40, 40);
                measurement.Date = DateTime.Now.AddDays(rnd.Next(-180, 0));
                measurement.Age = Calculator.CalculateAge(measurement);
                measurement.BMI = BMIManager.CalculateBMI(measurement);
                measurement.Designation = BMIManager.GetDesignation(measurement.BMI);

                BMIManager.AddToMeasurements(measurement);
            }
        }
    }
}
