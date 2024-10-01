namespace Practice1
{
    abstract class Vehicle : UnregisteredVehicle
    {
        private string plate;

        public Vehicle(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
            SetTypeOfVehicle(typeOfVehicle);
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }

        public string GetPlate()
        {
            return plate;
        }


        //Implment interface with Vechicle message structure
        public override string WriteMessage(string message)
        {
            // Incorporamos tanto el tipo de vehículo como la placa en el mensaje
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}: {message}";
        }
    }
}
