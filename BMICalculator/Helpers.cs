using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMICalculator;

internal class Helpers
{    
    public Helpers() { }
    internal static List<Person> persons = new List<Person>{ };
    internal static List<BMIMeasurement> bMIMeasurements = new List<BMIMeasurement> { };
    internal static void Info(string message)
    {
        Console.WriteLine(message);
    }
    internal static void InfoWait(string message)
    {
        Info(message);
        Console.ReadKey();
    }
    internal static void InfoWait()
    {
        Console.ReadKey();
    }
    internal static string GetInput() 
    {
        var input = Console.ReadLine();
        while (input == null) 
        {
            Info("Input invalid, try again");
            input = Console.ReadLine();
        }
        return input;
    }
    internal static string GetInput(string message)
    {
        Info(message);
        return GetInput();
    }
    internal static void Clear()
    {
        Console.Clear();
    }
    internal static string ValidateNumber(string answer)
    {
        while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
        {
            Console.WriteLine("Answer needs to be an Integer. Please try again.");
            answer = Console.ReadLine();
        }
        return answer;
    }
    internal static void AddToPersons(Person person)
    {
        persons.Add(person);
    }
    internal static void AddToMeasurements(BMIMeasurement measurement)
    {
        bMIMeasurements.Add(measurement);
    }
    internal static DateOnly GetDateOnly(string message)
    {
        Console.WriteLine($"{message}");
        var dateOnly = new DateOnly();
        while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly)) 
        {
            Console.WriteLine("Please enter the date as yyyy/MM/dd");
        }
        Console.Clear();
        return dateOnly;
    }
    internal static DateTime GetDateTime() { return DateTime.Now; }
    internal static Gender GetGender()
    {
        bool chosen = false;
        Gender Gender = Gender.other;
        do
        {
            Console.Clear();
            Console.WriteLine("" +
                "Please choose a Gender\n" +
                "m - male\n" +
                "f - female\n" +
                "o - other\n");

            var genderSelected = Console.ReadLine();

            switch (genderSelected.Trim().ToLower())
            {
                case "m":
                    Gender = Gender.male;
                    chosen = true;
                    break;
                case "f":
                    Gender = Gender.female;
                    chosen = true;
                    break;
                case "o":
                    Gender = Gender.other;
                    chosen = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        } while (!chosen);
        Console.Clear();
        return Gender;
    }
    internal static int CalculateAge(BMIMeasurement measurement)
    {

        int years = measurement.Date.Year - measurement.Person.Birthday.Year;

        if ((measurement.Person.Birthday.Month > measurement.Date.Month) || (measurement.Person.Birthday.Month == measurement.Date.Month && measurement.Person.Birthday.Day > measurement.Date.Day))
            years--;

        return years;
    }
}
