using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutIpn
    {
        public static string SellerId = "";
        public static string SecretKey = "";
        public static string SecretWord = "";
        public static TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey, SecretWord);
        public static TwoCheckoutOrder TwoCheckoutOrder = new TwoCheckoutOrder();
        public static TwoCheckoutSubscription TwoCheckoutSubscription = new TwoCheckoutSubscription();
        public static TwoCheckoutCplusSignature TwoCheckoutCplusSignature = new TwoCheckoutCplusSignature();
        public static TwoCheckoutIpn TwoCheckoutIpn = new TwoCheckoutIpn();
        private static TwoCheckoutUtil Tco = new TwoCheckoutUtil();
        private static string DateTimeString = "20210701163700";


        [TestMethod]
        public void TestCalculateSha256IpnResponse()
        {
            string Now = DateTime.Now.ToString(DateTimeString);
            Dictionary<string, dynamic> IpnParams = GetIpnDictionary();
            string IpnResponse = TwoCheckoutIpn.CalculateIpnResponse(SecretKey, Now, IpnParams);
            Assert.AreEqual(IpnResponse, "<sig algo=\"sha256\" date=\"20210701163700\">3995c5a6401057b4f4c0032089c6a951823b4d804e1abe2ac04d4d68362dff2f</sig>");
        }

        [TestMethod]
        public void TestCalculateMd5IpnResponse()
        {
            string Now = DateTime.Now.ToString(DateTimeString);
            Dictionary<string, dynamic> IpnParams = GetIpnDictionary();
            IpnParams.Remove("SIGNATURE_SHA2_256");
            IpnParams.Remove("SIGNATURE_SHA3_256");
            string IpnResponse = TwoCheckoutIpn.CalculateIpnResponse(SecretKey, Now, IpnParams);
            Assert.AreEqual(IpnResponse, "<EPAYMENT>20210701163700|3d58c9996861940deacd16215da33c1e</EPAYMENT>");
        }

        [TestMethod]
        public void TestIsSha256IpnResponseValid()
        {
            Dictionary<string, dynamic> IpnParams = GetIpnDictionary();
            bool IsIpnResponseValid = TwoCheckoutIpn.IsIpnResponseValid(SecretKey, IpnParams);
            Assert.AreEqual(IsIpnResponseValid, true);
        }

        [TestMethod]
        public void TestIsMd5IpnResponseValid()
        {
            Dictionary<string, dynamic> IpnParams = GetIpnDictionary();
            IpnParams.Remove("SIGNATURE_SHA2_256");
            IpnParams.Remove("SIGNATURE_SHA3_256");
            bool IsIpnResponseValid = TwoCheckoutIpn.IsIpnResponseValid(SecretKey, IpnParams);
            Assert.AreEqual(IsIpnResponseValid, true);
        }

        [TestMethod]
        public void TestGetIpnDictionary()
        {
            Dictionary<string, dynamic> Params = GetIpnDictionary();
            Assert.IsInstanceOfType(Params, typeof(Dictionary<string, dynamic>));
        }

        public dynamic GetIpnDictionary()
        {
            string[] IPN_PID = { "40898000" };
            string[] IPN_PNAME = { "Dynamic product" };
            string[] IPN_PCODE = { "" };
            string[] IPN_EXTERNAL_REFERENCE = { "" };
            string[] IPN_INFO = { "" };
            string[] IPN_QTY = { "1" };
            string[] IPN_PRICE = { "0.01" };
            string[] IPN_VAT = { "0.00" };
            string[] IPN_VAT_RATE = { "0.0000" };
            string[] IPN_VER = { "1" };
            string[] IPN_DISCOUNT = { "0.00" };
            string[] IPN_PROMOTION_CATEGORY = { "" };
            string[] IPN_PROMONAME = { "" };
            string[] IPN_PROMOCODE = { "" };
            string[] IPN_ORDER_COSTS = { "0" };
            string[] IPN_SKU = { "" };
            string[] IPN_PGROUP = { "0" };
            string[] IPN_PGROUP_NAME = { "" };
            string[] IPN_LICENSE_PROD = { "40898000" };
            string[] IPN_LICENSE_TYPE = { "REGULAR" };
            string[] IPN_LICENSE_REF = { "XRILXB9ZI3" };
            string[] IPN_LICENSE_EXP = { "9999-12-31 23:59:59" };
            string[] IPN_LICENSE_START = { "2023-06-09 15:31:18" };
            string[] IPN_LICENSE_LIFETIME = { "YES" };
            string[] IPN_LICENSE_ADDITIONAL_INFO = { "" };
            string[] IPN_DELIVEREDCODES = { "" };
            string[] IPN_TOTAL = { "0.01" };

            Dictionary<string, dynamic> IpnResponse = new Dictionary<string, dynamic>();
            IpnResponse.Add("GIFT_ORDER", "0");
            IpnResponse.Add("SALEDATE", "2023-06-09 15:26:18");
            IpnResponse.Add("PAYMENTDATE", "2023-06-09 15:31:18");
            IpnResponse.Add("REFNO", "211153389");
            IpnResponse.Add("REFNOEXT", "REST_API_AVANGTE");
            IpnResponse.Add("SHOPPER_REFERENCE_NUMBER", "");
            IpnResponse.Add("ORDERNO", "25430");
            IpnResponse.Add("ORDERSTATUS", "COMPLETE");
            IpnResponse.Add("PAYMETHOD", "Visa/MasterCard");
            IpnResponse.Add("PAYMETHOD_CODE", "CCVISAMC");
            IpnResponse.Add("FIRSTNAME", "Customer");
            IpnResponse.Add("LASTNAME", "2Checkout");
            IpnResponse.Add("COMPANY", "");
            IpnResponse.Add("REGISTRATIONNUMBER", "");
            IpnResponse.Add("FISCALCODE", "");
            IpnResponse.Add("TAX_OFFICE", "");
            IpnResponse.Add("CBANKNAME", "");
            IpnResponse.Add("CBANKACCOUNT", "");
            IpnResponse.Add("ADDRESS1", "Test Address");
            IpnResponse.Add("ADDRESS2", "");
            IpnResponse.Add("CITY", "LA");
            IpnResponse.Add("STATE", "DF");
            IpnResponse.Add("ZIPCODE", "70403-900");
            IpnResponse.Add("COUNTRY", "United States of America");
            IpnResponse.Add("COUNTRY_CODE", "us");
            IpnResponse.Add("PHONE", "556133127400");
            IpnResponse.Add("FAX", "");
            IpnResponse.Add("CUSTOMEREMAIL", "customer@2Checkout.com");
            IpnResponse.Add("FIRSTNAME_D", "Customer");
            IpnResponse.Add("LASTNAME_D", "2Checkout");
            IpnResponse.Add("COMPANY_D", "");
            IpnResponse.Add("ADDRESS1_D", "Test Address");
            IpnResponse.Add("ADDRESS2_D", "");
            IpnResponse.Add("CITY_D", "LA");
            IpnResponse.Add("STATE_D", "DF");
            IpnResponse.Add("ZIPCODE_D", "70403-900");
            IpnResponse.Add("COUNTRY_D", "United States of America");
            IpnResponse.Add("COUNTRY_D_CODE", "us");
            IpnResponse.Add("PHONE_D", "556133127400");
            IpnResponse.Add("EMAIL_D", "customer@2Checkout.com");
            IpnResponse.Add("IPADDRESS", "91.220.121.21");
            IpnResponse.Add("IPCOUNTRY", "Romania");
            IpnResponse.Add("COMPLETE_DATE", "2023-06-09 15:31:23");
            IpnResponse.Add("TIMEZONE_OFFSET", "GMT+03:00");
            IpnResponse.Add("CURRENCY", "RON");
            IpnResponse.Add("LANGUAGE", "en");
            IpnResponse.Add("ORDERFLOW", "REGULAR");
            IpnResponse.Add("IPN_PID", IPN_PID);
            IpnResponse.Add("IPN_PNAME", IPN_PNAME);
            IpnResponse.Add("IPN_PCODE", IPN_PCODE);
            IpnResponse.Add("IPN_EXTERNAL_REFERENCE", IPN_EXTERNAL_REFERENCE);
            IpnResponse.Add("IPN_INFO", IPN_INFO);
            IpnResponse.Add("IPN_QTY", IPN_QTY);
            IpnResponse.Add("IPN_PRICE", IPN_PRICE);
            IpnResponse.Add("IPN_VAT", IPN_VAT);
            IpnResponse.Add("IPN_VAT_RATE", IPN_VAT_RATE);
            IpnResponse.Add("IPN_VER", IPN_VER);
            IpnResponse.Add("IPN_DISCOUNT", IPN_DISCOUNT);
            IpnResponse.Add("IPN_PROMOTION_CATEGORY", IPN_PROMOTION_CATEGORY);
            IpnResponse.Add("IPN_PROMONAME", IPN_PROMONAME);
            IpnResponse.Add("IPN_PROMOCODE", IPN_PROMOCODE);
            IpnResponse.Add("IPN_ORDER_COSTS", IPN_ORDER_COSTS);
            IpnResponse.Add("IPN_SKU", IPN_SKU);
            IpnResponse.Add("IPN_PARTNER_CODE", "");
            IpnResponse.Add("IPN_PGROUP", IPN_PGROUP);
            IpnResponse.Add("IPN_PGROUP_NAME", IPN_PGROUP_NAME);
            IpnResponse.Add("MESSAGE_ID", "254510700124");
            IpnResponse.Add("MESSAGE_TYPE", "COMPLETE");
            IpnResponse.Add("IPN_LICENSE_PROD", IPN_LICENSE_PROD);
            IpnResponse.Add("IPN_LICENSE_TYPE", IPN_LICENSE_TYPE);
            IpnResponse.Add("IPN_LICENSE_REF", IPN_LICENSE_REF);
            IpnResponse.Add("IPN_LICENSE_EXP", IPN_LICENSE_EXP);
            IpnResponse.Add("IPN_LICENSE_START", IPN_LICENSE_START);
            IpnResponse.Add("IPN_LICENSE_LIFETIME", IPN_LICENSE_LIFETIME);
            IpnResponse.Add("IPN_LICENSE_ADDITIONAL_INFO", IPN_LICENSE_ADDITIONAL_INFO);
            IpnResponse.Add("IPN_DELIVEREDCODES", IPN_DELIVEREDCODES);
            IpnResponse.Add("IPN_DOWNLOAD_LINK", "");
            IpnResponse.Add("IPN_TOTAL", IPN_TOTAL);
            IpnResponse.Add("IPN_TOTALGENERAL", "0.01");
            IpnResponse.Add("IPN_SHIPPING", "0.00");
            IpnResponse.Add("IPN_SHIPPING_TAX", "0.00");
            IpnResponse.Add("AVANGATE_CUSTOMER_REFERENCE", "756227060");
            IpnResponse.Add("EXTERNAL_CUSTOMER_REFERENCE", "IOUER");
            IpnResponse.Add("IPN_PARTNER_MARGIN_PERCENT", "0.00");
            IpnResponse.Add("IPN_PARTNER_MARGIN", "0.00");
            IpnResponse.Add("IPN_EXTRA_MARGIN", "0.00");
            IpnResponse.Add("IPN_EXTRA_DISCOUNT", "0.00");
            IpnResponse.Add("IPN_COUPON_DISCOUNT", "0.00");
            IpnResponse.Add("IPN_LINK_SOURCE", "testAPI.com");
            IpnResponse.Add("IPN_COMMISSION", "2.7678");
            IpnResponse.Add("REFUND_TYPE", "");
            IpnResponse.Add("CHARGEBACK_RESOLUTION", "NONE");
            IpnResponse.Add("CHARGEBACK_REASON_CODE", "");
            IpnResponse.Add("TEST_ORDER", "0");
            IpnResponse.Add("IPN_ORDER_ORIGIN", "API");
            IpnResponse.Add("FRAUD_STATUS", "APPROVED");
            IpnResponse.Add("CARD_TYPE", "mastercard");
            IpnResponse.Add("CARD_LAST_DIGITS", "5547");
            IpnResponse.Add("CARD_EXPIRATION_DATE", "05/27");
            IpnResponse.Add("GATEWAY_RESPONSE", "Approved");
            IpnResponse.Add("IPN_DATE", "20230619190629");
            IpnResponse.Add("FX_RATE", "0.20810660205937");
            IpnResponse.Add("FX_MARKUP", "4");
            IpnResponse.Add("PAYABLE_AMOUNT", "-0.57");
            IpnResponse.Add("PAYOUT_CURRENCY", "USD");
            IpnResponse.Add("VENDOR_CODE", "250111206876");
            IpnResponse.Add("PROPOSAL_ID", "");
            IpnResponse.Add("HASH", "dad1c7a601a4a990cec21a57c1d2b702");
            IpnResponse.Add("SIGNATURE_SHA2_256", "d38b877262d8a7abbd7b8877c1d60f3ea6a5c11e2315fa5c3209ccaa9f2eb797");
            IpnResponse.Add("SIGNATURE_SHA3_256", "12b2a5d6bf2ddb8581d57787964bc351fb791655e5e9a7961ba8b9619e372adb");
            return IpnResponse;
        }
    }
}
