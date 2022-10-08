namespace TwoCheckout.Entities
{
    public class OrderDetails
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string CustomerIP { get; set; }
        public string ExternalReference { get; set; }
        public string Language { get; set; }
        public string Source { get; set; }
        public BillingDetails BillingDetails { get; set; }
        public Item[] Items { get; set; }
        public PaymentDetails PaymentDetails { get; set; }

        public OrderDetails(string country, string currency, string customerIp, string externalReference, string language, string source, BillingDetails billingDetails, Item[] items, PaymentDetails paymentDetails)
        {
            this.Country = country;
            this.Currency = currency;
            this.CustomerIP = customerIp;
            this.ExternalReference = externalReference;
            this.Language = language;
            this.Source = source;
            this.BillingDetails = billingDetails;
            this.Items = items;
            this.PaymentDetails = paymentDetails;
        }
    }
}
