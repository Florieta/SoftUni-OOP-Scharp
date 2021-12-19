using EgnValidatorProgram;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class GetEgnInfoTests
    {
        [Test]
        public void GetEgnInfoShouldThrowAnExceptionWhenGivenInvalidNumber()
        {
            var egn = new EgnValidatorProgram.EgnValidator();
            Assert.Throws<ArgumentException>(() =>
                egn.GetEgnInfo("0000000000"));
        }

        [Test]
        public void GetEgnInfoShouldWorkCorrectlyForPeopleBornAfter2000()
        {
            var egn = new EgnValidatorProgram.EgnValidator();
            var info = egn.GetEgnInfo("1046134610");
            Assert.AreEqual(new DateTime(2010, 6, 13), info.BirthDate);
            Assert.AreEqual(Gender.Female, info.Gender);
            Assert.AreEqual("Пловдив", info.City);
        }

        [Test]
        public void GetEgnInfoShouldWorkCorrectlyForPeopleBornBefore1900()
        {
            var egn = new EgnValidatorProgram.EgnValidator();
            var info = egn.GetEgnInfo("2124051230");
            Assert.AreEqual(new DateTime(1821, 4, 5), info.BirthDate);
            Assert.AreEqual(Gender.Female, info.Gender);
            Assert.AreEqual("Варна", info.City);
        }

        [Test]
        public void GetEgnInfoShouldWorkCorrectlyForPeopleBorn20thCentury()
        {
            var egn = new EgnValidatorProgram.EgnValidator();
            var info = egn.GetEgnInfo("5904256245");
            Assert.AreEqual(new DateTime(1959, 4, 25), info.BirthDate);
            Assert.AreEqual(Gender.Male, info.Gender);
            Assert.AreEqual("София - град", info.City);
        }

        [Test]
        public void GetEgnInfoShouldWorkCorrectlyForPeopleBornInUnknownRegion()
        {
            var egn = new EgnValidatorProgram.EgnValidator();
            var info = egn.GetEgnInfo("8812129997");
            Assert.AreEqual(new DateTime(1988, 12, 12), info.BirthDate);
            Assert.AreEqual(Gender.Female, info.Gender);
            Assert.AreEqual("Друг", info.City);
        }
    }
}
