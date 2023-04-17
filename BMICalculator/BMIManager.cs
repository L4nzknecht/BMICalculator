using BMICalculator.Models;

namespace BMICalculator;

internal class BMIManager
{
    internal static BMIManager bMI = new();

    internal static List<BMIMeasurement> bMIMeasurements = new List<BMIMeasurement> { };
    internal static void AddToMeasurements(BMIMeasurement measurement)
    {
        bMIMeasurements.Add(measurement);
    }

    internal static double CalculateBMI(BMIMeasurement measurement)
    {
        double height = measurement.Height;

        double BMI = measurement.Weight / (height / 100 * height / 100);
        BMI = Math.Round(BMI, 2);
        return BMI;
    }
    internal static BMIDesignation GetDesignation(double bMI)
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
    
    
    internal void GetBMI()
    {
        Console.Clear();

        Menu.Info("BMI-Calculator\n");

        BMIMeasurement measurement = GetBMIMeasurement(GetPerson());

        measurement.BMI = BMIManager.CalculateBMI(measurement);
        measurement.Designation = GetDesignation(measurement.BMI);
        AddToMeasurements(measurement);

        Menu.OutputBMI(measurement);
        Menu.InfoWait("Please press any Key to return to Menu");
        Console.Clear();
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
        measurement.Age = Calculator.CalculateAge(measurement);

        Console.Clear();
        return measurement;
    }
}
