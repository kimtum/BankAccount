using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class BankAccount
    {
        private double balance;
        private double interestRate;

        public double Balance => this.balance;
        public double InterestRate => this.interestRate;

        public BankAccount(double balance, double interesrate)
        {
            if (interesrate < 0 || interesrate > 22) 
            {
                InterestRateException ex = new InterestRateException("Illegal operation: nonpermissive interest rate.");
                ex.Data["Requested interest rate"] = interesrate;
                ex.Data["Minimal interest rate"] = 0.0;
                ex.Data["Maximal interestrate"] = 22.0;
                ex.Data["Timestamp"] = DateTime.Now;
                throw ex;
            }
            this.balance = balance;
            this.interestRate = interesrate;
        }

        public void Withdraw(double amount) 
        {
            if(amount > this.balance || amount < 0)
            {
                WithdrawException ex = new WithdrawException("Illegal operation");
                ex.Data["Requested withdraw"] = amount;
                ex.Data["Current balance"] = this.Balance;
                ex.Data["Timestamp"] = DateTime.Now;
                throw ex;
            }
            this.balance -= amount;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                DepositException ex = new DepositException("Illegal operation: Deposit can't be negative.");
                ex.Data["Requested deposit"] = amount;
                ex.Data["Timestamp"] = DateTime.Now;
                throw ex;
            }
            
            this.balance += amount;
        }
    }
}
