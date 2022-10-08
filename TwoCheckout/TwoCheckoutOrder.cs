using System;
using System.Collections.Generic;

namespace TwoCheckout
{
    public class TwoCheckoutOrder
    {
        private TwoCheckoutUtil Tco;
        public TwoCheckoutOrder()
        {
            this.Tco = new TwoCheckoutUtil();
        }
        public string PlaceOrder(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> OrderParams)
        {
            String jsonParamsPost = Tco.ConvertToJson(OrderParams);
            return Tco.Call(TwoCheckoutConfig.ApiUrl + "/orders/", TwoCheckoutConfig, "POST", jsonParamsPost);
        }

        public string GetOrder(TwoCheckoutConfig TwoCheckoutConfig, string RefNo)
        {
            return Tco.Call(TwoCheckoutConfig.ApiUrl + "/orders/" + RefNo + "/", TwoCheckoutConfig, "GET");
        }

        public string SearchOrder(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> OrderParams)
        {
            return Tco.Call(TwoCheckoutConfig.ApiUrl + "/orders/", TwoCheckoutConfig, "GET", OrderParams);
        }
    }
}
