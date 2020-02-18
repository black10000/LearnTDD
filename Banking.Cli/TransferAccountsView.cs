using System;
using System.IO;
using Banking.Models;
using Newtonsoft.Json;

namespace Banking.Cli
{
    public class TransferAccountsView : View
    {
        public TransferAccountsView(string header, IShell shell, IRepository repo)
        : base(header, shell, repo)
        {

        }
        protected override void ShowContent()
        {
            Shell.Write("Transfer Account No:");
            var transferAccountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Receiver Account No:");
            var receiverAccountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Balance:");
            var amount = Convert.ToDecimal(Shell.ReadLine());
            Account transferAccount = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{transferAccountId}.acc"));
            Account receiverAccount = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{receiverAccountId}.acc"));
            var transferService = new TransferService();
            transferService.Transfer(transferAccount, receiverAccount, amount);
            Repository.Save(transferAccount);
            Repository.Save(receiverAccount);
            Shell.WriteLine($"Account {transferAccountId} successfully withdraw amount {amount}");
            Shell.WriteLine($"Account {receiverAccountId} successfully deposited amount {amount}");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}