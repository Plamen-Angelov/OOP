namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            robotManager = new RobotManager(3);
            robot = new Robot("Pesho", 30);
            robotManager.Add(robot);
        }

        [Test]
        public void CtorThrowsExceptionWhenCapacityIsLeccThanZerro()
        {

            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-5));
        }

        [Test]
        public void CtorCreateInctanceCorectly()
        {
            Assert.That(robotManager.Capacity == 3);
        }

        [Test]
        public void AddThrowsExceptionWhenAddingRobotExisitc()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddThrowsExceptionWhenWhenCapacityIsFull()
        {
            Robot robot1 = new Robot("Gosho", 25);
            Robot robot2 = new Robot("Kiro", 45);
            Robot robot3 = new Robot("Stefan", 32);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot3));
        }

        [Test]
        public void AddWorksCorectlyAndIncreasingTheCount()
        {
            Robot robot1 = new Robot("Gosho", 25);
            robotManager.Add(robot1);

            Assert.That(robotManager.Count == 2);
        }
        
        [Test]
        public void RemoveThrowsExceptionWhenRobotWithGivenNameNotExisits()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Gosho"));
        }

        [Test]
        public void RemoveWorksCorectly()
        {
            Robot robot1 = new Robot("Gosho", 25);
            Robot robot2 = new Robot("Kiro", 45);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Remove("Gosho");

            Assert.That(robotManager.Count == 2);
        }

        [Test]
        public void WorkThrowsExceptionWhenRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "alaBala", 20));
        }

        [Test]
        public void WorkThrowsExceptionWhenUsageIsMoreThanRobotsBattery()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Pesho", "alaBala", 40));
        }

        [Test]
        public void WorkWorksCorectly()
        {
            robotManager.Work("Pesho", "alaBala", 20);

            Assert.That(robot.Battery == 10);
        }

        [Test]
        public void ChargeThrowsExceptionWhenRobotWithGivenNameNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Gosho"));
        }

        [Test]
        public void ChargeWorksCorectly()
        {
            robotManager.Work("Pesho", "alaBala", 25);
            robotManager.Charge("Pesho");

            Assert.That(robot.Battery == robot.MaximumBattery);
            Assert.That(robot.Battery == 30);
        }
    }
}
