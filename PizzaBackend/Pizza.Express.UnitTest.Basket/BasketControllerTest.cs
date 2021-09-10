using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza.Express.API.Controllers;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.UnitTest.Basket
{
    [TestClass]
    public class BasketControllerTest
    {
        [TestMethod]
        public void BasketController_Constructor()
        {
            BasketController testObject = new BasketController(new Mock<IBasketHandler>().Object);
            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public async Task BasketController_GetBasket()
        {
            Mock<IBasketHandler> basketHandlerMock = new Mock<IBasketHandler>();
            basketHandlerMock.Setup(x => x.GetBasket()).Returns(Task.FromResult(new List<BasketItemViewModel>()));
            var getBasket = await basketHandlerMock.Object.GetBasket().ConfigureAwait(false);
            Assert.IsInstanceOfType(getBasket, typeof(List<BasketItemViewModel>));
        }
    }
}
