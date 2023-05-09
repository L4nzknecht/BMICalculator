using BMICalculator.Manager;
using BMICalculator.Models;
using System.Diagnostics.Metrics;

namespace BMICalculator;

internal class Menu
{
    internal static void MenuMain()
    {
        int choice;
        do
        {
            Menu.Info("BMI-Calculator");

            var varchoice = Menu.GetInput(
                "Please choose one of the following\n" +
                "1 - Enter OutputMeasurement\n" +
                "2 - Recent Calculations\n" +
                "3 - listOfWarnings\n" +
                "99 - End");

            varchoice = varchoice.ToLower();
            if (varchoice.Contains("c") || varchoice.Contains("b"))
            {
                varchoice = "1";
            }
            if (varchoice.Contains("r"))
            {
                varchoice = "2";
            }
            if (varchoice.Contains("w"))
            {
                varchoice = "3";
            }
            if (varchoice.Contains("e") || varchoice.Contains("99"))
            {
                varchoice = "99";
            }
            choice = int.Parse(Menu.ValidateNumber(varchoice));
            switch (choice)
            {
                case 1:
                    MeasurementManager.GetMeasurement();
                    break;
                case 2:
                    PrintListOfMeasurements(MeasurementManager.listOfMeasurements, "all warnings");
                    break;
                case 3:
                    PrintListOfMeasurements(WarningManager.listOfWarnings, "warnings");
                    break;
                case 99:
                    break;
                default:
                    Menu.Info($"unknown choice {choice}, please try again");
                    break;
            }
            Console.Clear();
        } while (choice != 99);
    }
    internal static void PrintListOfMeasurements(List<Measurement> measurements, string message)
    {
        var LoM = measurements.OrderByDescending(x => x.Date);
        Console.Clear();
        Console.WriteLine($"List of {message}");
        Console.WriteLine("Ordered by Date");
        Console.WriteLine("----------------------------------");
        foreach (var measurement in LoM)
        {
            Menu.OutputMeasurement(measurement);
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Press any key to go back to the Menu");
        Console.ReadLine();
    }
    internal static void PrintListOfMeasurements(List<Warning> warnings, string message)
    {
        var LoW = warnings.OrderByDescending(x => x.measurement.Date);
        Console.Clear();
        Console.WriteLine($"List of {message}");
        Console.WriteLine("Ordered by Date");
        Console.WriteLine("----------------------------------");
        foreach (var warning in LoW)
        {
            OutputMeasurement(warning.measurement);
            Console.WriteLine($"   Warning: {warning.Message}");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Press any key to go back to the Menu");
        Console.ReadLine();
    }
    internal static void OutputMeasurement(Measurement measurement)
    {
        Console.WriteLine($"" +
            $"Date: {measurement.Date:dd/MM/yyyy} - " +
            $"Name: {measurement.Person.Lastname}, {measurement.Person.Firstname} - " +
            $"Age: {measurement.Age} - "/* +*/
            //$"Height: {measurement.Height} cm - " +
            //$"Weigt: {measurement.Weight} kg - " +
            //$"BMI: {measurement.BMI} - " +
            //$"Designation: {measurement.Designation}"
            )            ;
    }
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
    internal static string GetInput(string message)
    {
        Info(message);
        var input = Console.ReadLine();
        while (input == null)
        {
            Info("Input invalid, try again");
            input = Console.ReadLine();
        }
        return input;
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
    internal static DateOnly GetDateOnly(string message)
    {
        Console.WriteLine($"{message}");

        DateOnly dateOnly;
        while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly))
        {
            Console.WriteLine("Please enter the date as yyyy/MM/dd");
        }
        Console.Clear();
        return dateOnly;
    }
}
