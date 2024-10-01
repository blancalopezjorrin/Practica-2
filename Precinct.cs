using System;

namespace Practice1
{
    internal class Precinct
    {
        private string _name;
        private List<PoliceCar> ListPoliceCars;
        private bool _alarm;
        private City _city;

        public Precinct(string name, City city)
        {
            _name = name;
            ListPoliceCars = new List<PoliceCar>();
            _alarm = false;
            _city = city;
        }

        public string precinctName()
        {
            return _name;
        }

        public string cityName()
        {
            return _city.cityName();
        }

        public List<PoliceCar> listPoliceCars()
        {
            return ListPoliceCars;
        }


        public bool Alarm
        {
            get { return _alarm; }
            set { _alarm = value; }
        }


        public void RegisterPoliceCar(PoliceCar coche)
        {
            ListPoliceCars.Add(coche);
            Console.WriteLine(WriteMessage($"registered PoliceCar with plate {coche.GetPlate()}"));

        }

        public void ActivateAlarm(PoliceCar Police, Taxi taxiOffender)
        {
            this.Alarm = true;
            Console.WriteLine(WriteMessage($"Alarm activated by {Police.GetPlate()} to chase {taxiOffender.GetPlate()}"));

            foreach (PoliceCar coche in ListPoliceCars)
            {
                if (coche.IsPatrolling())
                {
                    coche.EnterAlarmMode(taxiOffender);
                }
            }
        }

        public void DeactivateAlarm(PoliceCar Police, Taxi taxiOffender)
        {
            this.Alarm = false;
            _city.WithdrawTaxiLicense(taxiOffender);
            Console.WriteLine(WriteMessage($"Alarm deactivated police car {Police.GetPlate()}. Arrested {taxiOffender.GetPlate()}"));

            foreach (PoliceCar coche in ListPoliceCars)
            {
                coche.isChasing = null;
            }
        }


        //Override ToString() method with class information
        public override string ToString()
        {
            return $"Precinct {precinctName()} in {cityName()}";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }



    }
}
