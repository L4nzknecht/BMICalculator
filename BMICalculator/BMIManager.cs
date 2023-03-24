using BMICalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMICalculator
{
    internal class BMIManager
    {
        private Calculator calc;

        public BMIManager()
        {
            calc = new Calculator();
        }

        public void Loop()
        {
            int choice = 0;
            
            do
            {
                choice = Menu.MenuMain();
                Helpers.Clear();
                switch (choice)
                {
                    case 1:
                        Helpers.Info("BMI-Calculator\n");

                        BMIMeasurement measurement = GetBMIMeasurement(GetPerson());

                        measurement.BMI = calc.CalculateBMI(measurement);
                        Helpers.AddToMeasurements(measurement);
                        OutputBMI(measurement.BMI);
                        
                        break;
                    case 2:
                        Menu.PrintPersons();
                        break;
                    case 3:
                        break;
                    default:
                        Helpers.Info($"unknown choice {choice}, please try again");
                        break;

                }
                Helpers.InfoWait();
                Helpers.Clear();
            } while (choice != 3);
            
        }

        private void OutputBMI(double bmi)
        {
            Helpers.Info(
                $"\n" +
                $"Your BMI: {bmi:0.##}\n" +
                $"\n" +
                $"BMI < 18,5         - Underweight\n" +
                $"BMI 18,5 to 24,9   - Normal\n" +
                $"BMI 25 to 29,9     - Overweight\n" +
                $"BMI 30 and up      - Adipositas");
        }
        internal static Person GetPerson()
        {
            Person person = new Person { };

            person.Surname = Helpers.GetInput("Please enter your Surname");
            person.Firstname = Helpers.GetInput("Please enter your Firstname");
            person.Birthday = Helpers.GetDateOnly("Please enter your bithday");
            person.Gender = Helpers.GetGender();
            Helpers.AddToPersons(person);
            return person;
        }
        internal static BMIMeasurement GetBMIMeasurement(Person person)
        {
            BMIMeasurement measurement = new BMIMeasurement { };

            measurement.Person = person;
            measurement.height = int.Parse(Helpers.ValidateNumber(Helpers.GetInput("Please enter your height in Centimeters")));
            measurement.weight = int.Parse(Helpers.ValidateNumber(Helpers.GetInput("Please enter your weight in kilograms")));
            measurement.Date = DateTime.Now;
            return measurement;
        }
    }
}
