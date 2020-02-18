using System.IO;
using Banking.Models;
using Newtonsoft.Json;

namespace Banking.Models
{
    public class FileRepository : IRepository
    {
        public string BasePath { get; private set; }
        public FileRepository(string basePath) => BasePath = basePath;
        public void Save(IAccount account)
        {
            var filePath = Path.Combine(BasePath, $"{account.AccountId}.acc");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(account));
        }
    }
}
