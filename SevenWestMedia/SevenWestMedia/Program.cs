using JsonHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWestMedia
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleQueries query = new PeopleQueries(Helper.ReadJson());

            // First Request
            long id = 0;
            do
            {
                Console.Write("Please enter id of the person : ");
            } while (!Int64.TryParse(Console.ReadLine(), out id));

            string name = query.PersonFullNameById(id);
            Console.WriteLine(name);

            // Second Request
            long age = 0;
            do
            {
                Console.Write("\nPlease enter age of the person : ");
            } while (!Int64.TryParse(Console.ReadLine(), out age));

            string nameByAge = query.PersonByAge(age);
            Console.WriteLine(nameByAge);

            // Third Request
            Console.Write("\nPlease enter Y/N to get Gender by age : ");
            string yesno = Console.ReadLine().ToUpper();
            if (yesno == "Y")
            {
                string listOfNames = query.GendersPerAge();
                Console.Write(listOfNames);
            }

            Console.Read();
        }
    }
}
