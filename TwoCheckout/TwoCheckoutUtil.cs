using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using TwoCheckout.Exceptions;

namespace TwoCheckout
{
    public class TwoCheckoutUtil
    {
        public const string UserAgent = "2Checkout .NET Library/1.0.0";

        public TwoCheckoutUtil()
        {

        }

        public string[] GetHeaders(TwoCheckoutConfig TwoCheckoutConfig)
        {
            var GmtDate = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH':'mm':'ss");
            var StringHash = TwoCheckoutConfig.SellerId.Length + TwoCheckoutConfig.SellerId + GmtDate.ToString().Length + GmtDate.ToString();
            var Data = Encoding.UTF8.GetBytes(StringHash);
            var Key = Encoding.UTF8.GetBytes(TwoCheckoutConfig.SecretKey);
            var Hmac = new HMACMD5(Key);
            var HashBytes = Hmac.ComputeHash(Data);
            var Hash = System.BitConverter.ToString(HashBytes).Replace("-", "").ToLower();
            string AvangateCode = "code=\"" + TwoCheckoutConfig.SellerId + "\" date=\"" + GmtDate + "\" hash=\"" + Hash + "\"";
            string[] Headers = { "application/json", "application/json", AvangateCode };
            return Headers;
        }

        public string ConvertToJson(object source)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(source, Formatting.None,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        public string QueryString(IDictionary<string, dynamic> dict)
        {
            var list = new List<string>();
            foreach (var item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            return string.Join("&", list);
        }

        public string Call(string Url, TwoCheckoutConfig TwoCheckoutConfig, string method = "POST", dynamic Parameters = null, dynamic JwtToken = null)
        {
            HttpWebRequest Request;
            string[] Headers = GetHeaders(TwoCheckoutConfig);
            string Result = null;
            string ContentType = Headers[0];
            string Accept = Headers[1];
            HttpWebResponse Response = null;

            try
            {
                Request = WebRequest.Create(Url.ToString()) as HttpWebRequest;
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                Request.Method = method;
                Request.ContentType = ContentType;
                Request.Accept = Accept;
                Request.UserAgent = UserAgent;
                if (JwtToken is null)
                {
                    Request.Headers.Add("X-Avangate-Authentication", Headers[2]);
                }
                else
                {
                    Request.Headers.Add("merchant-token", JwtToken);
                }

                if (method == "GET")
                {

                    if (Parameters != null)
                    {
                        Parameters = QueryString(Parameters);
                        Url = String.Concat(Url, "?", Parameters);
                    }

                }
                if (method == "POST")
                {
                    byte[] byteData = UTF8Encoding.UTF8.GetBytes(Parameters);
                    Request.ContentLength = byteData.Length;
                    using (Stream postStream = Request.GetRequestStream())
                    {
                        postStream.Write(byteData, 0, byteData.Length);
                    }
                }

               
                using (Response = Request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(Response.GetResponseStream());
                    Result = reader.ReadToEnd();
                    return Result;
                }
            }
            catch (WebException wex)
            {
                String ResultCode = null;
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        JObject RawError = null;
                        StreamReader reader = new StreamReader(errorResponse.GetResponseStream());
                        Result = reader.ReadToEnd();
                        if(Result is string)
                        {
                            ResultCode = "511";
                        }
                        else
                        {
                            RawError = JObject.Parse(Result);
                            if (RawError["error_code"] != null)
                            {
                                Result = RawError["message"].ToString();
                                ResultCode = RawError["error_code"].ToString();
                            }
                            else if (RawError["Errors"] != null)
                            {
                                foreach (string ApiError in RawError["Errors"])
                                {
                                    Result = ApiError.ToString() + "\n";
                                }
                            }
                        }
                    }
                }
                else
                {
                    Result = wex.Message;
                    ResultCode = "500";
                }
                throw new TwoCheckoutException(Result) { Code = ResultCode };
            }
            finally
            {
                if (Response != null) { Response.Close(); }
            }
        }
    }
}
