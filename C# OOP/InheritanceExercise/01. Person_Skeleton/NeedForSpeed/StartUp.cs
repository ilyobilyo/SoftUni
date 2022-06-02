namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle veh = new Vehicle(120, 60);
            Motorcycle moto = new Motorcycle(80, 30.6);
            Car car = new Car(200, 90);
            RaceMotorcycle rMoto = new RaceMotorcycle(110, 40.5);
            CrossMotorcycle cross = new CrossMotorcycle(80, 30);
            FamilyCar familyCar = new FamilyCar(80, 70);
            SportCar sCar = new SportCar(250, 100);


        }
    }
}
