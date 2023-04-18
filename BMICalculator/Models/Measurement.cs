﻿using BMICalculator.Interfaces;

namespace BMICalculator.Models;

internal class Measurement : IMeasurement
{

    public Person Person { get; set; }

    public int Bloodpressure { get; set; }
    public int Pulse { get; set; }


    public int Height { get; set; }
    public int Weight { get; set; }
    public DateTime Date { get; set; }
    public int Age { get; set; }
    public double BMI { get; set; }
    public BMIDesignation Designation { get; set; }

    public Measurement(Person person)
    {
        Person = person;
    }
}


