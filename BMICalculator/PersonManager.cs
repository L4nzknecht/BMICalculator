using BMICalculator.Models;

namespace BMICalculator;

internal class PersonManager
{
    internal static List<Person> persons = new List<Person> { };
    internal void AddToPersons(Person person)
    {
        persons.Add(person);
    }

    internal Person CreatePerson()
    {
        Person person = new Person
        {
            Surname = Helpers.GetInput("Please enter your Surname"),
            Firstname = Helpers.GetInput("Please enter your Firstname"),
            Birthday = Helpers.GetDateOnly("Please enter your Birthday"),
            Gender = GetGender()
        };

        AddToPersons(person);
        return person;
    }
    internal Gender GetGender()
    {
        bool chosen = false;
        Gender Gender = Gender.other;
        do
        {
            Console.Clear();
            Console.WriteLine("" +
                "Please choose a difficulty\n" +
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
