using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwoCheckout.Entities;

namespace TwoCheckoutTests
{
    [TestClass]
    public class TestCrossSell
    {
        private string CampaignCode;
        private string ParentCode;
        private CrossSell CrossSell;

        public void InstatiateCrossSell()
        {
            CampaignCode = "Test";
            ParentCode = "Test";
            CrossSell = new CrossSell(CampaignCode, ParentCode);
        }

        [TestMethod]
        public void IsCrossSellObject()
        {
            InstatiateCrossSell();
            Assert.IsInstanceOfType(CrossSell, typeof(CrossSell));
        }

        [TestMethod]
        public void IsCampaignCodeSet()
        {
            InstatiateCrossSell();
            Assert.AreEqual(CampaignCode, CrossSell.CampaignCode);
        }

        [TestMethod]
        public void IsParentCodeSet()
        {
            InstatiateCrossSell();
            Assert.AreEqual(ParentCode, CrossSell.ParentCode);
        }
    }
}
