using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class Exeptions
    {
    }

    public class PaymentServiceExeption : System.Exception
    {
        public PaymentServiceExeption() : base() { }
        public PaymentServiceExeption (string message) : base(message) { }
    }

    public class LimitExceedExeption : PaymentServiceExeption
    {
        public LimitExceedExeption() : base() { }
        public LimitExceedExeption(string message) : base(message) { }
    }

    public class InsufficientFundsExeption : PaymentServiceExeption
    {
        public InsufficientFundsExeption() : base() { }        
        public InsufficientFundsExeption(string message) : base(message) { }
    }
}
