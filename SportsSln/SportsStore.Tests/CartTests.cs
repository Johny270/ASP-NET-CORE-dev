using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Items() // - Test whether a new line is created if a product doesn't already exist in the cart
        {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - Create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert 
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[0].Product);


        }
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines() // - Increment the quantity of the CartLine if product's already in cart
        {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - Create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = (target.Lines ?? new())
                .OrderBy(c => c.Product.ProductID).ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }
        [Fact]
        public void Can_Remove_Item() // - Remove line/product from the cart.
        {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            // Arrange - Create a new cart
            Cart target = new Cart();

            // Arrange - Add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.Empty(target.Lines.Where(c => c.Product == p2));
            Assert.Equal(2, target.Lines.Count());
        }
        [Fact]
        public void Calculate_Cart_Total()
        {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - Create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.Equal(450M, result);
        }
        [Fact]
        public void Can_Clear_Contents() // - reset Cart
        {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // - Arrange - Create a new Cart
            Cart target = new Cart();

            // Arrange - add some items
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            // Act - reset the cart
            target.clear();

            // Assert
            Assert.Empty(target.Lines);
        }
    }
}
