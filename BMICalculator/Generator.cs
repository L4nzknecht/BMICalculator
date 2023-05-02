using BMICalculator.Interfaces;
using BMICalculator.Manager;
using BMICalculator.Models;
using BMICalculator.Helpers;
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
            Random rnd = new();
            for (int i = 0; i < 20; i++)
            {
                Person person = new()
                {
                    Lastname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8),
                    Firstname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8),
                    Birthday = DateOnly.FromDateTime(
                    DateTime.Now.AddYears(rnd.Next(-100, -18))
                                .AddMonths(rnd.Next(-11, 0))
                                .AddDays(rnd.Next(-31, 0))),
                    Gender = (Gender)rnd.Next(Enum.GetNames(typeof(Gender)).Length)
                };

                Measurement measurement = new(person)
                {
                    Person = person,
                    Height = 175 + (int)rnd.Next(-50, 50),
                    Weight = 80 + (int)rnd.Next(-40, 40),
                    Date = DateTime.Now.AddDays(rnd.Next(-180, 0))
                };
                measurement.Age = MeasurementManager.CalculateAge(measurement);
                measurement.BMI = BMIHelper.CalculateBMI(measurement);
                measurement.Designation = BMIHelper.GetDesignation((double)measurement.BMI);

                measurement.Pulse = 75 + (int)rnd.Next(-25, 30);

                //measurement.Bloodpressure.BloodpressureSYS = 100 + (int)rnd.Next(-30, 90);
                //measurement.Bloodpressure.BloodpressureDIA = 70 + (int)rnd.Next(-30, 30);

                MeasurementManager.AddToMeasurements(measurement);
            }
        }
    }
}
