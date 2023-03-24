using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Models;

internal class Person
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

