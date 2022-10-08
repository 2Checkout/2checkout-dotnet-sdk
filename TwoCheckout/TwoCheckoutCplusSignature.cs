using System;
using System.Collections.Generic;

namespace TwoCheckout
{
    public class TwoCheckoutCplusSignature
    {
        public string SignatureUrl = "https://secure.2checkout.com/checkout/api/encrypt/generate/signature";
        private TwoCheckoutUtil Tco;

        public TwoCheckoutCplusSignature()
        {
            this.Tco = new TwoCheckoutUtil();
        }

        public string GetSignature(TwoCheckoutConfig TwoCheckoutConfig, Dictionary<string, dynamic> CplusParamsDictionary)
        {
            String CplusParams = Tco.ConvertToJson(CplusParamsDictionary);
            int TokenExpiration = 3600;
            //must use time -1 second for it work
            int iat = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 10;
            int exp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + TokenExpiration;
            string JwtToken = GetJwtToken(TwoCheckoutConfig.SellerId, TwoCheckoutConfig.SecretWord, iat.ToString(), exp.ToString());
            return Tco.Call("https://secure.2checkout.com/checkout/api/encrypt/generate/signature", TwoCheckoutConfig, "POST", CplusParams, JwtToken.Trim());
        }

        public string GetJwtToken(string SellerId, string BuyLinkSecretWord, string iat, string exp)
        {
            var payload = new Dictionary<string, object>()
            {
                { "sub", SellerId },
                { "iat", iat },
                { "exp", exp  }
            };
            return JsonWebToken.Encode(payload, BuyLinkSecretWord, JwtHashAlgorithm.HS512);
        }
    }
}
