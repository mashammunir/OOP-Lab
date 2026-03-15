using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task3
{
    class ATM
    {
        public double Balance;
        public List<string> History;

        public ATM(double balance)
        {
            Balance = balance;
            History = new List<string>();
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            History.Add("Deposited: " + amount);
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                History.Add("Withdrawn: " + amount);
            }
            else
            {
                History.Add("Withdraw Failed: Insufficient Balance");
            }
        }

        public double CheckBalance()
        {
            return Balance;
        }

        public void ShowHistory()
        {
            foreach (string record in History)
            {
                Console.WriteLine(record);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM(10000);

            atm.Deposit(2000);
            atm.Withdraw(1500);
            atm.Withdraw(20000);

            Console.WriteLine("Current Balance: " + atm.CheckBalance());
            Console.WriteLine("Transaction History:");
            atm.ShowHistory();
        }
    }
}                                 