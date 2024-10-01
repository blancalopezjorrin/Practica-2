using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    
    abstract class UnregisteredVehicle : IMessageWritter
    {
        private string typeOfVehicle;
        private float speed;

        public UnregisteredVehicle(string typeOfVehicle)
        {
            this.typeOfVehicle = typeOfVehicle;
            speed = 0f;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }

        public void SetTypeOfVehicle(string typeOfVehicle)
        {
            this.typeOfVehicle = typeOfVehicle;
        }
        public string GetTypeOfVehicle()
        {
            return typeOfVehicle;
        }


        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public virtual string WriteMessage(string message)
        {
            // Incorporamos tanto el tipo de vehículo como la placa en el mensaje
            return $"{GetTypeOfVehicle()}: {message}";
        }

    }
}

