using BMICalculator.Models;

namespace BMICalculator;

internal class Calculator
{
    public Calculator() { }

    public double CalculateBMI(BMIMeasurement measurement)
    {
        double height = measurement.Height;

        double BMI = measurement.Weight / (height / 100 * height / 100);
        return BMI;
    }
    internal int CalculateAge(BMIMeasurement measurement)
    {

        int years = measurement.Date.Year - measurement.Birthday.Year;

        if ((measurement.Birthday.Month > measurement.Date.Month) || (measurement.Birthday.Month == measurement.Date.Month && measurement.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }

}
