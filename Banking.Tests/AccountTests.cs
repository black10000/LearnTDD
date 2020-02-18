using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Banking.Models;
using Xunit;
using Moq;

namespace Banking.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Deposite_Should_Update_Correct_Balance_Amount_When_Deposite_Is_Made()
        {
            var account = new Account(1111);
            account.Deposite(1000);
            Assert.Equal(1000, account.Balance);
        }
        [Fact]
        public void Withdraw_Should_Update_Correct_Balance()
        {
            var account = new Account(1111, 2000);
            account.Withdraw(1000);
            Assert.Equal(1000, account.Balance);
        }

        [Fact]
        public void Withdraw_Throws_Exception_When_Balance_Is_Not_Enought()
        {
            var account = new Account(1111, 500);
            Assert.ThrowsAny<NotEnoughtBalanceExeption>(() => account.Withdraw(1000));
        }
        [Fact]
        public void Withdraw_Throws_Exception_When_Balance_Is_Not_Enought_And_Custom_Used_Current_Balance_From_Exception()
        {
            var account = new Account(1111, 500);
            try
            {
                account.Withdraw(1000);
            }
            catch (NotEnoughtBalanceExeption e)
            {
                Assert.Equal(500, e.CurrentBalance);
            }
        }

    }
}
