using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class InterestRateException : ApplicationException
    {
        public InterestRateException() 
        {
        }
        public InterestRateException(string message) : base(message) 
        {
        }
        public InterestRateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
