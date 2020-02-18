using System;

namespace Banking.Cli
{
    public static class Options
    {
        public static int Show(IShell shell)
        {
            shell.WriteLine("--------------------");
            shell.WriteLine("Options");
            shell.WriteLine("--------------------");
            shell.WriteLine("0)Exit Program");
            shell.WriteLine("1)Create New Account");
            shell.WriteLine("2)Deposite");
            shell.WriteLine("3)Withdraw");
            shell.WriteLine("4)Transfer");
            shell.Write("Please Select:");
            var choice = Convert.ToInt32(shell.ReadLine());
            return choice;
        }
    }
}