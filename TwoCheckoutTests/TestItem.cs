using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestItem
    {
        private string Name;
        private string Description;
        private int Quantity;
        private bool IsDynamic;
        private bool Tangible;
        private string PurchaseType;
        private CrossSell CrossSell;
        private Price Price;
        private Item Item;

        public void InstantiateItem()
        {
            Name = "Test";
            Description = "Test";
            Quantity = 1;
            IsDynamic = true;
            Tangible = true;
            PurchaseType = "Test";
            CrossSell = new CrossSell("Test", "Test");
            Price = new Price(1, "Test");
            Item = new Item(Name, Description, Quantity, IsDynamic, Tangible, PurchaseType, CrossSell, Price);
        }

        [TestMethod]
        public void IsItemObject()
        {
            InstantiateItem();
            Assert.IsInstanceOfType(Item, typeof(Item));
        }

        [TestMethod]
        public void IsNameSet()
        {
            InstantiateItem();
            Assert.AreEqual(Name, Item.Name);
        }

        [TestMethod]
        public void IsDescriptionSet()
        {
            InstantiateItem();
            Assert.AreEqual(Description, Item.Description);
        }

        [TestMethod]
        public void IsQuantitySet()
        {
            InstantiateItem();
            Assert.AreEqual(Quantity, Item.Quantity);
        }

        [TestMethod]
        public void IsIsDynamicSet()
        {
            InstantiateItem();
            Assert.AreEqual(IsDynamic, Item.IsDynamic);
        }

        [TestMethod]
        public void IsTangibleSet()
        {
            InstantiateItem();
            Assert.AreEqual(Tangible, Item.Tangible);
        }

        [TestMethod]
        public void IsPurchaseTypeSet()
        {
            InstantiateItem();
            Assert.AreEqual(PurchaseType, Item.PurchaseType);
        }

        [TestMethod]
        public void IsCrossSellSet()
        {
            InstantiateItem();
            Assert.AreEqual(CrossSell, Item.CrossSell);
        }

        [TestMethod]
        public void IsPriceSet()
        {
            InstantiateItem();
            Assert.AreEqual(Price, Item.Price);
        }
    }
}
