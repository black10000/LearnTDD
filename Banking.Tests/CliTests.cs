using System;
using Xunit;
using Moq;
using Banking.Cli;
using Banking.Models;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class CliTests
    {
        [Fact]
        public void Custom_Choice_Option_Test()
        {
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1");
            var choice = Options.Show(consoleMock.Object);
            Assert.Equal(1, choice);
        }
        [Fact]
        public void Shell_ReadLine_When_Options_Choice()
        {
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1");
            var choice = Options.Show(consoleMock.Object);
            consoleMock.Verify(c => c.ReadLine(), Times.Exactly(1));
        }
        [Fact]
        public void Create_Account_Test()
        {
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accId = 0;
            decimal balance = 0;
            repoMock.Setup(r => r.Save(It.IsAny<IAccount>()))
            .Callback<IAccount>(a => (accId, balance) = (a.AccountId, a.Balance));
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1");
            Options.Show(consoleMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2000");
            var viewFactory = new ViewFactory(consoleMock.Object, repoMock.Object, new AccountFactory());
            var myview = viewFactory.Create(1);
            myview.Show();
            Assert.Equal(1111, accId);
            Assert.Equal(2000, balance);
        }
        [Fact]
        public void Deposite_Amount_Test()
        {
            var repo = new FileRepository(".");
            var transactionsMock = new Mock<List<ITransaction>>();
            var accountFactoryMock = new Mock<IAccountFactory>();
            var accountFactory = accountFactoryMock.Object;
            repo.Save(new AccountFactory().Create(1111, 0));
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accId = 0;
            decimal balance = 0;
            repoMock.Setup(r => r.Save(It.IsAny<IAccount>()))
            .Callback<IAccount>(a => (accId, balance) = (a.AccountId, a.Balance));
            //var createAccView = new CreateAccountView("fool", consoleMock.Object, repoMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("2");
            Options.Show(consoleMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2000");
            var viewFactory = new ViewFactory(consoleMock.Object, repoMock.Object, accountFactory);
            var myview = viewFactory.Create(2);
            myview.Show();
            Assert.Equal(1111, accId);
            Assert.Equal(2000, balance);
        }
        [Fact]
        public void Withdraw_Amount_Test()
        {
            var repo = new FileRepository(".");
            var accountFactoryMock = new Mock<IAccountFactory>();
            var accountFactory = accountFactoryMock.Object;
            repo.Save(new AccountFactory().Create(1111, 2000));
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accId = 0;
            decimal balance = 0;
            repoMock.Setup(r => r.Save(It.IsAny<IAccount>()))
            .Callback<IAccount>(a => (accId, balance) = (a.AccountId, a.Balance));
            //var createAccView = new CreateAccountView("fool", consoleMock.Object, repoMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("3");
            Options.Show(consoleMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("1000");
            var viewFactory = new ViewFactory(consoleMock.Object, repoMock.Object, accountFactory);
            var myview = viewFactory.Create(3);
            myview.Show();
            Assert.Equal(1111, accId);
            Assert.Equal(1000, balance);
        }
        [Fact]
        public void Transfer_Amount_Test()
        {
            var repo = new FileRepository(".");
            var accountFactoryMock = new Mock<IAccountFactory>();
            var accountFactory = new AccountFactory();
            repo.Save(accountFactory.Create(1, 2000));
            repo.Save(accountFactory.Create(2, 3000));
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accId = 0;
            decimal balance = 0;
            repoMock.Setup(r => r.Save(It.IsAny<IAccount>()))
            .Callback<IAccount>(a => (accId, balance) = (a.AccountId, a.Balance));
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("4");
            Options.Show(consoleMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns("2")
                .Returns("1000");
            var viewFactory = new ViewFactory(consoleMock.Object, repoMock.Object, accountFactoryMock.Object);
            var myview = viewFactory.Create(4);
            myview.Show();
            Assert.Equal(2, accId);
            Assert.Equal(4000, balance);
        }
        [Fact]
        public void Command_Base_Application_Full_Test()
        {
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accountFactoryMock = new Mock<IAccountFactory>();
            var viewFactoryMock = new Mock<ViewFactory>(consoleMock.Object, repoMock.Object, accountFactoryMock.Object);
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns("1111")
                .Returns("2000");
            var consoleApp = new CommandBaseApplication();
            var viewFactory = viewFactoryMock.Object;
            consoleApp.Run(consoleMock.Object, viewFactory);
            viewFactoryMock.Verify(v => v.Create(1));
        }
        [Fact]
        public void Invalid_Option_When_View_Factory_Is_Mate()
        {
            var consoleMock = new Mock<IShell>();
            var repoMock = new Mock<IRepository>();
            var accountFactoryMock = new Mock<IAccountFactory>();
            var viewFactory = new ViewFactory(consoleMock.Object, repoMock.Object, accountFactoryMock.Object);
            Assert.ThrowsAny<InvalidOptionException>(() => viewFactory.Create(0));
        }
    }
}