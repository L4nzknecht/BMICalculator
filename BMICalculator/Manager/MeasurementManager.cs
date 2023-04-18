using BMICalculator.Interfaces;
using BMICalculator.Models;
using BMICalculator.Manager;

namespace BMICalculator.Manager;

internal class MeasurementManager
{
    internal static MeasurementManager mm = new();

    internal static List<Measurement> listOfMeasurements = new();
    internal static void AddToMeasurements(Measurement measurement)
    {
        MeasurementCheckers.CheckMeasurement(measurement);
        listOfMeasurements.Add(measurement);
    }

    internal static void GetMeasurement()
    {
        Person person = GetPerson();
        PersonManager.AddToPersons(person);
        Measurement measurement = new(person)
        {
            Date = DateTime.Now
        };
        measurement.Age = CalculateAge(measurement);

        bool entering = false;
        do
        {
            measurement = GetBMI(measurement);
            measurement = GetPulse(measurement);
            measurement = GetPressure(measurement);

        }while (entering);
        

        AddToMeasurements(measurement);
    }



    private static Person GetPerson()
    {
        Person person = PersonManager.CreatePerson();
        return person;
    }
    internal static int CalculateAge(Measurement measurement)
    {

        int years = measurement.Date.Year - measurement.Person.Birthday.Year;

        if ((measurement.Person.Birthday.Month > measurement.Date.Month) || (measurement.Person.Birthday.Month == measurement.Date.Month && measurement.Person.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }

    private static Measurement GetBMI(Measurement measurement)
    {
        measurement = BMIManager.CreateBMIMeasurement(measurement);
        return measurement;
    }
    private static Measurement GetPulse(Measurement measurement)
    {
        measurement = PulseManager.CreatePulseMeasuement(measurement);
        return measurement;
    }
    private static Measurement GetPressure(Measurement measurement)
    {
        measurement = PressureManager.CreatePressureMeasuement(measurement);
        return measurement;
    }

}
