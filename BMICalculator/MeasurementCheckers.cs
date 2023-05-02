﻿using BMICalculator.Interfaces;
using BMICalculator.Manager;
using BMICalculator.Models;
using System.Diagnostics.Metrics;

namespace BMICalculator;

internal class MeasurementCheckers
{
    internal static void CheckMeasurement(Measurement measurement)
    {
        if (measurement.BMI.HasValue)
        {
            CheckBMI(measurement);
        }
        if (measurement.Pulse.HasValue)
        {
            CheckPulse(measurement);
        }
        //if (measurement.Bloodpressure.HasValue)
        //{
        //    CheckBloodpressure(measurement);
        //}
    }

    private static void CheckBloodpressure(Measurement measurement)
    {   
        if (measurement.Bloodpressure.BloodpressureSYS <= 130 && measurement.Bloodpressure.BloodpressureDIA <= 85)
        {
            return;
        }
        else if (measurement.Bloodpressure.BloodpressureSYS <= 139 && measurement.Bloodpressure.BloodpressureDIA <= 89)
        {
            WarningManager.Add(new Warning(measurement, "Bloodpressure too high, please check again", 0));
        }
        else if (measurement.Bloodpressure.BloodpressureSYS <= 159 && measurement.Bloodpressure.BloodpressureDIA <= 99)
        {
            WarningManager.Add(new Warning(measurement, "Bloodpressure too high, please check again", 1)); 
        }
        else if (measurement.Bloodpressure.BloodpressureSYS <= 179 && measurement.Bloodpressure.BloodpressureDIA <= 109)
        {
            WarningManager.Add(new Warning(measurement, "Bloodpressure too high, please check again", 2));
        }
        else if (measurement.Bloodpressure.BloodpressureSYS  > 179 && measurement.Bloodpressure.BloodpressureDIA > 109)
        {
            WarningManager.Add(new Warning(measurement, "Bloodpressure too high, please check again", 3));
        }
    }

    private static void CheckPulse(Measurement measurement)
    {
        if (measurement.Age < 1)
        {
            if (measurement.Pulse < 120)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too low", 1));
            }
            if (measurement.Pulse < 140)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too high", 1));
            }
        }
        if (1 <= measurement.Age && measurement.Age < 3)
        {
            if (measurement.Pulse < 100)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too low", 1));
            }
            if (measurement.Pulse < 120)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too high", 1));
            }
        }
        if (3 <= measurement.Age && measurement.Age < 18)
        {
            if (measurement.Pulse < 80)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too low", 1));
            }
            if (measurement.Pulse < 100)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too high", 1));
            }
        }
        if (18 <= measurement.Age)
        {
            if (measurement.Pulse < 60)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too low", 1));
            }
            if (measurement.Pulse < 80)
            {
                WarningManager.Add(new Warning(measurement, "Pulse too high", 1));
            }
        }

    }

    private static void CheckBMI(Measurement measurement)
    {
        if (measurement.Age >= 18)
        {
            if (measurement.Designation == BMIDesignation.AdipositasI)
            {
                WarningManager.Add(new Warning(measurement, "BMI too high", 2));
            }
            if (measurement.Designation == BMIDesignation.AdipositasII)
            {
                WarningManager.Add(new Warning(measurement, "BMI too high", 3));
            }
            if (measurement.Designation == BMIDesignation.AdipositasIII)
            {
                WarningManager.Add(new Warning(measurement, "BMI too high", 4));
            }
            if (measurement.Designation == BMIDesignation.overweight)
            {
                WarningManager.Add(new Warning(measurement, "BMI high", 1));
            }
            if (measurement.Designation == BMIDesignation.underweight)
            {
                WarningManager.Add(new Warning(measurement, "BMI too low", 1));
            }
        }

    }
}
