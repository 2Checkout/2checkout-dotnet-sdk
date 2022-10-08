using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutOrder
    {
        public static string SellerId = "test";
        public static string SecretKey = "test";
        public static TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey);
        public static TwoCheckoutOrder TwoCheckoutOrder = new TwoCheckoutOrder();
        private static string OrderReference = "152044125";
        private static string OrderContains = "RefNo";

        [TestMethod]
        public void TestGetOrder()
        {
            try
            {
                string ApiResponse = TwoCheckoutOrder.GetOrder(TwoCheckoutConfig, OrderReference);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestPlaceOrderWithDynamicProduct()
        {
            try
            {
                Dictionary<string, dynamic> DynamicProductOrderParams = GetDynamicProductOrderParamsSuccess();
                string DynamicProductOrder = PlaceOrderWithDynamicProduct(TwoCheckoutConfig, DynamicProductOrderParams);
                Assert.IsTrue(DynamicProductOrder.Contains(OrderContains));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestPlaceOrderWithCatalogProduct()
        {
            try
            {
                Dictionary<string, dynamic> CatalogProductOrderParams = GetCatalogProductOrderParamsSuccess();
                string CatalogProductOrder = PlaceOrderWithCatalogProduct(TwoCheckoutConfig, CatalogProductOrderParams);
                Assert.IsTrue(CatalogProductOrder.Contains(OrderContains));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestSearchOrder()
        {
            try
            {
                Dictionary<string, dynamic> OrderParams = OrderParamsForSearch();
                string SearchOrder = TwoCheckoutOrder.SearchOrder(TwoCheckoutConfig, OrderParams);
                Assert.IsTrue(SearchOrder.Contains(OrderContains));
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }


        [TestMethod]
        public void TestGetDynamicProductOrderParamsSuccess()
        {
            Dictionary<string, dynamic> DynamicParams = GetDynamicProductOrderParamsSuccess();
            Assert.IsInstanceOfType(DynamicParams, typeof(Dictionary<string, dynamic>));
        }


        [TestMethod]
        public void TestGetSubscriptionParamsSuccess()
        {
            Dictionary<string, dynamic> CatalogParams = GetCatalogProductOrderParamsSuccess();
            Assert.IsInstanceOfType(CatalogParams, typeof(Dictionary<string, dynamic>));
        }

        public static Dictionary<string, dynamic> OrderParamsForSearch()
        {
            Dictionary<string, dynamic> OrderParamsDictionary = new Dictionary<string, dynamic>();
            OrderParamsDictionary.Add("ExternalRefNo", "CustOrd100");
            return OrderParamsDictionary;
        }

        public string PlaceOrderWithDynamicProduct(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> DynamicProductOrderParams)
        {
            return TwoCheckoutOrder.PlaceOrder(TwoCheckoutConfig, DynamicProductOrderParams);
        }

        public string PlaceOrderWithCatalogProduct(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> CatalogProductOrderParams)
        {
            return TwoCheckoutOrder.PlaceOrder(TwoCheckoutConfig, CatalogProductOrderParams);
        }

        public static Dictionary<string, dynamic> GetDynamicProductOrderParamsSuccess()
        {
            Dictionary<string, dynamic> PaymentMethodDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> PaymentDetailsDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> PriceDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> ItemDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, string> BillingDetailsDictionary = new Dictionary<string, string>();
            Dictionary<string, dynamic> OrderDetailsDictionary = new Dictionary<string, dynamic>();
            dynamic[] items = { ItemDictionary };

            BillingDetailsDictionary.Add("Address1", "Test Address");
            BillingDetailsDictionary.Add("City", "LA");
            BillingDetailsDictionary.Add("State", "California");
            BillingDetailsDictionary.Add("CountryCode", "US");
            BillingDetailsDictionary.Add("Email", "testcustomer@2Checkout.com");
            BillingDetailsDictionary.Add("FirstName", "Customer");
            BillingDetailsDictionary.Add("LastName", "2Checkout");
            BillingDetailsDictionary.Add("Zip", "12345");

            PriceDictionary.Add("Amount", 1);
            PriceDictionary.Add("Type", "CUSTOM");

            ItemDictionary.Add("Name", "Dynamic product");
            ItemDictionary.Add("Description", "Test description");
            ItemDictionary.Add("Quantity", 1);
            ItemDictionary.Add("IsDynamic", true);
            ItemDictionary.Add("Tangible", false);
            ItemDictionary.Add("PurchaseType", "PRODUCT");
            ItemDictionary.Add("Price", PriceDictionary);

            PaymentMethodDictionary.Add("CardNumber", "4111111111111111");
            PaymentMethodDictionary.Add("CardType", "VISA");
            PaymentMethodDictionary.Add("Vendor3DSReturnURL", "www.success.com");
            PaymentMethodDictionary.Add("Vendor3DSCancelURL", "www.fail.com");
            PaymentMethodDictionary.Add("ExpirationYear", "2023");
            PaymentMethodDictionary.Add("ExpirationMonth", "12");
            PaymentMethodDictionary.Add("CCID", "123");
            PaymentMethodDictionary.Add("HolderName", "John Doe");
            PaymentMethodDictionary.Add("RecurringEnabled", false);
            PaymentMethodDictionary.Add("HolderNameTime", 1);
            PaymentMethodDictionary.Add("CardNumberTime", 1);

            PaymentDetailsDictionary.Add("Type", "TEST");
            PaymentDetailsDictionary.Add("Currency", "USD");
            PaymentDetailsDictionary.Add("CustomerIP", "91.220.121.21");
            PaymentDetailsDictionary.Add("PaymentMethod", PaymentMethodDictionary);


            OrderDetailsDictionary.Add("Country", "us");
            OrderDetailsDictionary.Add("Currency", "USD");
            OrderDetailsDictionary.Add("CustomerIP", "91.220.121.21");
            OrderDetailsDictionary.Add("ExternalReference", "CustOrd100");
            OrderDetailsDictionary.Add("Language", "en");
            OrderDetailsDictionary.Add("Source", "tcolib.local");
            OrderDetailsDictionary.Add("BillingDetails", BillingDetailsDictionary);
            OrderDetailsDictionary.Add("Items", items);
            OrderDetailsDictionary.Add("PaymentDetails", PaymentDetailsDictionary);

            return OrderDetailsDictionary;
        }

        public static Dictionary<string, dynamic> GetCatalogProductOrderParamsSuccess()
        {
            Dictionary<string, dynamic> PaymentMethodDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> PaymentDetailsDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> ItemDictionary = new Dictionary<string, dynamic>();
            Dictionary<string, string> BillingDetailsDictionary = new Dictionary<string, string>();
            Dictionary<string, dynamic> OrderDetailsDictionary = new Dictionary<string, dynamic>();
            dynamic[] items = { ItemDictionary };

            BillingDetailsDictionary.Add("Address1", "Test Address");
            BillingDetailsDictionary.Add("City", "LA");
            BillingDetailsDictionary.Add("CountryCode", "BR");
            BillingDetailsDictionary.Add("Email", "customer@2Checkout.com");
            BillingDetailsDictionary.Add("FirstName", "Customer");
            BillingDetailsDictionary.Add("FiscalCode", "056.027.963-98");
            BillingDetailsDictionary.Add("LastName", "2Checkout");
            BillingDetailsDictionary.Add("Phone", "556133127400");
            BillingDetailsDictionary.Add("State", "DF");
            BillingDetailsDictionary.Add("Zip", "70403-900");

            ItemDictionary.Add("Code", "E377076E6A_COPY1");
            ItemDictionary.Add("Quantity", "1");

            PaymentMethodDictionary.Add("CCID", "123");
            PaymentMethodDictionary.Add("CardNumber", "4111111111111111");
            PaymentMethodDictionary.Add("CardNumberTime", "12");
            PaymentMethodDictionary.Add("CardType", "VISA");
            PaymentMethodDictionary.Add("ExpirationMonth", "12");
            PaymentMethodDictionary.Add("ExpirationYear", "2023");
            PaymentMethodDictionary.Add("HolderName", "John Doe");
            PaymentMethodDictionary.Add("HolderNameTime", "12");
            PaymentMethodDictionary.Add("RecurringEnabled", true);
            PaymentMethodDictionary.Add("Vendor3DSReturnURL", "www.test.com");
            PaymentMethodDictionary.Add("Vendor3DSCancelURL", "www.test.com");

            PaymentDetailsDictionary.Add("Type", "TEST");
            PaymentDetailsDictionary.Add("Currency", "BRL");
            PaymentDetailsDictionary.Add("CustomerIP", "91.220.121.21");
            PaymentDetailsDictionary.Add("PaymentMethod", PaymentMethodDictionary);


            OrderDetailsDictionary.Add("Country", "br");
            OrderDetailsDictionary.Add("Currency", "brl");
            OrderDetailsDictionary.Add("CustomerIP", "91.220.121.21");
            OrderDetailsDictionary.Add("ExternalReference", "CustOrderCatProd100");
            OrderDetailsDictionary.Add("Language", "en");
            OrderDetailsDictionary.Add("BillingDetails", BillingDetailsDictionary);
            OrderDetailsDictionary.Add("Items", items);
            OrderDetailsDictionary.Add("PaymentDetails", PaymentDetailsDictionary);

            return OrderDetailsDictionary;
        }
    }
}
