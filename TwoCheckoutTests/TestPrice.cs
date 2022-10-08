using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestPrice
    {
        private int Amount;
        private string PriceType;
        private Price Price;

        public void InstantiatePrice()
        {
            Amount = 1;
            PriceType = "Test type";
            Price = new Price(Amount, PriceType);
        }

        [TestMethod]
        public void IsPriceObject()
        {
            InstantiatePrice();
            Assert.IsInstanceOfType(Price, typeof(Price));
        }

        [TestMethod]
        public void IsAmountSet()
        {
            InstantiatePrice();
            Assert.AreEqual(Amount, Price.Amount);
        }

        [TestMethod]
        public void IsPriceTypeSet()
        {
            InstantiatePrice();
            Assert.AreEqual(PriceType, Price.Type);
        }
    }
}
