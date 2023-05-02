using BMICalculator.Interfaces;

namespace BMICalculator.Models;

internal class Person : IPerson
{
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public DateOnly Birthday { get; set; }
    public Gender Gender { get; set; }
    public Person() { }
    public Person(string firstName, string lastName, DateOnly date, Gender gender)
    {
        Lastname = lastName;
        Firstname = firstName;
        Birthday = date;
        Gender = gender;
    }
}



