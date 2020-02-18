using Banking.Models;

namespace Banking.Cli
{
    public abstract class View
    {
        public string Header { get; private set; }
        public IShell Shell { get; private set; }
        public IRepository Repository { get; private set; }
        public IAccountFactory AccountFactory { get; private set; }
        public View(string header, IShell shell, IRepository repo, IAccountFactory accountFactory)
        {
            Header = header;
            Shell = shell;
            Repository = repo;
            AccountFactory = accountFactory;
        }
        public View(string header, IShell shell, IRepository repo)
        {
            Header = header;
            Shell = shell;
            Repository = repo;
        }
        public void Show()
        {
            ShowHeader();
            ShowContent();
        }

        protected abstract void ShowContent();

        private void ShowHeader()
        {
            Shell.WriteLine("--------------------");
            Shell.WriteLine(Header);
            Shell.WriteLine("--------------------");
        }
    }
}