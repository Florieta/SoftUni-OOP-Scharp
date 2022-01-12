using System;
using NUnit.Framework;

namespace HeroRep.Tests
{
    [TestFixture]
    public class HeroRepositoryTests
    {
        private HeroRepository heroRepository;

        [SetUp]
        public void Setup()
        {
            heroRepository = new HeroRepository();
        }

        [Test]
        public void CreateHero_ThrowsNullExceptionWhenHeroIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                heroRepository.Create(null);
            });
           
        }

        [Test]
        public void CreateHero_ThrowsExceptionWhenHeroHasAlreadyExisted()
        {
            string heroName = "Ivan";
            heroRepository.Create(new Hero(heroName, 2));
            
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                heroRepository.Create(new Hero(heroName, 2));
            });
            Assert.AreEqual(ex.Message, $"Hero with name {heroName} already exists");
        }

        [Test]
        public void CreateHero_ReturnExpectedResultMessage()
        {
            string heroName = "Ivan";
            int level = 2;
            string actual = heroRepository.Create(new Hero(heroName, level));

            var expected = $"Successfully added hero {heroName} with level {level}";
            Assert.That(expected, Is.EqualTo(actual));
            
        }

        [Test]

        public void RemoveHero_ThrowsNullException()
        {
           
            Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));

        }
        [Test]

        public void Remove()
        {
            string heroName = "Ivan";
            int level = 2;
            heroRepository.Create(new Hero(heroName, level));
            bool IsRemoved = heroRepository.Remove(heroName);
            bool expected = true;
            Assert.AreEqual(expected, IsRemoved);

        }
        [Test]

        public void GetHeroWithHighestLevel_ReturnTheCorrectResult()
        {
            Hero hero1 = new Hero("A", 1);
            Hero hero2 = new Hero("B", 2);
            Hero hero3 = new Hero("C", 3);
            heroRepository.Create(hero1);
            heroRepository.Create(hero2); 
            heroRepository.Create(hero3);

            var result = heroRepository.GetHeroWithHighestLevel();
            var expected = hero3;
            Assert.AreEqual(expected, result);
        }

        [Test]

        public void GetHero_ReturnTheCorrectResult()
        {
            Hero hero1 = new Hero("A", 1);
            Hero hero2 = new Hero("B", 2);
            heroRepository.Create(hero1);
            heroRepository.Create(hero2);

            var result = heroRepository.GetHero("A");
            var expected = hero1;
            Assert.AreEqual(expected, result);
        }
    }
}