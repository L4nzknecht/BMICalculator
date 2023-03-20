using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    internal class Person
    {
        private double height;
        private double weight;
        private int age;
        private string surname;
        private string lastname;
        public Person(string surname, string lastname, int age, double height, double weight)
        {
            this.height = height;
            this.weight = weight;
            this.age = age;
            this.surname = surname;
            this.lastname = lastname;
        }
    }
}
