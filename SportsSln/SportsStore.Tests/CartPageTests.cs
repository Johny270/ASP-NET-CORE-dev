using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SportsStore.Models;
using SportsStore.Pages;
using System.Text.Json;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

namespace SportsStore.Tests
{
    public class CartPageTests
    {
        [Fact]
        public void Can_Load_Cart()
        {
            // Arrange
            // - Create a mock repository
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Mock<IStoreRepository> mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(m => m.Products).Returns((new Product[]
            {
                p1, p2
            }).AsQueryable<Product>());

            // - Create a cart
            Cart testCart = new Cart();
            testCart.AddItem(p1, 2);
            testCart.AddItem(p2, 1);

            // - Create a mock page context and session
            Mock<ISession> mockSession = new Mock<ISession>();
            byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(testCart));
            mockSession.Setup(c => c.TryGetValue(It.IsAny<string>(), out data));
            Mock<HttpContext> mockContext = new Mock<HttpContext>();
            mockContext.SetupGet(C => C.Session).Returns(mockSession.Object);

            // Action
            CartModel cartModel = new CartModel(mockRepo.Object)
            {
                PageContext = new PageContext(new ActionContext
                {
                    HttpContext = mockContext.Object,
                    RouteData = new RouteData(),
                    ActionDescriptor = new PageActionDescriptor()
                })
            };
            cartModel.OnGet("myUrl");

            // Assert
            Assert.Equal(2, cartModel.Cart?.Lines.Count());
            Assert.Equal("myUrl", cartModel.ReturnUrl);
        }
    }
}
