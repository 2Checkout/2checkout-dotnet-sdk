using System;
using System.Collections.Generic;

namespace TwoCheckout
{
    public class TwoCheckoutSubscription
    {
        private TwoCheckoutUtil Tco;
        public TwoCheckoutSubscription()
        {
            this.Tco = new TwoCheckoutUtil();
        }

        public string CreateSubscription(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> SubscriptionParams)
        {
            String jsonParamsPost = Tco.ConvertToJson(SubscriptionParams);
            return Tco.Call(TwoCheckoutConfig.ApiUrl + "/subscriptions/", TwoCheckoutConfig, "POST", jsonParamsPost);
        }

        public string GetSubscription(TwoCheckoutConfig TwoCheckoutConfig, string SubscriptionReference)
        {
            return Tco.Call(TwoCheckoutConfig.ApiUrl + "/subscriptions/" + SubscriptionReference + "/", TwoCheckoutConfig, "GET");
        }
    }
}
