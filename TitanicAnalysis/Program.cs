using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TitanicAnalysis
{
    class Program
    {
        private static string Female;

        static void Main(string[] args)
        {

            //List<Passenger> passengers;
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "TitanicData.csv");
            var fileContents = ReadTitanicData(fileName);



            StringBuilder menu = new StringBuilder();
            menu.Append("----------------------------");
            menu.Append("\nTo sort surviors by gender, press 1 for female, press 2 for male");
            menu.Append("\n----------------------------");
            menu.Append("\nEnter Q to quit");

            Console.WriteLine(menu.ToString());

            var input = Console.ReadLine();

            while (input.ToUpper() != "Q")
            {
                switch (input)
                {
                    case "1":
                        PrintList(fileContents);
                        break;
                    case "2":
                        SurviorByGender();
                        break;



                    default:
                        Console.WriteLine("Please enter 1 or 2 or Q to quit");
                        break;
                }
                input = Console.ReadLine();
            }

            Console.ReadLine();

        }

        //private static void SurviorByGender(List<Passenger> fileContents)
        //{
        //    Console.WriteLine(,ToSt;
        //}

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<Passenger> ReadTitanicData(string fileName)
        {
            var titanicData = new List<Passenger>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var passenger = new Passenger();
                    string[] value = line.Split(',');

                    int parseInt;
                    if (int.TryParse(value[0], out parseInt))
                    {
                        passenger.PassClass = parseInt;
                    }
                    if (int.TryParse(value[5], out parseInt))
                    {
                        passenger.Age = parseInt;
                    }
                    passenger.Survived = value[1];
                    passenger.LastName = value[2];
                    passenger.FirstName = value[3];
                    passenger.Sex = value[4];

                    titanicData.Add(passenger);
                }
            }
            return titanicData;
        }
        private static void PrintList(List<Passenger> passengers)
        {

            foreach (var person in passengers)
            {

                Console.WriteLine(person.ToString());

            }
        }

        private static void SurviorByGender(List<Passenger> passengers, string Female)
        {
            foreach (var item in passengers)
            {
                int index = passengers.IndexOf(item);
            }
        }
    }
}