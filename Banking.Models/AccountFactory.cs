namespace Banking.Models
{
    public class AccountFactory : IAccountFactory
    {
        public IAccount Create(int id, decimal amount)
        {
            return new Account(id, amount);
        }
    }
}