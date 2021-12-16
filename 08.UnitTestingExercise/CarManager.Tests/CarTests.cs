using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 5, 100)]
        [TestCase(null, "Model", 5, 100)]
        [TestCase("Make", "", 5, 100)]
        [TestCase("Make", null, 5, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", 5, 0)]
        [TestCase("Make", "Model",  5, -10)]

        public void ctor_ThrowsExceptionWhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        
        public void ctor_SetInitialValueAreValidArgument()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));

        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]

        public void Refuel_ThrowsExceptionWhenFuelIsZeroOrNegativeValue(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));

        }

        [Test]
        public void Refuel_IncreaseFuelAmountWhenFuelIsValid()
        {
            double refuelAMount = car.FuelCapacity / 2;
            car.Refuel(refuelAMount);
            Assert.That(car.FuelAmount, Is.EqualTo(refuelAMount));

        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity()
        {
            car.Refuel(car.FuelCapacity * 1.2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));

        }

        [Test]
        public void Drive_ThrowsExceptionWhenFuelIsZero()
        {

            Assert.Throws<InvalidOperationException>(() => car.Drive(100));

        }

        [Test]
        public void Drive_DecreaseFuelAmountWhenDistanceIsValid()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }
        [Test]
        public void Drive_DecreaseFuelToZeroWhenRequiredFuelIsEqualToFuelAmount()
        {
            car.Refuel(car.FuelCapacity);
            double distance = car.FuelCapacity * car.FuelConsumption;
            car.Drive(distance);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void FuelAmount_ThrowsExceptionWhenNegativeValueIsPassed()
        {
            car.Refuel(car.FuelCapacity);
            double beforeDrive = car.FuelAmount;
            car.Drive(100);
            double afterDrive = car.FuelAmount;
            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}