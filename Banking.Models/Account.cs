using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Models
{
    public class Account : IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance
        {
            get
            {
                return Transactions.Where(t => t.TransactionType == TransactionType.Credit).Select(t => t.Amount).Sum()
               - Transactions.Where(t => t.TransactionType == TransactionType.Debit).Select(t => t.Amount).Sum();
            }
        }
        public List<Transaction> Transactions { get; }
        public Account(int accountId = 0, decimal amount = 0)
        {
            AccountId = accountId;
            Transactions = new List<Transaction>();
            var transaction = new Transaction(DateTime.Now, amount, TransactionType.Credit);
            Transactions.Add(transaction);
        }

        public void Deposite(decimal amount)
        {
            var transaction = new Transaction(DateTime.Now, amount, TransactionType.Credit);
            Transactions.Add(transaction);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= this.Balance)
            {
                var transaction = new Transaction(DateTime.Now, amount, TransactionType.Debit);
                Transactions.Add(transaction);
            }
            else
                throw new NotEnoughtBalanceExeption(this.Balance);
        }
    }
}