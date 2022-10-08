using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{

    [TestClass]
    public class TestPaymentDetails
    {
        private string Type;
        private string Currency;
        private string CustomerIP;
        private PaymentMethod PaymentMethod;
        private PaymentDetails PaymentDetails;

        public void InstantiatePaymentDetails()
        {
            Type = "Test";
            Currency = "Test";
            CustomerIP = "Test";
            PaymentMethod = new PaymentMethod("Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", true, 1, 1);
            PaymentDetails = new PaymentDetails(Type, Currency, CustomerIP, PaymentMethod);
        }

        [TestMethod]
        public void IsPaymentDetailsObject()
        {
            InstantiatePaymentDetails();
            Assert.IsInstanceOfType(PaymentDetails, typeof(PaymentDetails));
        }

        [TestMethod]
        public void IsTypeSet()
        {
            InstantiatePaymentDetails();
            Assert.AreEqual(Type, PaymentDetails.Type);
        }

        [TestMethod]
        public void IsCurrencySet()
        {
            InstantiatePaymentDetails();
            Assert.AreEqual(Currency, PaymentDetails.Currency);
        }

        [TestMethod]
        public void IsCustomerIPSet()
        {
            InstantiatePaymentDetails();
            Assert.AreEqual(CustomerIP, PaymentDetails.CustomerIP);
        }

        [TestMethod]
        public void IsPaymentMethodSet()
        {
            InstantiatePaymentDetails();
            Assert.AreEqual(PaymentMethod, PaymentDetails.PaymentMethod);
        }
    }
}
