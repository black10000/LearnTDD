using System;
using Xunit;
using Moq;
using Banking.Cli;
using Banking.Models;
using System.IO;

namespace Banking.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Call_Save_When_Repository_Is_Save()
        {
            var repoMock = new Mock<IRepository>();
            var accMock = new Mock<IAccount>();
            repoMock.Object.Save(accMock.Object);
            repoMock.Verify(r => r.Save(It.IsAny<IAccount>()));
        }
    }
}