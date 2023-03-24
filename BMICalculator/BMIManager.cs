using BMICalculator.Models;

namespace BMICalculator;

internal class BMIManager
{
    private Calculator calc;
    internal static BMIManager bMI = new BMIManager();

    internal static List<BMIMeasurement> bMIMeasurements = new List<BMIMeasurement> { };
    internal void AddToMeasurements(BMIMeasurement measurement)
    {
        BMIManager.bMIMeasurements.Add(measurement);
    }

    internal BMIManager()
    {
        calc = new Calculator();
    }

    internal void GetBMI()
    {
        Console.Clear();

        Helpers.Info("BMI-Calculator\n");

        BMIMeasurement measurement = GetBMIMeasurement(GetPerson());

        measurement.BMI = calc.CalculateBMI(measurement);
        AddToMeasurements(measurement);
        OutputBMI(measurement.BMI);
        Helpers.InfoWait("Please press any Key to return to Menu");
        Console.Clear();
    }
    private void OutputBMI(double bmi)
    {
        Helpers.Info(
            $"\n" +
            $"Your BMI: {bmi:0.##}\n" +
            $"\n" +
            $"BMI < 18,5         - Underweight\n" +
            $"BMI 18,5 to 24,9   - Normal\n" +
            $"BMI 25 to 29,9     - Overweight\n" +
            $"BMI 30 and up      - Adipositas");
    }
    internal Person GetPerson()
    {
        PersonManager personManager = new PersonManager();
        Person person = personManager.CreatePerson();
        return person;
    }
    internal BMIMeasurement GetBMIMeasurement(Person person)
    {
        BMIMeasurement measurement = new BMIMeasurement { };

        measurement.Person = person;
        measurement.Height = int.Parse(Helpers.ValidateNumber(Helpers.GetInput("Please enter your Height in Centimeters")));
        measurement.Weight = int.Parse(Helpers.ValidateNumber(Helpers.GetInput("Please enter your Weight in kilograms")));
        measurement.Date = DateTime.Now;
        measurement.Age = calc.CalculateAge(measurement);

        Console.Clear();
        return measurement;
    }
}
