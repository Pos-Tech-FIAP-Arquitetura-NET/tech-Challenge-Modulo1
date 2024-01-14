using Play_investe.DTO;
using Play_investe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserTemplate.Services;

namespace Play_Teste
{
    public class TransacktionTest
    {

        private PasswordHasherService passwordHasherMock;
        private SaveUserDTO saveUserDto;
        private SaveUserDTO saveUserDto2;
        private Account accountMock;
        private Account accountMock2;
        private User userMock;
        private User userMock2;
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

            saveUserDto2 = new SaveUserDTO
            {
                Name = "Jane Doe",
                Email = "jane.doe@example.com",
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

            userMock = new(saveUserDto, passwordHasherMock);
            userMock2 = new(saveUserDto, passwordHasherMock);
            accountMock = new(userMock.Id);
            accountMock2 = new(userMock2.Id);
            boundMock = new(boundDTO);

        }

        [Test]
        public void CreateTransaction()
        {
            //Arrange
            var date = DateTime.Now;
            var sourceAccountId = accountMock.Id;
            var destinationAccountId = accountMock2.Id;

            //Act
            TransactionsBank bankTransactions = new(date, 250, "Pix", sourceAccountId ,destinationAccountId);


            //Assert
            Assert.NotNull(bankTransactions.Id);
            Assert.AreEqual(sourceAccountId, bankTransactions.SourceAccountId);
            Assert.AreEqual(destinationAccountId, bankTransactions.DestinationAccountId);

        }

        [Test]
        public void GetTransactions()
        {
            //Arrange
            var date = DateTime.Now;           
            var destinationAccountId = accountMock2.Id;
            Account account = new(userMock.Id);

            //Act
            TransactionsBank bankTransactions = new(date, 250, "Pix", account.Id, destinationAccountId);
            account.TransactionsBank.Add(bankTransactions);

            //Assert
            Assert.AreEqual(account.TransactionsBank.Count, 1);

        }


    }
}
