namespace Banking.Models
{
    public interface IAccountFactory
    {
        IAccount Create(int id, decimal amount);
    }
}