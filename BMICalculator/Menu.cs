using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator;

internal class Menu
{
    internal static int MenuMain()
    {
        int choice = 0;
        Helpers.Info("BMI-Calculator");

        var varchoice = Helpers.GetInput(
            "Please choose one of the following\n" +
            "1 - BMI Calculator\n" +
            "2 - Recent Calculations\n" +
            "3 - End");

        varchoice = varchoice.ToLower();
        if (varchoice.Contains("c") || varchoice.Contains("b"))
        {
            varchoice = "1";
        }
        if (varchoice.Contains("r"))
        {
            varchoice = "2";
        }
        if (varchoice.Contains("e"))
        {
            varchoice = "3";
        }
        choice = int.Parse(Helpers.ValidateNumber(varchoice));
        return choice;
    }



    internal static void PrintPersons()
    {
        //var gamesToPrint = games.Where(x => x.Type == GameType.Division).OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("----------------------------------");
        foreach (var measurement in Helpers.bMIMeasurements)
        {
            Console.WriteLine($"Name: {measurement.Person.Surname}, {measurement.Person.Firstname} - Age: {Helpers.CalculateAge(measurement)} - BMI: {measurement.BMI}");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Press any key to go back to the Menu");
        Console.ReadLine();
    }
}
