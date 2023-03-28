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
            if (varchoice.Contains("e") || varchoice.Contains("3"))
            {
                varchoice = "99";
            }
            choice = int.Parse(Menu.ValidateNumber(varchoice));
            switch (choice)
            {
                case 1:
                    BMIManager.bMI.GetBMI();
                    break;
                case 2:
                    PrintPersons();
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
    internal static void PrintPersons()
    {
        Console.Clear();
        Console.WriteLine("List of old BMI Measurements");
        Console.WriteLine("----------------------------------");
        foreach (var measurement in BMIManager.bMIMeasurements)
        {
            Console.WriteLine($"Name: {measurement.Surname}, {measurement.Firstname} - Age: {measurement.Age} - BMI: {measurement.BMI}");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Press any key to go back to the Menu");
        Console.ReadLine();
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
        var dateOnly = new DateOnly();
        while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly))
        {
            Console.WriteLine("Please enter the date as yyyy/MM/dd");
        }
        Console.Clear();
        return dateOnly;
    }
}
