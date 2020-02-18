using System;

namespace Banking.Models
{
    public class Transaction : ITransaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public Transaction(DateTime date, decimal amount, TransactionType transactionType)
        {
            Date = date;
            Amount = amount;
            TransactionType = transactionType;
        }
    }
}