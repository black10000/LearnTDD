using Banking.Models;

namespace Banking.Cli
{
    public class ViewFactory
    {
        private IShell Shell { get; set; }
        private IRepository Repository { get; set; }
        private IAccountFactory AccountFactory { get; set; }
        public ViewFactory() { }
        public ViewFactory(IShell shell, IRepository repo, IAccountFactory accountFactory)
        {
            Shell = shell;
            Repository = repo;
            AccountFactory = accountFactory;
        }
        //protected View Custom_Prefer_View { get; set; }u
        public virtual View Create(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new CreateAccountView("Create New Account", Shell, Repository, AccountFactory);
                case 2:
                    return new DepositeAccountView("Deposite", Shell, Repository);
                case 3:
                    return new WithdrawAccountView("Withdraw", Shell, Repository);
                case 4:
                    return new TransferAccountsView("Trasfer", Shell, Repository);
                default:
                    throw new InvalidOptionException();
            }
        }
    }
}