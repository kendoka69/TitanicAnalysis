using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanicAnalysis
{
    public class Passenger
    {
        
        public string Survived { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        public string GetSurvivors()
        {
            return Survived;
        }

        public override string ToString()
        {
            return "Name: " + LastName + ", " + FirstName + "   Age: " + Age;
        }        
    }
}
