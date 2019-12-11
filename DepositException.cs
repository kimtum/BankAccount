using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class DepositException : ApplicationException
    {
        public DepositException()
        {
        }
        public DepositException(string message) : base(message)
        {
        }
        public DepositException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
