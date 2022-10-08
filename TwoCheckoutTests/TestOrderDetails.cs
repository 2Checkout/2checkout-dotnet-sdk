using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestOrderDetails
    {
        private string Country;
        private string Currency;
        private string CustomerIP;
        private string ExternalReference;
        private string Language;
        private string Source;
        private BillingDetails BillingDetails;
        private Item[] Items;
        private PaymentDetails PaymentDetails;
        private OrderDetails OrderDetails;

        public void InstantiateOrderDetails()
        {
            Country = "Test";
            Currency = "Test";
            CustomerIP = "Test";
            ExternalReference = "Test";
            Language = "Test";
            Source = "Test";
            BillingDetails = new BillingDetails("Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test");
            CrossSell CrossSell = new CrossSell("Test", "Test");
            Price Price = new Price(1, "Test");
            PaymentMethod PaymentMethod = new PaymentMethod("Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", true, 1, 1);
            Item[] items = { new Item("Dynamic product", "Test description", 1, true, false, "PRODUCT", CrossSell, Price) };
            Items = items;
            PaymentDetails = new PaymentDetails("Test", "Test", "Test", PaymentMethod);
            OrderDetails = new OrderDetails(Country, Currency, CustomerIP, ExternalReference, Language, Source, BillingDetails, Items, PaymentDetails);
        }

        [TestMethod]
        public void IsItemObject()
        {
            InstantiateOrderDetails();
            Assert.IsInstanceOfType(OrderDetails, typeof(OrderDetails));
        }

        [TestMethod]
        public void IsCountrySet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(Country, OrderDetails.Country);
        }

        [TestMethod]
        public void IsCurrencySet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(Currency, OrderDetails.Currency);
        }

        [TestMethod]
        public void IsCustomerIPSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(CustomerIP, OrderDetails.CustomerIP);
        }

        [TestMethod]
        public void IsExternalReferenceSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(ExternalReference, OrderDetails.ExternalReference);
        }

        [TestMethod]
        public void IsLanguageSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(Language, OrderDetails.Language);
        }

        [TestMethod]
        public void IsSourceSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(Source, OrderDetails.Source);
        }

        [TestMethod]
        public void IsBillingDetailsSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(BillingDetails, OrderDetails.BillingDetails);
        }

        [TestMethod]
        public void IsItemsSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(Items, OrderDetails.Items);
        }

        [TestMethod]
        public void IsPaymentDetailsSet()
        {
            InstantiateOrderDetails();
            Assert.AreEqual(PaymentDetails, OrderDetails.PaymentDetails);
        }
    }
}
