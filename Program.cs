using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = AccountCreator(690, 22.5);
            BankAccount account2 = AccountCreator(430, 20);
            

            TryDeposit(account2, 400);
            TryDeposit(account2, -1000);
            TryWithdraw(account2, 500);
            TryWithdraw(account2, 500);
            TryWithdraw(account2, -1);

            Console.ReadLine();
            
        }
        
        /// <summary>
        /// to avoid repitition code 
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="interestrate"></param>
        /// <returns></returns>
        public static BankAccount AccountCreator(double balance, double interestrate)
        {
            try
            {
                BankAccount account = new BankAccount(balance, interestrate);
                Console.WriteLine("Account created successfully.\n");
                return account;
            }
            catch (InterestRateException ex)
            {
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);
                foreach (DictionaryEntry entry in ex.Data)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\n");
                return null;
            }
        }
        /// <summary>
        /// to avoid repitition code
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public static void TryDeposit(BankAccount account, double amount)
        {
            try
            {
                account.Deposit(amount);
                Console.WriteLine("Operation completed successfully.\n");
            }
            catch (DepositException ex)
            {
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);
                foreach (DictionaryEntry entry in ex.Data)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\n");
            }
           
        }

        /// <summary>
        /// to avoid repitition code
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public static void TryWithdraw(BankAccount account, double amount)
        {
            try
            {
                account.Withdraw(amount);
                Console.WriteLine("Operation completed successfully.\n");
            }
            catch (WithdrawException ex) when (amount < 0)
            {
                Console.WriteLine(ex.Source);
                Console.WriteLine($"{ex.Message}: withdraw can't be negative.");
                foreach (DictionaryEntry entry in ex.Data)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\n");
            }
            catch (WithdrawException ex) when (amount > account.Balance)
            {
                Console.WriteLine(ex.Source);
                Console.WriteLine($"{ex.Message}: withdraw can't be larger than balance.");
                foreach (DictionaryEntry entry in ex.Data)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\n");
            }
        }
    }
}
