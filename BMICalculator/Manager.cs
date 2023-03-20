using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    internal class Manager
    {
        private List<double> recent;
        private ConsoleIO io;
        private Calculator calc;

        public Manager()
        {
            io = new ConsoleIO();
            calc = new Calculator();
            recent = new List<double>();
        }

        public void Loop()
        {
            int choice = 0;
            
            do
            {
                choice = MenuMain();
                io.Clear();
                switch (choice)
                {
                    case 1:
                        io.Info("BMI-Calculator\n");
                        double bmi = MenuBMI();
                        OutputBMI(bmi);
                        recent.Add(bmi);
                        break;
                    case 2:
                        OutputRecent();
                        break;
                    case 3:
                        break;
                    default:
                        io.Info($"unknown choice {choice}, please try again");
                        break;

                }
                io.InfoWait();
                io.Clear();
            } while (choice != 3);
            
        }
        private void OutputRecent()
        {
            io.Clear();
            io.Info("List of recent BMI");
            //foreach
        }
        private double MenuBMI()
        {
            double bmi;
            double height;
            double weight;
            string s;

            do
            {
                s = io.GetInput("Please Enter your Height");
            } while (!Containsnumber(s));
            height = GetNumber(s);
            height = height / 100;
            
            do
            {
                s = io.GetInput("Please Enter your Weight");
            } while (!Containsnumber(s));
            weight = GetNumber(s);

            bmi = calc.CalculateBMI(height, weight);
            return bmi;
        }
        private void OutputBMI(double bmi)
        {
            io.Info(
                $"\n" +
                $"Your BMI: {bmi:0.##}\n" +
                $"\n" +
                $"BMI < 18,5         - Underweight\n" +
                $"BMI 18,5 to 24,9   - Normal\n" +
                $"BMI 25 to 29,9     - Overweight\n" +
                $"BMI 30 and up      - Adipositas");
        }
        private int MenuMain()
        {
            int choice = 0;
            io.Info("BMI-Calculator");
            var varchoice = io.GetInput(
                "Please choose one of the following\n" +
                "1 - BMI Calculator\n" +
                "2 - Recent Calculations\n" +
                "3 - End");
            if(Containsnumber(varchoice))
            {
                choice = GetNumber(varchoice);
            }
            else
            {
                varchoice = varchoice.ToLower();
                if (varchoice.Contains("c") || varchoice.Contains("b"))
                {
                    choice = 1;
                }
                if (varchoice.Contains("r"))
                {
                    choice = 2;
                }
                if (varchoice.Contains("e"))
                {
                    choice = 3;
                }
            }
            io.Clear();
            return choice;
        }
        private bool Containsnumber(string s)
        {
            bool containsnumber = false;
            foreach(char c in s.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    containsnumber = true;
                    break;
                }
            }
            return containsnumber;
        }
        private int GetNumber(string s)
        {
            string num = "";
            foreach (char c in s.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    num += c.ToString();
                }
            }
            
            int number = int.Parse(num);
            return number;
        }
    }
}
