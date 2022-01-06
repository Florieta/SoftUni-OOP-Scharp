using NUnit.Framework;
using TheRace;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void Ctor_ReturnTheCorrectValues()
        {
            Assert.IsNotNull(raceEntry);
        }
        [Test]
        public void Count_IsZeroByDefault()
        {
            Assert.That(this.raceEntry.Counter, Is.Zero);
        }
        [Test]
        public void Count_ReturnTheCorrectResult()
        {
            raceEntry.AddDriver(new UnitDriver("a", new UnitCar("a", 200, 100)));
            int result = 1;
            Assert.AreEqual(result, raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ThrowsExceptionWhenDriverHasAlreadyExisted()
        {
            raceEntry.AddDriver(new UnitDriver("a", new UnitCar("b", 200, 100)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("a", new UnitCar("c", 400, 100))));

        }
        [Test]
        public void AddDriver_ThrowsExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }


        [Test]
        public void AddDriver_WorksCorrectly()
        {
            raceEntry.AddDriver(new UnitDriver("a", new UnitCar("b", 200, 100)));
            raceEntry.AddDriver(new UnitDriver("b", new UnitCar("c", 200, 100)));
            raceEntry.AddDriver(new UnitDriver("c", new UnitCar("d", 200, 100)));


            Assert.AreEqual(3, raceEntry.Counter);

        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsExcWhenParticipandLessthan2()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
            raceEntry.AddDriver(new UnitDriver("a", new UnitCar("b", 200, 100)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

        }
        [Test]
        public void CalculateAverageHorsePower_WorksCorrectly()
        {
            raceEntry.AddDriver(new UnitDriver("a", new UnitCar("b", 200, 100)));
            raceEntry.AddDriver(new UnitDriver("b", new UnitCar("c", 200, 100)));
            raceEntry.AddDriver(new UnitDriver("c", new UnitCar("d", 200, 100)));
            

            Assert.AreEqual(200, raceEntry.CalculateAverageHorsePower());

        }
    }
}