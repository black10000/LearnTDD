using System;
using System.IO;
using Banking.Models;
using Newtonsoft.Json;

namespace Banking.Cli
{
    public class WithdrawAccountView : View
    {
        public WithdrawAccountView(string header, IShell shell, IRepository repo)
        : base(header, shell, repo)
        {

        }
        protected override void ShowContent()
        {
            Shell.Write("Account No:");
            var accountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Balance:");
            var amount = Convert.ToDecimal(Shell.ReadLine());
            Account account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{accountId}.acc"));
            account.Withdraw(amount);
            Repository.Save(account);
            Shell.WriteLine($"Account {accountId} successfully withdraw amount {amount}");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}