using Banking.Models;

namespace Banking.Cli
{
    public class CommandBaseApplication
    {
        public void Run(IShell shell, ViewFactory viewFactory)
        {
            int choice = 0;
            bool loop = true;
            do
            {
                choice = Options.Show(shell);
                if (choice != 0)
                {
                    var myView = viewFactory.Create(choice);
                    myView?.Show();
                }
                else
                {
                    loop = false;
                }

            } while (loop);
        }
    }
}