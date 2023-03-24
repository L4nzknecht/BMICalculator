using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Models;

internal class BMIMeasurement
{
    public Person Person { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
    public double BMI { get; set; }
    public DateTime Date { get; set; }
}
