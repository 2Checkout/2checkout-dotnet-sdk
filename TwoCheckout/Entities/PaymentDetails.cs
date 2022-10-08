namespace TwoCheckout.Entities
{
    public class PaymentDetails
    {
        public string Type { get; set; }
        public string Currency { get; set; }
        public string CustomerIP { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public PaymentDetails(string paymentType, string currency, string customerIP, PaymentMethod paymentMethod)
        {
            this.Type = paymentType;
            this.Currency = currency;
            this.CustomerIP = customerIP;
            this.PaymentMethod = paymentMethod;
        }
    }
}
