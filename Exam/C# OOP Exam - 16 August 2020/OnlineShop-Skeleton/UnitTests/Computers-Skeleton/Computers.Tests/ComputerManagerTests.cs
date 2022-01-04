using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }


        [Test]
        public void Counter_IsZeroByDefault()
        {
            Assert.That(this.computerManager.Count, Is.Zero);
        }

        [Test]
        public void Counter_EncreasesWhenAddingComputer()
        {
            computerManager.AddComputer(new Computer("Lenovo", "460", 2000));
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddComputer_ThrowsExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ThrowsExceptionWhenComputerExists()
        {
            var computer = "Lenovo";
            var model = "460";
            var price = 2000;
            computerManager.AddComputer(new Computer(computer, model, price));

            Exception ex = Assert.Throws<ArgumentException>(() => computerManager.AddComputer(new Computer(computer, model, price)));
            Assert.AreEqual(ex.Message, "This computer already exists.");
        }

        [Test]
        public void AddComputer_ReturnsExpectedResultMessage()
        {
            var computer = "Lenovo";
            var model = "460";
            var price = 2000;
            computerManager.AddComputer(new Computer(computer, model, price));
            var expected = 1;
            Assert.That(expected, Is.EqualTo(computerManager.Count));
        }
        [Test]
        public void RemoveComputer_ReturnsExpectedResultMessage()
        {
            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 200000));

            var computer = computerManager.RemoveComputer("1", "1");

            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
            Assert.That(computerManager.Count, Is.EqualTo(1));

            Assert.That(computer.Manufacturer, Is.EqualTo("1"));
            Assert.That(computer.Model, Is.EqualTo("1"));
            Assert.That(computer.Price, Is.EqualTo(20000));
        }


        [Test]
        public void Remove_Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.RemoveComputer(null, "10"),
                "Value is not null.");
        }

        [Test]
        public void Get_Computer_Method_Should_Throw_An_Exception_If_Computer_Is_Null()
        {
            

            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer("1", "1"),
                "This computer is not null.");
        }

        [Test]
        public void Get_Computers__Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
            

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "10"),
                "Value is not null.");
        }

        [Test]
        public void Get_Computers__Method_Should_Throw_An_Exception_If_The_Model_Is_Null()
        {
           

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("10", null),
                "Value is not null.");
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Return_Correct_Result()
        {
            

            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 100));
            computerManager.AddComputer(new Computer("2", "3", 200));
            computerManager.AddComputer(new Computer("2", "4", 300));

            var computers = computerManager
                .GetComputersByManufacturer("2")
                .ToList();

            Assert.That(computers.Count, Is.EqualTo(3));

            Assert.That(computers[0].Manufacturer, Is.EqualTo("2"));
            Assert.That(computers[1].Manufacturer, Is.EqualTo("2"));
            Assert.That(computers[2].Manufacturer, Is.EqualTo("2"));

            Assert.That(computers[0].Model, Is.EqualTo("2"));
            Assert.That(computers[1].Model, Is.EqualTo("3"));
            Assert.That(computers[2].Model, Is.EqualTo("4"));

            Assert.That(computers[0].Price, Is.EqualTo(100));
            Assert.That(computers[1].Price, Is.EqualTo(200));
            Assert.That(computers[2].Price, Is.EqualTo(300));
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Return_Empty_Collection()
        {
          
            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 100));
            computerManager.AddComputer(new Computer("2", "3", 200));
            computerManager.AddComputer(new Computer("2", "4", 300));

            var computers = computerManager
                .GetComputersByManufacturer("51")
                .ToList();

            Assert.IsEmpty(computers);
            Assert.That(computers.Count, Is.EqualTo(0));
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
           
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null),
                "Value is not null.");
        }
    }

}