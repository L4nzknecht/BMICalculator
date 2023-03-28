using BMICalculator.Models;

namespace BMICalculator;

internal class BMIManager
{
    private Calculator calc;
    internal static BMIManager bMI = new BMIManager();

    internal static List<BMIMeasurement> bMIMeasurements = new List<BMIMeasurement> 
    { 
    //    new BMIMeasurement(Lastname = "Platl", Fistname = "Henri", Birthday = 02.05.1993, Gender = Gender.male, Height = 180, Weight = 100, Date = DateTime.Now.AddDays(-1), Age = 29, BMI 
    };
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
