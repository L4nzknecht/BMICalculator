namespace BMICalculator.Models;

internal class BMIMeasurement : IPerson
{

    //public Person Person { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public DateOnly Birthday { get; set; }
    public Gender Gender { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public DateTime Date { get; set; }
    public int Age { get; set; }
    public double BMI { get; set; }
    public BMIDesignation Designation { get; set; }
}
internal enum BMIDesignation
{
    underweight,
    normalweight,
    overweight,
    AdipositasI,
    AdipositasII,
    AdipositasIII
}