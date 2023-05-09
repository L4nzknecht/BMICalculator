using BMICalculator.Helpers;
using BMICalculator.Interfaces;
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
        var LoM = WarningManager.listOfWarnings.OrderByDescending(x => x.Prio);
        foreach (Warning warning in LoM)
        {
            Menu.OutputMeasurement(warning.measurement);
            Console.WriteLine("   Warning:  Priority:" + warning.Prio + " " + warning.Message);
        }
    }
}