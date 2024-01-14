using Play_investe.DTO;
using Play_investe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTemplate.Services;

namespace Play_Teste
{
    public class AccountTest
    {
        private PasswordHasherService passwordHasherMock;
        private SaveUserDTO saveUserDto;
        private Bound boundMock;
        private SaveBoundDTO boundDTO;

        [SetUp]
        public void Initialize()
        {

            passwordHasherMock = new PasswordHasherService();

            saveUserDto = new SaveUserDTO
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                CPF = "12345678901",
                DateOfBirth = new DateTime(1990 - 01 - 01),
                RG = "1234567",
                DateOfIssue = new DateTime(1990 - 01 - 01),
                Password = "old_password",

            };

            boundDTO = new SaveBoundDTO
            {
                LiquidityType = 0,
                Index = "Selic",
                Percent = 5
            };
            boundMock = new(boundDTO);
        }

        [Test]
        public void CreateAccount()
        {
            // Arrange & Act
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            user.Account = account;

            //Assert
            Assert.IsNotNull(account.AccountNumber);
            Assert.AreEqual(account.Agency, "0024");
            Assert.AreEqual(account.AccountType, "Conta Corrente");
            Assert.IsFalse(account.IsWithdrawalAvailableForAll);
            Assert.NotNull(account.IdUser);
            Assert.AreEqual(user.Account.Id, account.Id);

        }

        [Test]
        public void WithdrawBalenceEnough()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            account.Balance = 400;

            //Act
            account.Withdraw(200);

            //Assert           
            Assert.AreEqual(account.Balance, 200);          

        }


        [Test]
        public void WithdrawBalenceNotEnough()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            account.Balance = 10;

            //Act & Assert
            Assert.Throws<System.InvalidOperationException>(() =>  
            {                
                account.Withdraw(200);
            });

            //Assert           
            Assert.AreNotEqual(account.Balance, 200);

        }

        [Test]
        public void WithdrawValueLessThanZero()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            account.Balance = 10;

            //Act & Assert
            Assert.Throws<System.ArgumentException>(() =>
            {
                account.Withdraw(0);
            });             

        }

        [Test]
        public void DepositValid()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            account.Balance = 100;

            //Act
            account.Deposit(10);

            //Assert
            Assert.AreEqual(account.Balance, 110);

        }

        
    
        [Test]
        public void DepositInvalid()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            account.Balance = 100;
         
            //Act & Assert
            Assert.Throws<System.ArgumentException>(() =>
            {
                    account.Withdraw(0);
            });

            //Assert
            Assert.AreEqual(account.Balance, 100);
            

        }

        [Test]
        public void GetInvestimentList()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            var dueDate = boundMock.GetDueDate(boundMock.LiquidityType);
            Investment investment = new(dueDate, 250, boundMock, account);

            //Act  
            account.Investments.Add(investment);

            //Assert
            Assert.AreEqual(account.Investments.Count, 1);

        }

        [Test]
        public void TotalInvestiment()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            Account account = new(user.Id);
            var dueDate = boundMock.GetDueDate(boundMock.LiquidityType);
            Investment investment = new(dueDate, 250, boundMock, account);

            //Act  
            account.Investments.Add(investment);

            var value = account.CalculateTotalInvestmentValue();

            //Assert
            Assert.AreEqual(value, 250);

        }

    }
}
