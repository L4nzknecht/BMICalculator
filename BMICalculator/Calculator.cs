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

        int years = measurement.Date.Year - measurement.Person.Birthday.Year;

        if ((measurement.Person.Birthday.Month > measurement.Date.Month) || (measurement.Person.Birthday.Month == measurement.Date.Month && measurement.Person.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }

}
