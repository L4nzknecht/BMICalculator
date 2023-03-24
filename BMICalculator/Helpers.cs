namespace BMICalculator;

internal class Helpers
{
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
