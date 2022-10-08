namespace TwoCheckout
{
    public class TwoCheckoutConfig
    {

        public string SellerId { get; set; }
        public string SecretKey { get; set; }
        public string SecretWord { get; set; }
        public string ApiUrl = "https://api.2checkout.com/rest/6.0";

        public TwoCheckoutConfig(string sellerId = null, string secretKey = null, string secretWord = null)
        {
            this.SellerId = sellerId;
            this.SecretKey = secretKey;
            this.SecretWord = secretWord;
        }
    }
}
