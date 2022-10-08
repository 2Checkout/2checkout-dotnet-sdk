namespace TwoCheckout.Entities
{
    public class Price
    {
        public int Amount { get; set; }
        public string Type { get; set; }

        public Price(int amount, string type)
        {
            this.Amount = amount;
            this.Type = type;
        }
    }
}
