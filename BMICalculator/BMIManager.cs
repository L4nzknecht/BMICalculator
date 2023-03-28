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

        Menu.Info("BMI-Calculator\n");

        BMIMeasurement measurement = GetBMIMeasurement(GetPerson());

        measurement.BMI = calc.CalculateBMI(measurement);
        AddToMeasurements(measurement);
        OutputBMI(measurement.BMI);
        Menu.InfoWait("Please press any Key to return to Menu");
        Console.Clear();
    }
    private void OutputBMI(double bmi)
    {
        Menu.Info(
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

        measurement.Surname = person.Surname;
        measurement.Firstname = person.Firstname;
        measurement.Gender = person.Gender;
        measurement.Birthday = person.Birthday;
        measurement.Height = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Height in Centimeters")));
        measurement.Weight = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Weight in kilograms")));
        measurement.Date = DateTime.Now;
        measurement.Age = calc.CalculateAge(measurement);

        Console.Clear();
        return measurement;
    }
}
