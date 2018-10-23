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
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "TitanicData.csv");
            var fileContents = ReadTitanicData(fileName);
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<string[]> ReadTitanicData(string fileName)
        {
            var titanicData = new List<string[]>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    titanicData.Add(values);

                }
            }
            return titanicData;
        }

    }
}