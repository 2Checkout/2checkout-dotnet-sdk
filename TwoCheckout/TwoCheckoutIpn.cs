using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TwoCheckout
{
    public class TwoCheckoutIpn
    {
        public TwoCheckoutIpn()
        {

        }

        public string CalculateIpnResponse(string SecretKey, string Now, Dictionary<string, dynamic> IpnResponse)
        {
            string ResultResponse = "";
            IpnResponse.Add("DATE", Now);
            foreach (var item in IpnResponse.Values)
            {
                if (item.GetType().IsArray)
                {
                    ResultResponse += ArrayExpand(item);
                }
                else
                {
                    ResultResponse += StripSlashes(item).Length + StripSlashes(item);
                }
                    
            }
            return "<EPAYMENT>" + IpnResponse["DATE"] + "|" + HmacMd5(ResultResponse, SecretKey) + "</EPAYMENT>";
        }

        public bool IsIpnResponseValid(string SecretKey, Dictionary<string, dynamic> IpnParams)
        {
            string Result = "";
            string ReceivedHash = IpnParams["HASH"];

            foreach (var item in IpnParams)
            {
                if(item.Key != "HASH")
                {
                    if (item.Value.GetType().IsArray)
                    {
                        Result += ArrayExpand(item.Value);
                    }
                    else
                    {
                        Result += StripSlashes(item.Value).Length + StripSlashes(item.Value);
                    }
                }
            }

            if (IpnParams["REFNO"] != null)
            {
                string CalcHash = HmacMd5(Result, SecretKey);
                if (ReceivedHash == CalcHash )
			    {
                    return true;
                }

             }
            return false;
        }
        public string ArrayExpand(dynamic itemArray)
        {
		    string RetVal = "";
            foreach(dynamic item in itemArray)
            {
                var itemClean = StripSlashes(item);
                var size = itemClean.Length;
                RetVal += size + itemClean;
            }
            return RetVal;
        }
        public string StripSlashes(dynamic InputTxt)
        {
            string Result = InputTxt.ToString();

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt.ToString(), @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return Result;
        }

        public dynamic HmacMd5(string ResultResponse, string SecretKey)
        {
            var data = Encoding.UTF8.GetBytes(ResultResponse);
            var key = Encoding.UTF8.GetBytes(SecretKey);
            var hmac = new HMACMD5(key);
            var hashBytes = hmac.ComputeHash(data);
            return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
