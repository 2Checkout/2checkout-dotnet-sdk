using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutSubscription
    {
        public static string SellerId = "test";
        public static string SecretKey = "test";
        public TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey);
        public TwoCheckoutOrder TwoCheckoutOrder = new TwoCheckoutOrder();
        public TwoCheckoutSubscription TwoCheckoutSubscription = new TwoCheckoutSubscription();
        private static string SubscriptionReference = "RCBGCP5MRI";

        [TestMethod]
        public void TestGetSubscription()
        {
            try
            {
                string SubscriptionRetrieved = TwoCheckoutSubscription.GetSubscription(TwoCheckoutConfig, SubscriptionReference);
                Assert.IsTrue(SubscriptionRetrieved.Contains(SubscriptionReference));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestCreateSubscription()
        {
            try
            {

                Dictionary<string, dynamic> SubscriptionParams = GetSubscriptionParamsSuccess();
                string SubscriptionCreated = TwoCheckoutSubscription.CreateSubscription(TwoCheckoutConfig, SubscriptionParams);
                Assert.IsTrue(SubscriptionCreated.Contains(SubscriptionReference));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestGetSubscriptionParamsSuccess()
        {
            Dictionary<string, dynamic> SubscriptionParams = GetSubscriptionParamsSuccess();
            Assert.IsInstanceOfType(SubscriptionParams, typeof(Dictionary<string, dynamic>));
        }

        public Dictionary<string, dynamic> GetSubscriptionParamsSuccess()
        {

            Dictionary<string, dynamic> EndUserDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> PaymentDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> ProductDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> DeliveryInfoDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, string> CodesDictionary = new Dictionary<string, string>();
            Dictionary<string, dynamic> SubscriptionDictionary = new Dictionary<string, dynamic>();
            string[] PriceOptionCodes = { "addon-1_1_annually" };

            ProductDictionary.Add("PriceOptionCodes", PriceOptionCodes);
            ProductDictionary.Add("ProductCode", "my_subscription_1");
            ProductDictionary.Add("ProductId", "24584760");
            ProductDictionary.Add("ProductName", "2Checkout Subscription");
            ProductDictionary.Add("ProductQuantity", 1);
            ProductDictionary.Add("ProductVersion", "");

            CodesDictionary.Add("Code", "___TEST___CODE____");
            DeliveryInfoDictionary.Add("Codes", CodesDictionary);

            EndUserDictionary.Add("Address1", "Test Address");
            EndUserDictionary.Add("Address2", "");
            EndUserDictionary.Add("City", "LA");
            EndUserDictionary.Add("Company", "");
            EndUserDictionary.Add("CountryCode", "us");
            EndUserDictionary.Add("Email", "customer@2Checkout.com");
            EndUserDictionary.Add("Fax", "123");
            EndUserDictionary.Add("FirstName", "Customer");
            EndUserDictionary.Add("Language", "en");
            EndUserDictionary.Add("LastName", "2Checkout");
            EndUserDictionary.Add("Phone", "");
            EndUserDictionary.Add("State", "CA");
            EndUserDictionary.Add("Zip", "12345");

            PaymentDictionary.Add("CCID", "123");
            PaymentDictionary.Add("CardNumber", "4111111111111111");
            PaymentDictionary.Add("CardType", "VISA");
            PaymentDictionary.Add("ExpirationMonth", "12");
            PaymentDictionary.Add("ExpirationYear", "2018");
            PaymentDictionary.Add("HolderName", "John Doe");

            SubscriptionDictionary.Add("CustomPriceBillingCyclesLeft", 2);
            SubscriptionDictionary.Add("DeliveryInfo", DeliveryInfoDictionary);
            SubscriptionDictionary.Add("EndUser", EndUserDictionary);
            SubscriptionDictionary.Add("ExpirationDate", "2015-12-16");
            SubscriptionDictionary.Add("ExternalSubscriptionReference", "ThisIsYourUniqueIdentifier123");
            SubscriptionDictionary.Add("NextRenewalPrice", 49.99);
            SubscriptionDictionary.Add("NextRenewalPriceCurrency", "usd");
            SubscriptionDictionary.Add("PartnerCode", "");
            SubscriptionDictionary.Add("Payment", PaymentDictionary);
            SubscriptionDictionary.Add("Product", ProductDictionary);
            SubscriptionDictionary.Add("StartDate", "2015-02-16");
            SubscriptionDictionary.Add("SubscriptionValue", 199);
            SubscriptionDictionary.Add("SubscriptionValueCurrency", "usd");
            SubscriptionDictionary.Add("Test", 1);

            return SubscriptionDictionary;
        }
    }
}
