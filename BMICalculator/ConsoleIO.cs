using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    internal class ConsoleIO
    {    
        public ConsoleIO() { }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }
        public void InfoWait(string message)
        {
            Info(message);
            Console.ReadKey();
        }
        public void InfoWait()
        {
            Console.ReadKey();
        }
        public string GetInput() 
        {
            var input = Console.ReadLine();
            while (input == null) 
            {
                Info("Input invalid, try again");
                input = Console.ReadLine();
            }
            return input;
        }
        public string GetInput(string message)
        {
            Info(message);
            return GetInput();
        }
        public void Clear()
        {
            Console.Clear();
        }
    }


}
