using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vinicius.VirtualStore.Domain.Entities;
using Vinicius.VirtualStore.Web.Models;

namespace Vinicius.VirtualStore.UnitTest
{
    [TestClass]
    public class TestCartItems
    {
        [TestMethod]
        public void AddItemToCart()
        {
            Products products1 = new Products
            {
                ProductId = 1,
                Name = "Test Product 1"
            };

            Products products2 = new Products
            {
                ProductId = 2,
                Name = "Teste Product 2"
            };

            Cart cart = new Cart();

            cart.AddItem(products1, 2);
            cart.AddItem(products2, 3);

            CartItems[] items = cart.CartItems.ToArray();

            Assert.AreEqual(items.Length, 2);
            Assert.AreEqual(items[0].Procuts, products1);
            Assert.AreEqual(items[1].Procuts, products2);

        }

        [TestMethod]
        public void AddExistendProduct()
        {
            Products product1 = new Products
            {
                ProductId = 1,
                Name = "Product 1"
            };

            Products product2 = new Products
            {
                ProductId = 2,
                Name = "Product 2"
            };

            Cart cart = new Cart();

            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product1, 10);

            CartItems[] result = cart.CartItems
                .OrderBy(c => c.Procuts.ProductId).ToArray();

            Assert.AreEqual(result.Length, 2);

            Assert.AreEqual(result[0].Quantity, 11);
        }

        [TestMethod]
        public void RemoveFromCart()
        {
            Products product1 = new Products
            {
                ProductId = 1,
                Name = "Teste 1"
            };

            Products product2 = new Products
            {
                ProductId = 2,
                Name = "Teste 2"
            };

            Cart cart = new Cart();

            cart.AddItem(product1, 2);
            cart.RemoveItem(product1);
            cart.AddItem(product2, 3);

            CartItems[] items = cart.CartItems.ToArray();

            Assert.AreEqual(items.Length, 1);
            Assert.AreEqual(cart.CartItems.Where(p => p.Procuts.ProductId == product1.ProductId).Count(), 0);


        }

        [TestMethod]
        public void CalculatesTotal()
        {
            Products product1 = new Products
            {
                ProductId = 1,
                Name = "Test 1",
                Price = 100
            };

            Products product2 = new Products
            {
                ProductId = 2,
                Name = "Test 2",
                Price = 500
            };

            Cart cart = new Cart();

            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            var result = cart.TotalValue();

            Assert.AreEqual(result, 600);
        }

        [TestMethod]
        public void CleanCart()
        {
            Products product1 = new Products
            {
                ProductId = 1,
                Name = "Test 1"
            };

            Products product2 = new Products
            {
                ProductId = 2,
                Name = "Test 2"
            };

            Cart cart = new Cart();

            cart.AddItem(product1, 2);
            cart.CleanCart();
            cart.AddItem(product2, 3);


            Assert.AreEqual(cart.CartItems.Count(), 1);
        }

    }
}
