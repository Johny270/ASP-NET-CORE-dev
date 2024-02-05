using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleApp.Models;
using SimpleApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        //class FakeDataSource : IDataSource
        //{
        //    public FakeDataSource(Product[] data) => Products = data;
        //    public IEnumerable<Product> Products { get; set; }
        //}

        [Fact]
        public void IndexActionModelIsComplete()
        {
                // Arrange
            Product[] testData = new Product[]
            {
                new Product { Name = "P1", Price = 75.10M },
                new Product { Name = "P2", Price = 120M },
                new Product { Name = "P3", Price = 110M }
            };
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(testData);
            var controller = new HomeController();
            controller.dataSource = mock.Object;

            //var controller = new HomeController();
            //controller.dataSource = data;

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(testData, model, Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
