using BMICalculator.Models;

namespace BMICalculator;

internal class Calculator
{
    internal static int CalculateAge(Measurement measurement)
    {

        int years = measurement.Date.Year - measurement.Person.Birthday.Year;

        if ((measurement.Person.Birthday.Month > measurement.Date.Month) || (measurement.Person.Birthday.Month == measurement.Date.Month && measurement.Person.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }

}
