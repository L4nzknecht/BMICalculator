using BMICalculator.Models;

namespace BMICalculator;

internal class Calculator
{
    internal static int CalculateAge(BMIMeasurement measurement)
    {

        int years = measurement.Date.Year - measurement.Birthday.Year;

        if ((measurement.Birthday.Month > measurement.Date.Month) || (measurement.Birthday.Month == measurement.Date.Month && measurement.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }

}
