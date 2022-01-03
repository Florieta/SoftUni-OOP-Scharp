namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(2);
            this.robot = new Robot("A", 20);
        }

        [Test]
        public void Count_IsZeroByDefault()
        {
            Assert.That(this.robotManager.Count, Is.Zero);
        }
        [Test]
        public void Count_ReturnTheCorrectResult()
        {
            robotManager.Add(robot);
            int result = 1;
            Assert.AreEqual(result, robotManager.Count);
        }
        
        [Test]
        public void Capacity_ThrowsExceptionWhenCapacityIsInvalid()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                robotManager = new RobotManager(-2);
            });
            Assert.AreEqual(ex.Message, "Invalid capacity!");
        }

        [Test]
        public void AddRobot_ThrowsExceptionWhenRobotHasAlreadyExisted()
        {
            string robotName = "A";
            Robot robot = new Robot(robotName, 20);
            robotManager.Add(robot);
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
               robotManager.Add(new Robot(robotName, 20));
            });
            Assert.AreEqual(ex.Message, $"There is already a robot with name {robotName}!");
        }

        [Test]
        public void AddRobot_ThrowsExceptionWhenCapacityIsNotEnough()
        {
            
            Robot robot1 = new Robot("A", 20);
            robotManager.Add(robot1);
            Robot robot2 = new Robot("B", 20);
            robotManager.Add(robot2);
            Robot robot3 = new Robot("C", 20);
            
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            });
            Assert.AreEqual(ex.Message, "Not enough capacity!");
        }

        [Test]

        public void RemoveRobot_ThrowsExceptionWhenRobotWithThisNameDoesNotExist()
        {
            Robot robot1 = new Robot("A", 20);
            robotManager.Add(robot1);
            Robot robot2 = new Robot("B", 20);
            robotManager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("C"));

        }
        [Test]

        public void Remove_ThrowsExcWhenRobotNotFpund()
        {
            Robot robot1 = new Robot("A", 20);
            robotManager.Add(robot1);
            string robotName = "C";
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("C");
            });
            Assert.AreEqual(ex.Message, $"Robot with the name {robotName} doesn't exist!");
        }


        [Test]
        public void WorksThrowsExWhenDoesntExists()
        {
            Assert.That(() => robotManager.Work("Goo", "kopaene", 3), Throws.InvalidOperationException);
        }
        [Test]
        public void WorksThrowsExWhenBatteryIsSmaller()
        {

            Robot robot = new Robot("Gosho", 5);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Work("Gosho", "kopaene", 20), Throws.InvalidOperationException);
        }
        [Test]
        public void WorksWorksFine()
        {

            Robot robot = new Robot("Gosho", 20);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "kopaene", 10);
            Assert.That(robot.Battery, Is.EqualTo(10));
        }
        [Test]
        public void ChargeThrowsExWhenDoesntExists()
        {
            Assert.That(() => robotManager.Charge("Goo"), Throws.InvalidOperationException);
        }
        [Test]
        public void ChargeWorksFine()
        {
            Robot robot = new Robot("Gosho", 20);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "kopaene", 10);
            robotManager.Charge("Gosho");
            Assert.That(robot.Battery, Is.EqualTo(20)); ;
        }
    }
}
