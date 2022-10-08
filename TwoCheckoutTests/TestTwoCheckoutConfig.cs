using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutConfig
    {
        public string SellerId = null;
        public string SecretKey = null;
        public string SecretWord = null;
        public string ApiUrl = "https://api.2checkout.com/rest/6.0";
        private TwoCheckoutConfig TwoCheckoutConfig;
        [TestMethod]

        public void InstantiateTwoCheckoutConfig()
        {
            SellerId = "Test";
            SecretKey = "Test";
            SecretWord = "Test";
            TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey, SecretWord);
        }

        [TestMethod]
        public void IsPriceObject()
        {
            InstantiateTwoCheckoutConfig();
            Assert.IsInstanceOfType(TwoCheckoutConfig, typeof(TwoCheckoutConfig));
        }

        public void IsSellerIdSet()
        {
            InstantiateTwoCheckoutConfig();
            Assert.AreEqual(SellerId, TwoCheckoutConfig.SellerId);
        }

        [TestMethod]
        public void IsSecretKeySet()
        {
            InstantiateTwoCheckoutConfig();
            Assert.AreEqual(SecretKey, TwoCheckoutConfig.SecretKey);
        }

        [TestMethod]
        public void IsSecretWordSet()
        {
            InstantiateTwoCheckoutConfig();
            Assert.AreEqual(SecretWord, TwoCheckoutConfig.SecretWord);
        }

        [TestMethod]
        public void IsApiUrlSet()
        {
            InstantiateTwoCheckoutConfig();
            Assert.AreEqual(ApiUrl, TwoCheckoutConfig.ApiUrl);
        }
    }
}
