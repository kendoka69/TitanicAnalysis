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
        private static string female;
        private static string male;

        //private static string Female;
        //private static string Male;

        static void Main(string[] args)
        {

            List<Passenger> passengers = new List<Passenger>();
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
                        FemaleSurvivor(passengers, female);
                        break;
                    case "3":
                        MaleSurvivor(passengers, male);
                        break;

                    default:
                        Console.WriteLine("Please enter 1 or 2 or Q to quit");
                        break;
                }
                input = Console.ReadLine();
            }

            Console.ReadLine();

        }


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
            foreach (var passenger in passengers)
            {
                Console.WriteLine(passenger.ToString());
            }
        }

        public static List<Passenger> FemaleSurvivor(List<Passenger> passengers, string Sex)
        {
            List<Passenger> femaleSuvivor = new List<Passenger>();
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Sex == "Female" && passenger.Survived == "1")
                {
                    femaleSuvivor.Add(passenger);
                }
            }
            return femaleSuvivor;
        }

        public static List<Passenger> MaleSurvivor(List<Passenger> passengers, string Sex)
        {
            List<Passenger> maleSuvivor = new List<Passenger>();
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Sex == "Male" && passenger.Survived == "1")
                {
                    maleSuvivor.Add(passenger);
                }
            }
            return maleSuvivor;
        }
    }
}