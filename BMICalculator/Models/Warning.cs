using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator;

internal class Warning
{
    private Measurement measurement;
    public string Message { get; set; }
    public int Prio { get; set; }

    public Warning(Measurement m, string message, int prio)
    {
        this.measurement = m;
        Message = message;
        Prio = Prio;
    }

}
