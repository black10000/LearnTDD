using System;
using System.Collections.Generic;
using Banking.Models;

namespace Banking.Cli
{
    public class CreateAccountView : View
    {

        public CreateAccountView(string header, IShell shell, IRepository repo, IAccountFactory accountFactory)
        : base(header, shell, repo, accountFactory)
        {

        }
        protected override void ShowContent()
        {
            Shell.Write("Account No:");
            var accountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Balance:");
            var amount = Convert.ToDecimal(Shell.ReadLine());
            var account = AccountFactory.Create(accountId, amount);
            Repository.Save(account);
            Shell.WriteLine($"Account {accountId} created successfully");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}