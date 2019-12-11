using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class WithdrawException : ApplicationException
    {
        public WithdrawException()
        {
        }
        public WithdrawException(string message) : base(message)
        {
        }
        public WithdrawException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
