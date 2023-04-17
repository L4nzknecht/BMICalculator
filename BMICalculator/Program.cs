namespace BMICalculator;

internal class Program
{
    static void Main(string[] args)
    {
        Generator.GenerateBMIMeasurements();
        Menu.MenuMain();
    }
}