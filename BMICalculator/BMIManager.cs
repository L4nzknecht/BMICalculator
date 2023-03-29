using BMICalculator.Models;

namespace BMICalculator;

internal class BMIManager
{
    private static Calculator calc;
    internal static BMIManager bMI = new BMIManager();

    internal static List<BMIMeasurement> bMIMeasurements = new List<BMIMeasurement> { };
    internal void AddToMeasurements(BMIMeasurement measurement)
    {
        bMIMeasurements.Add(measurement);
    }
    internal static void GenerateMeasurement()
    {
        for (int i = 0; i < 20; i++)
        {
            Random rnd = new Random();
            BMIMeasurement measurement = new BMIMeasurement { };

            measurement.Lastname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            measurement.Firstname = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            measurement.Birthday = DateOnly.FromDateTime(
                DateTime.Now.AddYears(rnd.Next(-100, -15))
                            .AddMonths(rnd.Next(-11, 0))
                            .AddDays(rnd.Next(-28, 0)));
            measurement.Gender = (Gender)rnd.Next(Enum.GetNames(typeof(Gender)).Length);
            measurement.Height = 100 + (int)rnd.Next(0, 110);
            measurement.Weight = 80 + (int)rnd.Next(-40, 40);
            measurement.Date = DateTime.Now.AddDays(rnd.Next(-180, 0));
            measurement.Age = calc.CalculateAge(measurement);
            measurement.BMI = calc.CalculateBMI(measurement);
            measurement.Designation = bMI.GetDesignation(measurement.BMI);

            bMIMeasurements.Add(measurement); 
        }
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
        measurement.Designation = GetDesignation(measurement.BMI);
        AddToMeasurements(measurement);

        Menu.OutputBMI(measurement);
        Menu.InfoWait("Please press any Key to return to Menu");
        Console.Clear();
    }
    internal BMIDesignation GetDesignation(double bMI)
    {
        BMIDesignation designation = BMIDesignation.normalweight;
        if (bMI >= 40) { designation = BMIDesignation.AdipositasIII; }
        if (40 > bMI && bMI >= 35) { designation = BMIDesignation.AdipositasII; }
        if (35 > bMI && bMI >= 30) { designation = BMIDesignation.AdipositasI; }
        if (30 > bMI && bMI >= 25) { designation = BMIDesignation.overweight; }
        if (25 > bMI && bMI >= 18.5) { designation = BMIDesignation.normalweight; }
        if (18.8 > bMI) { designation = BMIDesignation.underweight; }
        return designation;
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

        measurement.Lastname = person.Lastname;
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
