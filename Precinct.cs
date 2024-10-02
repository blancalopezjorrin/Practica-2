using System;

namespace Practice1
{
    internal class Precinct
    {
        private string _name;
        private List<PoliceCar> _listPoliceCars;
        private bool _alarm;
        private City _city;

        public Precinct(string name, City city)
        {
            _name = name;
            _listPoliceCars = new List<PoliceCar>();
            _alarm = false;
            _city = city;
        }


        public bool Alarm
        {
            get { return _alarm; }
            set { _alarm = value; }
        }


        public void RegisterPoliceCar(PoliceCar coche)
        {
            _listPoliceCars.Add(coche);
            Console.WriteLine(WriteMessage($"registered PoliceCar with plate {coche.GetPlate()}"));

        }

        public void ActivateAlarm(PoliceCar Police, Taxi taxiOffender)
        {
            this.Alarm = true;
            Console.WriteLine(WriteMessage($"Alarm activated by {Police.GetPlate()} to chase {taxiOffender.GetPlate()}"));

            foreach (PoliceCar coche in _listPoliceCars)
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

            foreach (PoliceCar coche in _listPoliceCars)
            {
                coche.isChasing = null;
            }
        }


        //Override ToString() method with class information
        public override string ToString()
        {
            return $"Precinct {_name} in {_city.CityName()}";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }



    }
}
