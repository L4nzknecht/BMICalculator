using BMICalculator.Interfaces;
using BMICalculator.Models;

namespace BMICalculator.Manager;

internal class PersonManager
{
    internal static List<Person> listOfPersons = new() { };
    internal static void AddToPersons(Person person)
    {
        listOfPersons.Add(person);
    }



    internal static Person CreatePerson()
    {
        Person person = new()
        {
            Lastname = Menu.GetInput("Please enter your Lastname"),
            Firstname = Menu.GetInput("Please enter your Firstname"),
            Birthday = Menu.GetDateOnly("Please enter your Birthday"),
            Gender = GetGender()
        };
        return person;
    }
    private static Gender GetGender()
    {
        bool chosen = false;
        Gender Gender = Gender.other;
        do
        {
            Console.Clear();
            Console.WriteLine("" +
                "Please choose a gender\n" +
                "m - male\n" +
                "f - female\n" +
                "o - other\n");

            var genderSelected = Console.ReadLine();

            switch (genderSelected.Trim().ToLower())
            {
                case "m":
                    Gender = Gender.male;
                    chosen = true;
                    break;
                case "f":
                    Gender = Gender.female;
                    chosen = true;
                    break;
                case "o":
                    Gender = Gender.other;
                    chosen = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input, choose 'm','f' or 'o'");
                    break;
            }
        } while (!chosen);

        return Gender;
    }


}
