namespace Banking.Models
{
    public interface ITransferService
    {
        void Transfer(IAccount from, IAccount to, decimal amount);
    }
}