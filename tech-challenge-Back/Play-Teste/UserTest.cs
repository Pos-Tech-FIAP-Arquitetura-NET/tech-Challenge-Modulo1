using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using Play_investe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTemplate.Services;
using Assert = NUnit.Framework.Assert;

namespace Play_Teste
{
    public class UserTest
    {

        private PasswordHasherService passwordHasherMock;
        private SaveUserDTO saveUserDto;
        private TokenService tokenService;
        private IConfiguration config;



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

            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            tokenService = new TokenService(config);
        }

        [Test]
        public void TestUserCreation()
        {
            // Arrange
            User user = new (saveUserDto, passwordHasherMock);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(saveUserDto.Name, user.Name);
            Assert.AreEqual(saveUserDto.Email, user.Email);
            Assert.AreEqual(saveUserDto.PhoneNumber, user.PhoneNumber);
            Assert.AreEqual(saveUserDto.CPF, user.CPF);
            Assert.AreEqual(saveUserDto.DateOfBirth, user.DateOfBirth);
            Assert.AreEqual(saveUserDto.RG, user.RG);
            Assert.AreEqual(saveUserDto.DateOfIssue, user.DateOfIssue);      
            Assert.IsTrue(user.IsActived);
            Assert.IsNotNull(user.Password);
        }


        [Test]
        public void DesactiveUser()
        {
            // Arrange
            User user = new(saveUserDto, passwordHasherMock);
            var today = DateTime.Now;

            //Act
            user.DesactiveUser(user.Id);

            //Assert
            Assert.IsFalse(user.IsActived);          
            Assert.IsNotNull(user.DesactivedDate);
        }



        [Test]
        public void ChangePassword()
        {
            // Arrange
            var newPassword = "new_password";
            var oldPassword = "old_password";

            User user = new(saveUserDto, passwordHasherMock);
            //Act
            user.ChangeUserPassword(newPassword, passwordHasherMock);            

            //Assert
            Assert.IsTrue(passwordHasherMock.VerifyPassword(user.Password, newPassword));
            Assert.IsFalse(passwordHasherMock.VerifyPassword(user.Password, oldPassword));

        }

        [Test]
        public void CreateAdminUser()
        {
            //Arrange
           var saveAdminUserDto = new SaveUserDTO
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                CPF = "12345678901",
                DateOfBirth = new DateTime(1990 - 01 - 01),
                RG = "1234567",
                DateOfIssue = new DateTime(1990 - 01 - 01),
                Password = "old_password",
                Permitions = PermitionsTypes.Admin,
            };

            //Act
            User user = new(saveAdminUserDto, passwordHasherMock);

            //Assert
            Assert.AreEqual(user.Permitions, PermitionsTypes.Admin);

        }

        [Test]
        public void TestHashingPassword()
        {
            //Arrange 
            var password = "Password2024";

            //Act
            var passwordHas = passwordHasherMock.HashPassword(password);

            //Assert
            Assert.AreNotEqual(password, passwordHas);
        }

        [Test]
        public void CreateGeneralUser()
        {
             
            //Arrange & Act
            User user = new(saveUserDto, passwordHasherMock);

            //Assert
            Assert.AreEqual(user.Permitions, PermitionsTypes.General);

        }


        [Test]
        public void CreateStaffUser()
        {
            //Arrange
            var saveAdminUserDto = new SaveUserDTO
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                CPF = "12345678901",
                DateOfBirth = new DateTime(1990 - 01 - 01),
                RG = "1234567",
                DateOfIssue = new DateTime(1990 - 01 - 01),
                Password = "old_password",
                Permitions = PermitionsTypes.Staff,
            };


            //Act
            User user = new(saveAdminUserDto, passwordHasherMock);

            //Assert
            Assert.AreEqual(user.Permitions, PermitionsTypes.Staff);
        }

        [Test]
        public void NotCreateAdminUser()
        {
            //Arrange
            var saveAdminUserDto = new SaveUserDTO
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                CPF = "12345678901",
                DateOfBirth = new DateTime(1990 - 01 - 01),
                RG = "1234567",
                DateOfIssue = new DateTime(1990 - 01 - 01),
                Password = "old_password",
                Permitions = PermitionsTypes.Staff,
                Street = "Rua Principal",
                Number = "123",
                ZipCode = "12345-678",
                City = "Cidade Aleatória",
                State = "Estado Aleatório",
                Country = "País Aleatório",

        };
            //Act
            User user = new(saveAdminUserDto, passwordHasherMock);

            //Assert
            Assert.AreNotEqual(user.Permitions, PermitionsTypes.Admin);
        }


        [Test]
        public void GetUserToken()
        {
            //Arrange
            User user = new(saveUserDto, passwordHasherMock);

            //Act           
            var userToken = tokenService.GetToken(user);

            //Assert
            Assert.IsNotNull(string.IsNullOrEmpty(userToken));
            Assert.IsTrue(userToken.Length > 0);

        }

        [Test]
        public void GetUserAddres()
        {
            //Arrange
            User user = new(saveUserDto, passwordHasherMock);
            string street = "Rua Principal";
            string number = "123";
            string zipCode = "12345-678";
            string city = "Cidade Aleatória";
            string state = "Estado Aleatório";
            string country = "País Aleatório";

            //Act
            var address = new Address(street, number, zipCode, city, state, country, user.Id);
            user.Address = address;

            //Assert
            Assert.AreEqual(user.Address.Id, address.Id);
            Assert.AreEqual(user.Address.Country, country);
            Assert.AreEqual(user.Address.Number, address.Number);
            Assert.AreEqual(user.Address.ZipCode, zipCode);
            Assert.AreEqual(user.Address.City, city);
            Assert.AreEqual(user.Address.State, state);
            Assert.AreEqual(user.Address.Street, street);

        }

        [Test]
        public void SetUserAccount() 
        {
            //Arrange
            User user = new(saveUserDto, passwordHasherMock);


            //Act
            Account account = new(user.Id);
            user.Account = account;

            //Assert
            Assert.IsTrue(user.Account.Equals(account));
            Assert.NotNull(user.Account);


        }

        [Test]
        public void BasicUserConstruscor()
        {
            //Arrange & Act
            User user = new();

            //Assert
            Assert.NotNull(user);
        }
    }
}
