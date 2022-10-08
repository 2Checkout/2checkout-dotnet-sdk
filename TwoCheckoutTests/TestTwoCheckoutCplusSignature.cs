using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutCplusSignature
    {
        public static string SellerId = "Add Seller id";
        public static string SecretKey = "Add Secret Key";
        public static string SecretWord = "Add Secret Word";
        public static TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey, SecretWord);
        public static TwoCheckoutCplusSignature TwoCheckoutCplusSignature = new TwoCheckoutCplusSignature();
        private static TwoCheckoutUtil Tco = new TwoCheckoutUtil();
        private static string JwtReference = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBZGQgU2VsbGVyIGlkIiwiaWF0IjoiMTYyMTQxNjcyNSIsImV4cCI6IjE2MjE0MjAzNjMifQ.L0xXHvq88Sa677KcGO8u4LuRqY0J63kL9z8oyDbWlyYpH6sF3996T-vMxuxfZ2pmnjljccOTEJfXZSVEkPwpjA";
        private static string iat = "1621416725";
        private static string exp = "1621420363";

        [TestMethod]
        public void TestGetJwtToken()
        {
            string JwtToken = TwoCheckoutCplusSignature.GetJwtToken(TwoCheckoutConfig.SellerId, TwoCheckoutConfig.SecretWord, iat, exp);
            Assert.AreEqual(JwtToken, JwtReference);
        }

        [TestMethod]
        public void TestGetSignature()
        {
            try
            {
                Dictionary<string, dynamic> CplusParamsDictionary = GetConvertPlusParameters(TwoCheckoutConfig.SellerId);
                string Signature = TwoCheckoutCplusSignature.GetSignature(TwoCheckoutConfig, CplusParamsDictionary);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void TestGetConvertPlusParameters()
        {
            Dictionary<string, dynamic> CplusParamsDictionary = GetConvertPlusParameters(TwoCheckoutConfig.SellerId);
            Assert.IsInstanceOfType(CplusParamsDictionary, typeof(Dictionary<string, dynamic>));
        }

        public Dictionary<string, dynamic> GetConvertPlusParameters(string SellerId)
        {
            Dictionary<string, dynamic> CplusParamsDictionary = new Dictionary<string, dynamic>();

            CplusParamsDictionary.Add("name", "John Doe");
            CplusParamsDictionary.Add("phone", "756852919");
            CplusParamsDictionary.Add("country", "US");
            CplusParamsDictionary.Add("state", "Utah");
            CplusParamsDictionary.Add("email", "example@example.com");
            CplusParamsDictionary.Add("address", "Example");
            CplusParamsDictionary.Add("city", "Utah");
            CplusParamsDictionary.Add("company-name", "2co");
            CplusParamsDictionary.Add("ship-name", "John Doe");
            CplusParamsDictionary.Add("ship-country", "US");
            CplusParamsDictionary.Add("ship-state", "Utah");
            CplusParamsDictionary.Add("ship-city", "Utah");
            CplusParamsDictionary.Add("ship-email", "example@example.com");
            CplusParamsDictionary.Add("ship-address", "Example");
            CplusParamsDictionary.Add("ship-address2", "dewdedw");
            CplusParamsDictionary.Add("zip", "84101");
            CplusParamsDictionary.Add("prod", "Cart_2");
            CplusParamsDictionary.Add("price", 106);
            CplusParamsDictionary.Add("qty", 1);
            CplusParamsDictionary.Add("type", "PRODUCT");
            CplusParamsDictionary.Add("tangible", "0");
            CplusParamsDictionary.Add("src", "OPENCART_3_0_3_7");
            CplusParamsDictionary.Add("return-url", "https://www.google.ro");
            CplusParamsDictionary.Add("return-type", "redirect");
            CplusParamsDictionary.Add("expiration", 1620911744);
            CplusParamsDictionary.Add("order-ext-ref", "2");
            CplusParamsDictionary.Add("item-ext-ref", "20210513081544");
            CplusParamsDictionary.Add("customer-ext-ref", "example@example.com");
            CplusParamsDictionary.Add("currency", "usd");
            CplusParamsDictionary.Add("language", "en");
            CplusParamsDictionary.Add("test", "1");
            CplusParamsDictionary.Add("merchant", SellerId);
            CplusParamsDictionary.Add("dynamic", 1);

            return CplusParamsDictionary;
        }
    }
}
