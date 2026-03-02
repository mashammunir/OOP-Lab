using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task1
{
    class Transaction
    {
        public int TransactionId;
        public string ProductName;
        public double Amount;
        public DateTime Date;

        public Transaction(int id, string product, double amount, DateTime date)
        {
            TransactionId = id;
            ProductName = product;
            Amount = amount;
            Date = date;
        }

        public Transaction(Transaction t)
        {
            TransactionId = t.TransactionId;
            ProductName = t.ProductName;
            Amount = t.Amount;
            Date = t.Date;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction t1 = new Transaction(101, "Laptop", 75000, DateTime.Now);
            Transaction t2 = new Transaction(t1);

            t2.ProductName = "Mobile";

            Console.WriteLine(t1.TransactionId + " " + t1.ProductName + " " + t1.Amount + " " + t1.Date);
            Console.WriteLine(t2.TransactionId + " " + t2.ProductName + " " + t2.Amount + " " + t2.Date);
        }
    }
}