
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;
        private int damage;
        private int health;

        [SetUp]
        public void Setup()
        {
            damage = 20;
            health = 50;

            arena = new Arena();

            attacker = new Warrior("Attacker", damage, health);
            defender = new Warrior("Defender", damage, health);
        }

        [Test]
        public void EmptyConstructor_Initialises_EmptyWarriorList()
        {
            List<Warrior> expectedResult = new List<Warrior>();
            List<Warrior> actualResult = arena.Warriors.ToList();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WarriorsProperty_ShouldReturn_AddedWarriors()
        {
            //Arrange
            arena.Enroll(attacker);
            arena.Enroll(defender);

            //Act
            List<Warrior> expectedResult = new List<Warrior>()
            {
                attacker,
                defender
            };

            List<Warrior> actualResult = arena.Warriors.ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WarriorsCountProperty_Should_Return_InnerWarriorList_Count()
        {
            //Arrange
            arena.Enroll(attacker);
            arena.Enroll(defender);

            //Act
            int expectedResult = arena.Warriors.Count;
            int actualResult = arena.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Enroll_Should_ThrowException_When_TryingToAdd_Warrior_WithExistingName()
        {
            //Arrange
            int damage = 111;
            int hp = 222;
            arena.Enroll(attacker);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(attacker.Name, damage, health)));
        }

        [Test]
        public void FightMethod_Should_ThrowException_When_EitherAttackerName_NotPresent()
        {
            //Arrange
            string wrongNameOne = "wrongNameOne";
            string wrongNameTwo = "wrongNameTwo";

            arena.Enroll(attacker);
            arena.Enroll(defender);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<InvalidOperationException>(() => arena.Fight(wrongNameOne, wrongNameTwo));
                Assert.Throws<InvalidOperationException>(() => arena.Fight(wrongNameOne, defender.Name));
                Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, wrongNameTwo));
            });
        }

        [Test]
        public void FightMethod_Should_Work_When_BothAttackerName_ArePresent()
        {
            //Arrange
            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 30;
            int expectedDefenderHp = 30;

            //Act
            arena.Fight(attacker.Name, defender.Name);

            //Assert

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}
