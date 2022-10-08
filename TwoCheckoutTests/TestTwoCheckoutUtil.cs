using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{

    [TestClass]
    public class TestTwoCheckoutUtil
    {
        private TwoCheckoutUtil TwoCheckoutUtil;
        private TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig("Test", "Test");

        public void InstantiateTwoCheckoutUtil()
        {
            TwoCheckoutUtil = new TwoCheckoutUtil();
        }

        [TestMethod]
        public void CheckHeaders()
        {
            InstantiateTwoCheckoutUtil();
            TwoCheckoutConfig.SellerId = "Test";
            TwoCheckoutConfig.SecretKey = "Test";
            string[] Headers = TwoCheckoutUtil.GetHeaders(TwoCheckoutConfig);
            Assert.AreEqual(Headers[0], "application/json");
            Assert.AreEqual(Headers[1], "application/json");
            Assert.IsTrue(Headers[2].Contains("code=\""));
        }

        [TestMethod]
        public void CheckConvertToJson()
        {
            InstantiateTwoCheckoutUtil();
            Price Price = new Price(1, "Test");
            string Json = TwoCheckoutUtil.ConvertToJson(Price);
            string JsonResult = "{\"Amount\":1,\"Type\":\"Test\"}";
            Assert.AreEqual(Json, JsonResult);
        }

        [TestMethod]
        public void QueryString()
        {
            Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
            dict.Add("RefNo", "1");
            dict.Add("Currency", "USD");

            var list = new List<string>();
            foreach (var item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            string QueryString = string.Join("&", list);
            Assert.AreEqual(QueryString, "RefNo=1&Currency=USD");
        }
    }
}
