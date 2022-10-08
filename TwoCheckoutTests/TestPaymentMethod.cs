using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestPaymentMethod
    {
        private string CardNumber;
        private string CardType;
        private string Vendor3DSReturnURL;
        private string Vendor3DSCancelURL;
        private string ExpirationYear;
        private string ExpirationMonth;
        private string CCID;
        private string HolderName;
        private bool RecurringEnabled;
        private int HolderNameTime;
        private int CardNumberTime;
        private PaymentMethod PaymentMethod;

        public void InstantiatePaymentMethod()
        {
            CardNumber = "Test";
            CardType = "Test";
            Vendor3DSReturnURL = "Test";
            Vendor3DSCancelURL = "Test";
            ExpirationYear = "Test";
            ExpirationMonth = "Test";
            CCID = "Test";
            HolderName = "Test";
            RecurringEnabled = true;
            HolderNameTime = 1;
            CardNumberTime = 2;
            PaymentMethod = new PaymentMethod(CardNumber, CardType, Vendor3DSReturnURL, Vendor3DSCancelURL, ExpirationYear, ExpirationMonth, CCID, HolderName, RecurringEnabled, HolderNameTime, CardNumberTime);
        }

        [TestMethod]
        public void IsPaymentMethodObject()
        {
            InstantiatePaymentMethod();
            Assert.IsInstanceOfType(PaymentMethod, typeof(PaymentMethod));
        }

        [TestMethod]
        public void IsCardNumberSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(CardNumber, PaymentMethod.CardNumber);
        }

        [TestMethod]
        public void IsCardTypeSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(CardType, PaymentMethod.CardType);
        }

        [TestMethod]
        public void IsVendor3DSReturnURLSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(Vendor3DSReturnURL, PaymentMethod.Vendor3DSReturnURL);
        }

        [TestMethod]
        public void IsVendor3DSCancelURLSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(Vendor3DSCancelURL, PaymentMethod.Vendor3DSCancelURL);
        }

        [TestMethod]
        public void IsExpirationYearSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(ExpirationYear, PaymentMethod.ExpirationYear);
        }

        [TestMethod]
        public void IsExpirationMonthSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(ExpirationMonth, PaymentMethod.ExpirationMonth);
        }

        [TestMethod]
        public void IsCCIDSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(CCID, PaymentMethod.CCID);
        }

        [TestMethod]
        public void IsHolderNameSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(HolderName, PaymentMethod.HolderName);
        }

        [TestMethod]
        public void IsRecurringEnabledLSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(RecurringEnabled, PaymentMethod.RecurringEnabled);
        }

        [TestMethod]
        public void IsHolderNameTimeSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(HolderNameTime, PaymentMethod.HolderNameTime);
        }

        [TestMethod]
        public void IsCardNumberTimeSet()
        {
            InstantiatePaymentMethod();
            Assert.AreEqual(CardNumberTime, PaymentMethod.CardNumberTime);
        }
    }
}
