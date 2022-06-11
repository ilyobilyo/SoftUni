namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase(
            "Ford",
            "Focus",
            0.9,
            60.5)]
        [TestCase(
            "VW",
            "Golf",
            3.4,
            0.7)]
        public void Test_Constructors_Parameters(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.EqualTo(0));

        }


        [TestCase(
            null,
            "Focus",
            3.4,
            0.7)]
        [TestCase(
            "",
            "Golf",
            3.4,
            30.37)]
        [TestCase(
            "VW",
            "",
            3.4,
            30.37)]
        [TestCase(
            "Ford",
            null,
            3.4,
            0.7)]
        [TestCase(
            "VW",
            "Golf",
            -1.3,
            30.37)]
        [TestCase(
            "Ford",
            "Focus",
            0,
            0.7)]
        [TestCase(
            "VW",
            "Golf",
            1.2,
            -20.4)]
        [TestCase(
            "Ford",
            "Focus",
            1.1,
            0)]
        public void Test_Properties__Set_Invalid_Input(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            });

        }

        [TestCase(
            "Ford",
            "Focus",
            0.9,
            60.5,
            20.3,
            20.3)]
        [TestCase(
            "Ford",
            "Focus",
            0.9,
            20.5,
            22.3,
            20.5
            )]
        public void Test_Refuel_Car(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double expectedFuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [TestCase(
            "Ford",
            "Focus",
            0.9,
            60.5,
            0)]
        [TestCase(
            "Ford",
            "Focus",
            0.9,
            20.5,
            -20.6
            )]
        public void Test_Refuel_Car_With_Invalid_FuelToRefuel(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });

        }

        [TestCase(
             "Ford",
             "Focus",
             2.9,
             60.5,
             20.1,
             10.3,
             19.8013)]
        [TestCase(
             "Ford",
             "Focus",
             3.9,
             20.5,
             40.3,
             50.5,
             18.5305)]
        public void Test_Drive_Car(string make, string model, double fuelConsumption
            , double fuelCapacity, double fuelToRefuel,double distance , double expectedFuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [TestCase(
             "Ford",
             "Focus",
             2.9,
             60.5,
             5.1,
             1000.3)]
        [TestCase(
             "Ford",
             "Focus",
             3.9,
             20.5,
             0.3,
             50.5)]
        public void Test_Drive_Car_When_FuelAmount_Is_Not_Enough(string make, string model, double fuelConsumption
            , double fuelCapacity, double fuelToRefuel, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);

            });

        }
    }
}