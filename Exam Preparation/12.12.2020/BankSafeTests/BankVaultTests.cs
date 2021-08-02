using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Pesho", "pesh");
        }

        [Test]
        public void CtorCreateAnInstanceOfTheClass()
        {
            Assert.That(bankVault.VaultCells != null);
        }

        [Test]
        public void CtorInitializeDictionaryCorectly()
        {
            Assert.That(bankVault.VaultCells.Count == 12);
        }

        [Test]
        public void AddItemThrowsExceptionWhenCellDoesntExists()
        {
            string cell = "D6";

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item));
        }

        [Test]
        public void AddItemThrowsExceptionWhenCellInNotEmpty()
        {
            bankVault.AddItem("B2", item);

            Item testItem = new Item("Gesh", "gesh");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("B2", item));
        }

        [Test]
        public void AddItemThrowsExceptionWhenAddItemThatExists()
        {
            bankVault.AddItem("B2", item);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A1", item));
        }

        [Test]
        public void AddItemAddTheItem()
        {
            bankVault.AddItem("B2", item);

            Assert.That(bankVault.VaultCells["B2"], Is.EqualTo(item));
        }

        [Test]
        public void RemoveItemThrowsExceptionWhenCellDoentExists()
        {
            bankVault.AddItem("A2", item);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("D12", item));
        }

        [Test]
        public void RemoveItemThrowsExceptionWhenItemDoesntMatch()
        {
            bankVault.AddItem("B2", item);
            Item testItem = new Item("Gesh", "gesh");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("B2", testItem));
        }

        [Test]
        public void RemoveItemWorkCorectky()
        {
            bankVault.AddItem("B2", item);
            Assert.That(bankVault.VaultCells["B2"] != null);

            bankVault.RemoveItem("B2", item);
            Assert.That(bankVault.VaultCells["B2"] == null);
        }
    }
}