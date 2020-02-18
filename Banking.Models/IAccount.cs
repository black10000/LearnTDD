using System;
using System.Collections.Generic;

namespace Banking.Models
{
    public interface IAccount
    {
        int AccountId { get; set; }
        decimal Balance { get; }
        List<Transaction> Transactions { get; }
        void Deposite(decimal v);
        void Withdraw(decimal value);

    }
}
