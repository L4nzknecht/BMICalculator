using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Manager;

internal class WarningManager
{
    internal static List<Warning> listOfWarnings = new();

    internal static void Add(Warning warning)
    {
        listOfWarnings.Add(warning);
    }


}
