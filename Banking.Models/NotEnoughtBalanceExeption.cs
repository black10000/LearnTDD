using System;

namespace Banking.Models{
    public class NotEnoughtBalanceExeption : Exception{
        public decimal CurrentBalance {get; private set;}
        public NotEnoughtBalanceExeption(decimal balance) => CurrentBalance = balance;
    }
}
