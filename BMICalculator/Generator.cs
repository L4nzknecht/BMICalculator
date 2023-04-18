using BMICalculator.Interfaces;
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
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {      
                Person person = new Person();
                person.Lastname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
                person.Firstname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
                person.Birthday = DateOnly.FromDateTime(
                    DateTime.Now.AddYears(rnd.Next(-100, -18))
                                .AddMonths(rnd.Next(-11, 0))
                                .AddDays(rnd.Next(-31, 0)));
                person.Gender = (Gender)rnd.Next(Enum.GetNames(typeof(Gender)).Length);

                Measurement measurement = new Measurement(person) { };

                measurement.Person = person;
                measurement.Height = 175 + (int)rnd.Next(-50, 50);
                measurement.Weight = 80 + (int)rnd.Next(-40, 40);
                measurement.Date = DateTime.Now.AddDays(rnd.Next(-180, 0));
                measurement.Age = Calculator.CalculateAge(measurement);
                measurement.BMI = MeasurementManager.CalculateBMI(measurement);
                measurement.Designation = MeasurementManager.GetDesignation(measurement.BMI);

                MeasurementManager.AddToMeasurements(measurement);
            }
        }
    }
}
