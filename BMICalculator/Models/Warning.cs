using BMICalculator.Models;

namespace BMICalculator;

internal class Warning
{
    public Measurement measurement;
    public string Message { get; set; }
    public int Prio { get; set; }

    public Warning(Measurement m, string message, int prio)
    {
        measurement = m;
        Message = message;
        Prio = prio;
    }

}
