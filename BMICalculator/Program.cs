using BMICalculator.Helpers;
using BMICalculator.Manager;
using BMICalculator.Models;
using System.Diagnostics.Metrics;

namespace BMICalculator;

internal class Program
{
    static void Main(string[] args)
    {
        Generator.GenerateBMIMeasurements();
        //Menu.MenuMain();
        MeasurementManager.AddToMeasurements(
            new Measurement(new Person("Henri","Platl",new DateOnly(1993,05,02), Interfaces.Gender.male) { })
            {
                Age = 30,
                Height = 180,
                Weight = 100,
                BMI = BMIHelper.CalculateBMI(180, 100),
                Designation = BMIHelper.GetDesignation(BMIHelper.CalculateBMI(180, 100))
            });
        foreach(Warning warning in WarningManager.listOfWarnings)
        {
            Console.WriteLine(warning.measurement.Person.Firstname + " " + warning.Prio + " " + warning.Message);
        }
    }
}