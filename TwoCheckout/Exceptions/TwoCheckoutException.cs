using System;

namespace TwoCheckout.Exceptions
{
    public class TwoCheckoutException : ApplicationException
    {
        public String Code { get; set; }

        public TwoCheckoutException(string message)
            : base(message)
        {

        }
    }
}
