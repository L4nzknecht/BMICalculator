using BMICalculator.Interfaces;
using BMICalculator.Models;
using System.Diagnostics.Metrics;

namespace BMICalculator;

internal class MeasurementCheckers
{
    internal static void BMICheck()
    {
        var listOfWarnings = new List<Measurement>();
        listOfWarnings.AddRange(ListofBMIMeasurements(BMIDesignation.underweight));
        listOfWarnings.AddRange(ListofBMIMeasurements(BMIDesignation.AdipositasIII));
        Menu.PrintListOfMeasurements(listOfWarnings);
    }
    private static List<Measurement> ListofBMIMeasurements(BMIDesignation designation)
    {
        var measurementsToPrint = MeasurementManager.bMIMeasurements.Where(x => x.Designation == designation).ToList<Measurement>();

        return (List<Measurement>)measurementsToPrint;
    }
    private void checkBmi(Measurement measurement)
    {
        if (measurement.BMI != null)
        {
            if (measurement.Designation == BMIDesignation.AdipositasI)
            {
                WarningManager.Add(new Warning(measurement, "BMI too high", 1));
            }
        }
    }

}
