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
    public class AddressTest
    {

        private PasswordHasherService passwordHasherMock;
        private SaveUserDTO saveUserDto;
        private User userMock;
       

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

            userMock = new(saveUserDto, passwordHasherMock);
           


        }

        [Test]
        public void CreateAddress()
        {
            //Arrange 
            string street = "Rua Principal";
            string number = "123";
            string zipCode = "12345-678";
            string city = "Cidade Aleatória";
            string state = "Estado Aleatório";
            string country = "País Aleatório";

            //Act
            var address = new Address(street, number, zipCode, city,state,country, userMock.Id);
            userMock.Address = address;

            //Assert
            Assert.NotNull(address.Id);
            Assert.AreEqual(street, address.Street);
            Assert.AreEqual(number, address.Number);    
            Assert.AreEqual(zipCode, address.ZipCode);
            Assert.AreEqual(city, address.City);    
            Assert.AreEqual(state, address.State);
            Assert.AreEqual(country, address.Country);
            Assert.NotNull(address.IdUser);
           
        }



    }
}
