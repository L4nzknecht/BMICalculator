namespace BMICalculator;

internal class Menu
{
    internal static void MenuMain()
    {
        int choice;
        do
        {
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
            if (varchoice.Contains("e") || varchoice.Contains("3"))
            {
                varchoice = "99";
            }
            choice = int.Parse(Helpers.ValidateNumber(varchoice));
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
                    Helpers.Info($"unknown choice {choice}, please try again");
                    break;
            }
            Helpers.InfoWait();
            Console.Clear();
        } while (choice != 3);
    }

    internal static void PrintPersons()
    {
        //var gamesToPrint = games.Where(x => x.Type == GameType.Division).OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("----------------------------------");
        foreach (var measurement in BMIManager.bMIMeasurements)
        {
            Console.WriteLine($"Name: {measurement.Surname}, {measurement.Firstname} - Age: {measurement.Age} - BMI: {measurement.BMI}");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Press any key to go back to the Menu");
        Console.ReadLine();
    }
}
