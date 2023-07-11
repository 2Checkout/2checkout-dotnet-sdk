using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TwoCheckout
{
    public class TwoCheckoutIpn
    {
        public const string algoMd5 = "MD5";
        public const string algoSha256 = "SHA256";

        public TwoCheckoutIpn()
        {

        }

        public string CalculateIpnResponse(string SecretKey, string Now, Dictionary<string, dynamic> IpnResponse)
        {
            string response = "";

            string algorithm = GetHashAlgorithm(IpnResponse);
            if (algorithm != null)
            {
                string ResultResponse = "";
                ResultResponse += ArrayExpand(IpnResponse["IPN_PID"]);
                ResultResponse += ArrayExpand(IpnResponse["IPN_PNAME"]);
                ResultResponse += IpnResponse["IPN_DATE"].Length + IpnResponse["IPN_DATE"];
                ResultResponse += Now.Length + Now;

                if (algorithm.Equals(algoSha256))
                {
                    response = "<sig algo=\"sha256\" date=\"" + Now + "\">" + HmacSha256(ResultResponse, SecretKey) + "</sig>";
                }
                else
                {
                    response = "<EPAYMENT>" + Now + "|" + HmacMd5(ResultResponse, SecretKey) + "</EPAYMENT>";
                }
            }

            return response;
        }

        public bool IsIpnResponseValid(string SecretKey, Dictionary<string, dynamic> IpnParams)
        {
            string Result = "";
            string algorithm = GetHashAlgorithm(IpnParams);

            if (algorithm != null)
            {
                string ReceivedHash = algorithm.Equals(algoSha256) ? IpnParams["SIGNATURE_SHA2_256"] : IpnParams["HASH"];

                string[] array = { "HASH", "SIGNATURE_SHA3_256", "SIGNATURE_SHA2_256" };

                foreach (var item in IpnParams)
                {
                    if(!Array.Exists(array, element => element == item.Key))
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

                string CalcHash = null;
                if (algorithm.Equals(algoSha256))
                {
                    CalcHash = HmacSha256(Result, SecretKey);
                }
                else
                {
                    CalcHash = HmacMd5(Result, SecretKey);
                }

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

        public dynamic HmacSha256(string ResultResponse, string SecretKey)
        {
            var data = Encoding.UTF8.GetBytes(ResultResponse);
            var key = Encoding.UTF8.GetBytes(SecretKey);
            var hmac = new HMACSHA256(key);
            var hashBytes = hmac.ComputeHash(data);
            return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public String GetHashAlgorithm(Dictionary<string, dynamic> IpnParams)
        {
            String receivedAlgo = null;

            if (IpnParams.ContainsKey("SIGNATURE_SHA2_256"))
            {
                receivedAlgo = algoSha256;
            } else if (IpnParams.ContainsKey("HASH"))
            {
                receivedAlgo = algoMd5;
            }

            return receivedAlgo;
        }
    }
}
