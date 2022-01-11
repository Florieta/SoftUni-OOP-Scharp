using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("a", 2);
        }

        [Test]
        public void CtorWorksProperly()
        {
            Assert.That(gym.Count, Is.EqualTo(0));
        }
        [Test]
        public void Count_IsZeroByDefault()
        {
            Assert.That(this.gym.Count, Is.Zero);
        }
        [Test]
        public void Count_ReturnTheCorrectResult()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            int result = 1;
            Assert.AreEqual(result, gym.Count);
        }
        [Test]
        public void Name_ThrowsExcWhenNameIsNullOrWhitespace()
        {

            Assert.Throws<ArgumentNullException>(() => gym = new Gym(null, 2));
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(string.Empty, 1));
        }

        [Test]
        public void Capacity_ThrowsExceptionWhenCapacityIsInvalid()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym("b", -2);
            });
            Assert.AreEqual(ex.Message, "Invalid gym capacity.");
        }

        [Test]
        public void AddAthlete_ThrowsExceptionWhenCountIsEqualToSize()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
            Athlete athlete2 = new Athlete("ad");
           
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
            Assert.AreEqual(ex.Message, "The gym is full.");
        }
        [Test]
        public void AddAthlete_WorksCorrectly()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
           
            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void Remove_ThrowsExceptionWhenAthleteIsNull()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
           

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("bc");
            });
            Assert.AreEqual(ex.Message, "The athlete bc doesn't exist.");
        }

        [Test]
        public void Remove_WorksCorrectly()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("ab");
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjureAthlete_ThrowsExceptionWhenAthleteIsNull()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
            
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("bc");
            });
            Assert.AreEqual(ex.Message, "The athlete bc doesn't exist.");
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(null));

        }
        [Test]
        public void InjureAthlete_WorksCorrectly()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
            var requestedAthlete = gym.InjureAthlete("ab");
            List<Athlete> injured = new List<Athlete>();
            injured.Add(requestedAthlete);
            Assert.AreEqual(1, injured.Count);
            Assert.AreEqual(requestedAthlete.FullName, "ab");
            Assert.AreEqual(requestedAthlete.IsInjured, true);
        }

        [Test]
        public void Report_ReturnTheCorrectResult()
        {
            Athlete athlete = new Athlete("ab");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("ac");
            gym.AddAthlete(athlete1);
            gym.InjureAthlete("ab");
            var report = gym.Report();
            var expected = "Active athletes at a: ac";
            Assert.AreEqual(expected, report);
        }
    }
}
