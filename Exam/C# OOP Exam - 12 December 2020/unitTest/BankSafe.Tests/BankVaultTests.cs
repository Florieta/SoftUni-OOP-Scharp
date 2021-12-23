using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");
        }

        [Test]
        public void WhenCellDoesntExistsYouShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("go nqma", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellIsAlreadyTakenYouShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Pesho", "3"));

            });
            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void WhenItemIsAlreadyExistsYouShouldThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B3", item);

            });
            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void WhenItemIsAddedShouldReturnCorrectMessage()
        {
            string result = vault.AddItem("A2", item);
            Assert.AreEqual(result, $"Item:1 saved successfully!");
        }
        [Test]
        public void WhenItemIsAddedShouldSetItemToCell()
        {
            string result = vault.AddItem("A2", item);
            Assert.AreEqual(item, vault.VaultCells["A2"]);
        }

        [Test]
        public void WhenRemoveCalledCellDoesntExistsYouShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("go nqma", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenRemoveCalledCellANDItemDoesntExistsYouShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });
            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }
        [Test]
        public void WhenItemIsRemovedShouldReturnCorrectMessage()
        {
            vault.AddItem("A2", item);
            string result = vault.RemoveItem("A2", item);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
        public void WhenItemIsRemovedShouldMakeTheCellNull()
        {
            vault.AddItem("A2", item);
            Item savedItem = vault.VaultCells["A2"];
            string result = vault.RemoveItem("A2", item);
            Assert.AreEqual(null, vault.VaultCells["A2"]);
        }
    }
}