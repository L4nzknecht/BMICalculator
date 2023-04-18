﻿using BMICalculator.Models;

namespace BMICalculator.Manager;

internal class PulseManager
{
    internal static Measurement CreatePulseMeasuement(Measurement measurement)
    {
        Console.Clear();

        Menu.Info("Pulse-Measurements\n");

        measurement.Pulse = int.Parse(Menu.ValidateNumber(Menu.GetInput("Please enter your Pulse in Hertz(1/s)")));

        Menu.InfoWait("Please press any Key to return to Selection");
        Console.Clear();
        return measurement;
    }
}
