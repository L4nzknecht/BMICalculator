namespace BMICalculator.Models;

internal class Person : IPerson
{
    public string Surname { get; set; }
    public string Firstname { get; set; }
    public DateOnly Birthday { get; set; }
    public Gender Gender { get; set; }
}
internal enum Gender
{
    male,
    female,
    other
}

