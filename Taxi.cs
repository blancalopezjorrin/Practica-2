using System.ComponentModel;
using System.Xml.Linq;

namespace Practice1
{
    class Taxi : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances.
        private static string typeOfVehicle = "Taxi";
        private bool isCarryingPassengers;
        private City? _city;

        public Taxi(string plate, City? city) : base(typeOfVehicle, plate)
        {
            //Values of atributes are set just when the instance is done if not needed before.
            isCarryingPassengers = false;
            SetSpeed(45.0f);
            _city = city;

        }

        public City? City
        {
            get { return _city; }
            set { _city = value; }
        }

        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                if (City != null)
                {
                    isCarryingPassengers = true;
                    SetSpeed(100.0f);
                    Console.WriteLine(WriteMessage("starts a ride."));
                }
                else 
                {
                    Console.WriteLine(WriteMessage("doesn't have a license."));
                }


            }
            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }
    }
}