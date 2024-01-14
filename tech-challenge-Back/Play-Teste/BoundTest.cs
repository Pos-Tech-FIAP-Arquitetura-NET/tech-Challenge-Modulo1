using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTemplate.Services;

namespace Play_Teste
{
    public class BoundTest
    {
        private SaveBoundDTO boundDTO;

        [SetUp]
        public void Initialize()
        {           

            boundDTO = new SaveBoundDTO
            {
                LiquidityType = 0,
                Index = "Selic",
                Percent = 5
            };           

        }


        [Test]
        public void CreateIndexedBound()
        {
            //Arrange & Act
            Bound bound = new(boundDTO);


            //Assert
            Assert.AreEqual(bound.Type, "Indexed Bound");
        }

        [Test]
        public void CreateFixedBound()
        {
            //Arrange & Act

           var fixedBound = new SaveBoundDTO
            {
                LiquidityType = 0,
                Index = "",
                Percent = 5
            };

            Bound bound = new(fixedBound);

            //Assert
            Assert.AreEqual(bound.Type, "Fixed Bound");
        }

        [Test]
        public void CreateDueDate()
        {

            //Arrange 
            Bound bound = new(boundDTO);

            //Act
            var dueDate = bound.GetDueDate(0);

            //Assert
            Assert.IsNotNull(dueDate);
        }
    }
}
