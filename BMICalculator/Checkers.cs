using BMICalculator.Models;
using System.Diagnostics.Metrics;

namespace BMICalculator;

internal class Checkers
{
    internal static void BMICheck()
    {
        var listOfWarnings = new List<BMIMeasurement>();
        listOfWarnings.AddRange(ListofBMIMeasurements(BMIDesignation.underweight));
        listOfWarnings.AddRange(ListofBMIMeasurements(BMIDesignation.AdipositasIII));
        Menu.PrintListOfMeasurements(listOfWarnings);
    }
    private static List<BMIMeasurement> ListofBMIMeasurements(BMIDesignation designation)
    {
        var measurementsToPrint = BMIManager.bMIMeasurements.Where(x => x.Designation == designation);

        return (List<BMIMeasurement>)measurementsToPrint;
    }

}
