using Banking.Models;
using Moq;
using Xunit;

namespace Banking.Tests
{
    public class TransferServiceTest
    {
        [Fact]
        public void Transfer_Service_Work_Correctly()
        {
            var transferServiceMock = new Mock<ITransferService>();
            var fromAcc = new Mock<IAccount>();
            var toAcc = new Mock<IAccount>();
            var transferService = transferServiceMock.Object;
            transferService.Transfer(fromAcc.Object, toAcc.Object, 1000);
            transferServiceMock.Verify(t => t.Transfer(It.IsAny<IAccount>(), It.IsAny<IAccount>(), It.IsAny<decimal>()));
        }
    }
}