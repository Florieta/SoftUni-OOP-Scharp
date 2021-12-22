namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {

        [Test]

        public void Constructor_InitializeCorrectly()
        {
            string name = "aname";
            int cap = 1;
            Aquarium aquarium = new Aquarium(name, cap);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, cap);
        }

        [Test]

        public void SetNameThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 1));
        }

        [Test]

        public void CapacityThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("a", -1));
           
        }

        [Test]

        public void Count()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("a"));
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]

        public void AddShouldThrowException()
        {
            Aquarium aquarium = new Aquarium("test", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("a")));

        }


        [Test]

        public void RemoveThrowsException()
        {
            Aquarium aquarium = new Aquarium("test", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));

        }
        [Test]

        public void Remove()
        {
            Aquarium aquarium = new Aquarium("test", 1);
            aquarium.Add(new Fish("a"));
            aquarium.RemoveFish("a");
            Assert.AreEqual(aquarium.Count, 0);

        }

        [Test]

        public void SelfFishShouldThrowsException()
        {
            Aquarium aquarium = new Aquarium("test", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));

        }
        [Test]
        public void SelfFish()
        {
            Aquarium aquarium = new Aquarium("test", 1);
            aquarium.Add(new Fish("a"));
            Fish fish = aquarium.SellFish("a");
            Assert.AreEqual(fish.Name, "a");
            Assert.AreEqual(fish.Available, false);
        }

        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium("test", 1);
            aquarium.Add(new Fish("a"));

            string expectedMessage = $"Fish available at test: a";
            Assert.AreEqual(expectedMessage, aquarium.Report());
        }
    }
}
