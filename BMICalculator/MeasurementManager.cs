using BMICalculator.Interfaces;
using BMICalculator.Models;

namespace BMICalculator;

internal class MeasurementManager
{
    internal static MeasurementManager bMI = new();

    internal static List<Measurement> bMIMeasurements = new List<Measurement> { };
    internal static void AddToMeasurements(Measurement measurement)
    {
        //check
        bMIMeasurements.Add(measurement);
    }

    internal static double CalculateBMI(Measurement measurement)
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

        Measurement measurement = GetBMIMeasurement(GetPerson());

        measurement.BMI = MeasurementManager.CalculateBMI(measurement);
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
    internal Measurement GetBMIMeasurement(Person person)
    {
        Measurement measurement = new Measurement(person) { };

        measurement.Person = person;
        measurement.Height = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Height in Centimeters")));
        measurement.Weight = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Weight in kilograms")));
        measurement.Date = DateTime.Now;
        measurement.Age = Calculator.CalculateAge(measurement);

        Console.Clear();
        return measurement;
    }
}
