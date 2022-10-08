using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwoCheckout;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestTwoCheckoutIpn
    {
        public static string SellerId = "insert seller id";
        public static string SecretKey = "insert secret key";
        public static string SecretWord = "insert secret word";
        public static TwoCheckoutConfig TwoCheckoutConfig = new TwoCheckoutConfig(SellerId, SecretKey, SecretWord);
        public static TwoCheckoutOrder TwoCheckoutOrder = new TwoCheckoutOrder();
        public static TwoCheckoutSubscription TwoCheckoutSubscription = new TwoCheckoutSubscription();
        public static TwoCheckoutCplusSignature TwoCheckoutCplusSignature = new TwoCheckoutCplusSignature();
        public static TwoCheckoutIpn TwoCheckoutIpn = new TwoCheckoutIpn();
        private static TwoCheckoutUtil Tco = new TwoCheckoutUtil();
        private static string ExpectedHash = "<EPAYMENT>20210518112122|14942802c5c411489e408f512f69c5fe</EPAYMENT>";
        private static string DateTimeString = "20210518112122";

        [TestMethod]
        public void TestCalculateIpnResponse()
        {
            string Now = DateTime.Now.ToString(DateTimeString);
            Dictionary<string, dynamic> ShortIpnParams = GetShortIpnDictionary();
            string IpnResponse = TwoCheckoutIpn.CalculateIpnResponse(SecretKey, Now, ShortIpnParams);
            Assert.AreEqual(IpnResponse, ExpectedHash);
        }

        [TestMethod]
        public void TestIsIpnResponseValid()
        {
            Dictionary<string, dynamic> IpnParams = GetIpnDictionary();
            bool IsIpnResponseValid = TwoCheckoutIpn.IsIpnResponseValid(SecretKey, IpnParams);
            Assert.AreEqual(IsIpnResponseValid, false);
        }

        [TestMethod]
        public void TestArrayExpand()
        {
            string [] ArrayToExpand = { "Cart_000001070", "Cart_0000001071" };
            string Response = TwoCheckoutIpn.ArrayExpand(ArrayToExpand);
            Assert.AreEqual(Response, "14Cart_00000107015Cart_0000001071");
        }

        [TestMethod]
        public void TestStripSlashes()
        {
            string Response = TwoCheckoutIpn.StripSlashes("text");
            Assert.AreEqual(Response, "text");
        }

        [TestMethod]
        public void TestHmacMd5()
        {
            string Response = TwoCheckoutIpn.HmacMd5("text", SecretKey);
            Assert.AreEqual(Response, "35ff75571c5a643c88fa893d90163bda");
        }

        [TestMethod]
        public void TestGetShortIpnDictionary()
        {
            Dictionary<string, dynamic> Params = GetShortIpnDictionary();
            Assert.IsInstanceOfType(Params, typeof(Dictionary<string, dynamic>));
        }

        [TestMethod]
        public void TestGetIpnDictionary()
        {
            Dictionary<string, dynamic> Params = GetIpnDictionary();
            Assert.IsInstanceOfType(Params, typeof(Dictionary<string, dynamic>));
        }
        public dynamic GetShortIpnDictionary()
        {
            Dictionary<string, dynamic> IpnResponse = new Dictionary<string, dynamic>();
            string[] IPNPID = { "35807759" };
            string[] IPNPNAME = { "Cart_000001070" };
            string[] IPN_DATE = { "20210517104249" };
            IpnResponse.Add("IPNPID", IPNPID);
            IpnResponse.Add("IPNPNAME", IPNPNAME);
            IpnResponse.Add("IPN_DATE", IPN_DATE);
            return IpnResponse;
        }

        public dynamic GetIpnDictionary()
        {
            Dictionary<string, dynamic> IpnResponse = new Dictionary<string, dynamic>();
            IpnResponse.Add("GIFT_ORDER", "0");
            IpnResponse.Add("SALEDATE", "2021-05-17 10:42:42");
            IpnResponse.Add("PAYMENTDATE", "2021-05-17 10:42:45");
            IpnResponse.Add("REFNO", "152604755");
            IpnResponse.Add("REFNOEXT", "000001070");
            IpnResponse.Add("SHOPPER_REFERENCE_NUMBER", "");
            IpnResponse.Add("ORDERNO", "10372");
            IpnResponse.Add("ORDERSTATUS", "COMPLETE");
            IpnResponse.Add("PAYMETHOD", "Visa/MasterCard");
            IpnResponse.Add("PAYMETHOD_CODE", "CCVISAMC");
            IpnResponse.Add("FIRSTNAME", "John");
            IpnResponse.Add("LASTNAME", "Doe");
            IpnResponse.Add("COMPANY", "2co");
            IpnResponse.Add("REGISTRATIONNUMBER", "");
            IpnResponse.Add("FISCALCODE", "");
            IpnResponse.Add("TAX_OFFICE", "");
            IpnResponse.Add("CBANKNAME", "");
            IpnResponse.Add("CBANKACCOUNT", "");
            IpnResponse.Add("ADDRESS1", "Utah Street");
            IpnResponse.Add("ADDRESS2", "");
            IpnResponse.Add("CITY", "Utah");
            IpnResponse.Add("STATE", "Utah");
            IpnResponse.Add("ZIPCODE", "84101");
            IpnResponse.Add("COUNTRY", "United States of America");
            IpnResponse.Add("COUNTRY_CODE", "us");
            IpnResponse.Add("PHONE", "+10705959442");
            IpnResponse.Add("FAX", "");
            IpnResponse.Add("CUSTOMEREMAIL", "alex.pietrareanu@2checkout.com");
            IpnResponse.Add("FIRSTNAME_D", "John");
            IpnResponse.Add("LASTNAME_D", "Doe");
            IpnResponse.Add("COMPANY_D", "2co");
            IpnResponse.Add("ADDRESS1_D", "Utah Street");
            IpnResponse.Add("ADDRESS2_D", "");
            IpnResponse.Add("CITY_D", "Utah");
            IpnResponse.Add("STATE_D", "Utah");
            IpnResponse.Add("ZIPCODE_D", "84101");
            IpnResponse.Add("COUNTRY_D", "United States of America");
            IpnResponse.Add("COUNTRY_D_CODE", "us");
            IpnResponse.Add("PHONE_D", "+10705959442");
            IpnResponse.Add("EMAIL_D", "alex.pietrareanu@2checkout.com");
            IpnResponse.Add("IPADDRESS", "62.231.103.185");
            IpnResponse.Add("IPCOUNTRY", "Romania");
            IpnResponse.Add("COMPLETE_DATE", "2021-05-17 10:42:47");
            IpnResponse.Add("TIMEZONE_OFFSET", "GMT+03:00");
            IpnResponse.Add("CURRENCY", "USD");
            IpnResponse.Add("LANGUAGE", "en");
            IpnResponse.Add("ORDERFLOW", "REGULAR");
            IpnResponse.Add("IPNPID", "35807759");
            IpnResponse.Add("IPNPNAME", "Cart_000001070");
            IpnResponse.Add("IPNPCODE", "");
            IpnResponse.Add("IPNEXTERNALREFERENCE", "");
            IpnResponse.Add("IPNINFO", "");
            IpnResponse.Add("IPNQTY", "1");
            IpnResponse.Add("IPNPRICE", "59.00");
            IpnResponse.Add("IPNVAT", "0.00");
            IpnResponse.Add("IPNVATRATE", "0.0000");
            IpnResponse.Add("IPNVER", "1");
            IpnResponse.Add("IPNDISCOUNT", "0.00");
            IpnResponse.Add("IPNPROMOTIONCATEGORY", "");
            IpnResponse.Add("IPNPROMONAME", "");
            IpnResponse.Add("IPNPROMOCODE", "");
            IpnResponse.Add("IPNORDERCOSTS", "0");
            IpnResponse.Add("IPNSKU", "");
            IpnResponse.Add("IPN_PARTNER_CODE", "");
            IpnResponse.Add("IPNPGROUP", "0");
            IpnResponse.Add("IPNPGROUPNAME", "");
            IpnResponse.Add("MESSAGE_ID", "250984930862");
            IpnResponse.Add("MESSAGE_TYPE", "COMPLETE");
            IpnResponse.Add("IPNLICENSEPROD", "35807759");
            IpnResponse.Add("IPNLICENSETYPE", "REGULAR");
            IpnResponse.Add("IPNLICENSEREF", "5AATIL932A");
            IpnResponse.Add("IPNLICENSEEXP", "9999-12-31 23:59:59");
            IpnResponse.Add("IPNLICENSESTART", "2021-05-17 10:42:45");
            IpnResponse.Add("IPNLICENSELIFETIME", "YES");
            IpnResponse.Add("IPNLICENSEADDITIONALINFO", "");
            IpnResponse.Add("IPNDELIVEREDCODES", "");
            IpnResponse.Add("IPN_DOWNLOAD_LINK", "");
            IpnResponse.Add("IPNTOTAL", "59.00");
            IpnResponse.Add("IPN_TOTALGENERAL", "59.00");
            IpnResponse.Add("IPN_SHIPPING", "0.00");
            IpnResponse.Add("IPN_SHIPPING_TAX", "0.00");
            IpnResponse.Add("AVANGATE_CUSTOMER_REFERENCE", "466382788");
            IpnResponse.Add("EXTERNAL_CUSTOMER_REFERENCE", "");
            IpnResponse.Add("IPN_PARTNER_MARGIN_PERCENT", "0.00");
            IpnResponse.Add("IPN_PARTNER_MARGIN", "0.00");
            IpnResponse.Add("IPN_EXTRA_MARGIN", "0.00");
            IpnResponse.Add("IPN_EXTRA_DISCOUNT", "0.00");
            IpnResponse.Add("IPN_COUPON_DISCOUNT", "0.00");
            IpnResponse.Add("IPN_LINK_SOURCE", "MAGENTO2");
            IpnResponse.Add("IPN_COMMISSION", "2.4287");
            IpnResponse.Add("REFUND_TYPE", "");
            IpnResponse.Add("CHARGEBACK_RESOLUTION", "NONE");
            IpnResponse.Add("CHARGEBACK_REASON_CODE", "");
            IpnResponse.Add("TEST_ORDER", "1");
            IpnResponse.Add("IPN_ORDER_ORIGIN", "Web");
            IpnResponse.Add("FRAUD_STATUS", "APPROVED");
            IpnResponse.Add("CARD_TYPE", "visa");
            IpnResponse.Add("CARD_LAST_DIGITS", "1111");
            IpnResponse.Add("CARD_EXPIRATION_DATE", "01/23");
            IpnResponse.Add("GATEWAY_RESPONSE", "Approved");
            IpnResponse.Add("IPN_DATE", "20210517104249");
            IpnResponse.Add("FX_RATE", "1");
            IpnResponse.Add("FX_MARKUP", "0");
            IpnResponse.Add("PAYABLE_AMOUNT", "56.57");
            IpnResponse.Add("PAYOUT_CURRENCY", "USD");
            IpnResponse.Add("VENDOR_CODE", "250111206876");
            IpnResponse.Add("PROPOSAL_ID", "");
            IpnResponse.Add("HASH", "9f8e2c105f29e72c547e8c0f2607cb92");
            return IpnResponse;
        }
    }
}
