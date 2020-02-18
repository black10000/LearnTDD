namespace Banking.Models
{
    public class TransferService : ITransferService
    {
        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
            from.Withdraw(amount);
            to.Deposite(amount);
        }
    }
}