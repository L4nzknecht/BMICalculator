using BMICalculator.Models;

namespace BMICalculator;

internal interface IPerson
{
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public DateOnly Birthday { get; set; }
    public Gender Gender { get; set; }
}
