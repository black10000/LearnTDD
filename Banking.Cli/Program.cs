using System;
using Banking.Models;

namespace Banking.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            new CommandBaseApplication().Run(new ConsoleShell(), new ViewFactory(new ConsoleShell(), new FileRepository("."), new AccountFactory()));
        }
    }
}
