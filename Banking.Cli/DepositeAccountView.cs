using System;
using System.IO;
using Banking.Models;
using Newtonsoft.Json;

namespace Banking.Cli
{
    public class DepositeAccountView : View
    {

        public DepositeAccountView(string header, IShell shell, IRepository repo)
        : base(header, shell, repo)
        {

        }
        protected override void ShowContent()
        {
            Shell.Write("Account No:");
            var accountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Balance:");
            var amount = Convert.ToDecimal(Shell.ReadLine());
            IAccount account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{accountId}.acc"));
            account.Deposite(amount);
            Repository.Save(account);
            Shell.WriteLine($"Account {accountId} successfully deposited amount {amount}");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}