namespace BMICalculator.Models;

internal class BMIMeasurement
{
    public Person Person { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public double BMI { get; set; }
    public DateTime Date { get; set; }
    public int Age { get; set; }
}
