namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private Precinct precinct;
        private Taxi? _isChasing;

        public PoliceCar(string plate, Precinct precinct_var, SpeedRadar? _speedRadar=null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            _isChasing = null;
            speedRadar = _speedRadar;
            precinct = precinct_var;
            precinct.RegisterPoliceCar(this);
        }

        public void UseRadar(Taxi vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null) 
                {
                    bool illegal = speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (illegal) { precinct.ActivateAlarm(this, vehicle); }
                }
                else { Console.WriteLine(WriteMessage("does not have a speed radar.")); }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }


        public Taxi? isChasing
        {
            get { return _isChasing; }
            set { _isChasing = value; }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
                if (precinct.Alarm) { precinct.DeactivateAlarm(this, isChasing);  }
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null) 
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else { Console.WriteLine(WriteMessage("does not have a speed radar.")); }
        }

        public void EnterAlarmMode(Taxi taxiOffender)
        {
            isChasing = taxiOffender;
            Console.WriteLine(this.WriteMessage($"chasing vehicle with plate {taxiOffender.GetPlate()}"));
        }
    }
}