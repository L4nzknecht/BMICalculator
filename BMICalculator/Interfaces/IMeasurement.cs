using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Interfaces
{
    internal interface IMeasurement
    {
        public Person Person { get; set; }

        public DateTime Date { get; set; }
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
}
