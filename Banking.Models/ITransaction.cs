using System;

namespace Banking.Models
{
    public interface ITransaction
    {
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        TransactionType TransactionType { get; set; }
    }
}