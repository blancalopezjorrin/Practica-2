using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice1
{
    internal class City
    { 
        private string _name;

        public City(string name)
        {
            _name = name;
        }

        public string cityName()
        {
            return _name;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"City {cityName()}";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }

        public void AddTaxiLicense(Taxi taxi)
        {
            taxi.City = this;
        }

        public void WithdrawTaxiLicense(Taxi taxi)
        {
            taxi.City = null;
            Console.WriteLine(WriteMessage($"Taxi {taxi.GetPlate()} withdrawn license."));
        }




    }
}
