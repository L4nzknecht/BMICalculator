using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator;

internal class WarningManager
{
    internal static List<Warning> ListOfWarnings = new List<Warning>();

    internal static void Add(Warning warning)
    {
        ListOfWarnings.Add(warning);
    }
}
