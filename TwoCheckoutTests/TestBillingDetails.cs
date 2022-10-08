using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;


namespace TwoCheckoutTests
{
    [TestClass]
    public class TestBillingDetails
    {
        private string Address1;
        private string City;
        private string State;
        private string CountryCode;
        private string Email;
        private string FirstName;
        private string LastName;
        private string Zip;
        private BillingDetails BillingDetails;

        public void InstantiateBillingDetails()
        {
            Address1 = "Test";
            City = "Test";
            State = "Test";
            CountryCode = "Test";
            Email = "Test";
            FirstName = "Test";
            LastName = "Test";
            Zip = "Test";
            BillingDetails = new BillingDetails(Address1, City, State, CountryCode, Email, FirstName, LastName, Zip);
        }

        [TestMethod]
        public void IsBillingDetailsObject()
        {
            InstantiateBillingDetails();
            Assert.IsInstanceOfType(BillingDetails, typeof(BillingDetails));
        }

        [TestMethod]
        public void IsAddress1Set()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(Address1, BillingDetails.Address1);
        }

        [TestMethod]
        public void IsCitySet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(City, BillingDetails.City);
        }

        [TestMethod]
        public void IsStateSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(State, BillingDetails.State);
        }

        [TestMethod]
        public void IsCountryCodeSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(CountryCode, BillingDetails.CountryCode);
        }

        [TestMethod]
        public void IsEmailSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(Email, BillingDetails.Email);
        }

        [TestMethod]
        public void IsFirstNameSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(FirstName, BillingDetails.FirstName);
        }

        [TestMethod]
        public void IsLastNameSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(LastName, BillingDetails.LastName);
        }

        [TestMethod]
        public void IsZipSet()
        {
            InstantiateBillingDetails();
            Assert.AreEqual(Zip, BillingDetails.Zip);
        }
    }
}
