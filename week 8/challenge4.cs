using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week8_task4_
{
    internal class Program
    {
        class account
        {
            protected string accountTitle;
            protected int accountNumber;
            protected double balance;

            public account(string title, int number, double balance)
            {
                this.accountTitle = title;
                this.accountNumber = number;
                this.balance = balance;
            }

            public void credit(double amount)
            {
                balance += amount;
                Console.WriteLine("Amount Deposited: " + amount);
            }

            public virtual void debit(double amount)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine("Amount Withdrawn: " + amount);
                }
                else
                {
                    Console.WriteLine("Insufficient Balance!");
                }
            }

            public string toString()
            {
                return "Title: " + accountTitle +
                       "\nAccount No: " + accountNumber +
                       "\nBalance: " + balance;
            }
        }

        class studentAccount : account
        {
            private double creditLimit = 500000;

            public studentAccount(string title, int number, double balance)
                : base(title, number, balance)
            {
            }

            public override void debit(double amount)
            {
                if (amount <= balance + creditLimit)
                {
                    balance -= amount;
                    Console.WriteLine("Student Withdraw: " + amount);
                }
                else
                {
                    Console.WriteLine("Limit Exceeded!");
                }
            }
        }

        class savingAccount : account
        {
            private double profitRate;

            public savingAccount(string title, int number, double balance, double rate)
                : base(title, number, balance)
            {
                this.profitRate = rate;
            }

            public void addProfit()
            {
                double profit = balance * profitRate;
                balance += profit;
                Console.WriteLine("Profit Added: " + profit);
            }
        }
        static void Main(string[] args)
        {
            studentAccount s1 = new studentAccount("Ali", 101, 10000);
            s1.credit(5000);
            s1.debit(20000);
            Console.WriteLine(s1.toString());

            Console.WriteLine("-------------------");

            savingAccount s2 = new savingAccount("Ahmed", 102, 20000, 0.1);
            s2.addProfit();
            s2.debit(5000);
            Console.WriteLine(s2.toString());
        }
    }
}
