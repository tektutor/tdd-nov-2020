using NUnit.Framework;
using Moq;
using System;

namespace TekTutor
{
    public class SavingsAccountTest
    {
        private Mock<SavingsAccount> partiallyMockedAccount;

        [SetUp]
        public void Setup()
        {
            partiallyMockedAccount = new Mock<SavingsAccount>();
        }

        [TearDown]
        public void CleanUp()
        {
            partiallyMockedAccount = null;
        }

        [Test]
        public void TestDepositWhenCurrentBalanceIs5000INR()
        {

            partiallyMockedAccount.SetupSequence(account => account.GetBalance())
                .Returns(5000.00)
                .Returns(15000.00);

            double actualBalance = partiallyMockedAccount.Object.Deposit(10000.00);

            double expectedBalance = 15000.00;
            Assert.That( actualBalance, Is.EqualTo(expectedBalance) );
            partiallyMockedAccount.Verify(account => account.GetBalance(), Times.AtLeast(1) );
            partiallyMockedAccount.Verify(account => account.UpdateBalanceInDB(It.IsAny<double>()), Times.AtLeast(1));


            //Demonstrates how SetUp can be done to return different values at different time
            actualBalance = partiallyMockedAccount.Object.Deposit(2000.00);
            expectedBalance = 17000.00;
            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
            partiallyMockedAccount.Verify(account => account.GetBalance(), Times.AtLeast(1));

        }

        [Test]
        public void TestDepositWhenCurrentBalanceIs15000INR()
        {
            partiallyMockedAccount.Setup(account => account.GetBalance()).Returns(15000.00);

            double actualBalance = partiallyMockedAccount.Object.Deposit(2000.00);
            
            double expectedBalance = 17000.00;
            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
            partiallyMockedAccount.Verify(account => account.GetBalance(), Times.AtLeast(1));
            partiallyMockedAccount.Verify(account => account.UpdateBalanceInDB(It.IsAny<double>()), Times.AtLeast(1));
        }

        [Test]
        public void TestWithdraw1000INRWhenCurrentBalanceIs900INR()
        {
            partiallyMockedAccount.Setup(account => account.GetBalance()).Returns(900.00);

            Assert.Throws(
                Is.TypeOf<Exception>().And.Message.EqualTo("Insufficient Balance"),
                delegate { partiallyMockedAccount.Object.Withdraw(1000.00); }
            );

            partiallyMockedAccount.Verify(account => account.GetBalance(), Times.Once());
            partiallyMockedAccount.Verify(account => account.UpdateBalanceInDB(It.IsAny<double>()), Times.Never() );

        }
    }
}