using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler;

namespace Pizza.Express.UnitTest.Basket
{
    [TestClass]
    public class BasketHandlerTest
    {
        [TestMethod]
        public void BasketHandler_Constructor()
        {
            BasketHandler testObject = new BasketHandler(new Mock<IBasketContext>().Object);
            Assert.IsNotNull(testObject);
        }
    }
}
