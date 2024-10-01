using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class Scooter : UnregisteredVehicle
    {
        private const string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)
        {
            SetTypeOfVehicle(typeOfVehicle);
            Console.WriteLine(WriteMessage("Created"));
        }
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }

    }
}
