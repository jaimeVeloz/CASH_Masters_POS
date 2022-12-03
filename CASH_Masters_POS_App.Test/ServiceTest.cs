using System.Transactions;

namespace CASH_Masters_POS_App.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void validIntNumber_Letters_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validIntNumber("xyz");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void validIntNumber_DecimalNumber_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validIntNumber("5.25");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void validIntNumber_EmptyString_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validIntNumber("");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void validIntNumber_IntNumber_ReturnTrue()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validIntNumber("5");
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void validDecimalNumber_Letters_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validDecimalNumber("xyz");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void validDecimalNumber_IntNumber_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validDecimalNumber("5");
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void validDecimalNumber_EmptyString_ReturnFalse()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validDecimalNumber("");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void validDecimalNumber_DecimalNumber_ReturnTrue()
        {
            //Arrange
            Service service = new();
            //Act
            var result = service.validDecimalNumber("5.55");
            //Assert
            Assert.AreEqual(true, result);
        }
    }
}