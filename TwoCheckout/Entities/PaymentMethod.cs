namespace TwoCheckout.Entities
{
    public class PaymentMethod
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Vendor3DSReturnURL { get; set; }
        public string Vendor3DSCancelURL { get; set; }
        public string ExpirationYear { get; set; }
        public string ExpirationMonth { get; set; }
        public string CCID { get; set; }
        public string HolderName { get; set; }
        public bool RecurringEnabled { get; set; }
        public int HolderNameTime { get; set; }
        public int CardNumberTime { get; set; }

        public PaymentMethod(string cardNumber, string cardType, string vendor3DSReturnURL, string vendor3DSCancelURL, string expirationYear, string expirationMonth, string ccid, string holderName, bool recurringEnabled, int holderNameTime, int cardNumberTime)
        {
            this.CardNumber = cardNumber;
            this.CardType = cardType;
            this.Vendor3DSReturnURL = vendor3DSReturnURL;
            this.Vendor3DSCancelURL = vendor3DSCancelURL;
            this.ExpirationYear = expirationYear;
            this.ExpirationMonth = expirationMonth;
            this.CCID = ccid;
            this.HolderName = holderName;
            this.RecurringEnabled = recurringEnabled;
            this.HolderNameTime = holderNameTime;
            this.CardNumberTime = cardNumberTime;
        }
    }
}
