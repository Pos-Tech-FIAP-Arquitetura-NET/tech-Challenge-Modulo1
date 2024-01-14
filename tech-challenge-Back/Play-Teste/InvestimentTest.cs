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
    public class InvestimentTest
    {
        private PasswordHasherService passwordHasherMock;
        private SaveUserDTO saveUserDto;
        private Account accountMock;
        private User userMock;
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

            userMock = new(saveUserDto, passwordHasherMock);
            accountMock = new(userMock.Id);
            boundMock = new(boundDTO);

        }

        [Test]
        public void CreateInvestiment()
        {
            // Arrange
           var dueDate = boundMock.GetDueDate(boundMock.LiquidityType);             

            //Act
            Investment investment = new(dueDate, 250, boundMock, accountMock);

            //Assert           
            Assert.AreEqual(investment.DueDate, dueDate);
            Assert.NotNull(investment.Id);

        }
    }
}
