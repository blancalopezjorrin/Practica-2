namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City("Madrid");
            Console.WriteLine(city.WriteMessage("Created"));

            Precinct precinct = new Precinct("Precinct 1", city);
            Console.WriteLine(precinct.WriteMessage("Created"));

            Taxi taxi1 = new Taxi("0001 AAA", city);
            Console.WriteLine(taxi1.WriteMessage("Created"));


            Taxi taxi2 = new Taxi("0002 BBB", city);
            Console.WriteLine(taxi2.WriteMessage("Created"));


            SpeedRadar radar1 = new SpeedRadar();
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", precinct, radar1);

            PoliceCar policeCar2 = new PoliceCar("0002 CNP", precinct);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", precinct);

            Scooter scooter = new Scooter();

            policeCar3.StartPatrolling();

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();
            taxi1.StartRide();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

        }
    }
}
    

