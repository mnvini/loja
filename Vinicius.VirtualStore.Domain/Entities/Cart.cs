using System.Collections.Generic;
using System.Linq;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartItems> _cartitems = new List<CartItems>(); 

        public void AddItem(Products products, int quantity)
        {
            CartItems cart = _cartitems.FirstOrDefault(p => p.Products.ProductId == products.ProductId);

            if (cart == null)
            {
                _cartitems.Add(new CartItems
                {
                    Products = products,
                    Quantity = quantity
                });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }

        public void RemoveItem(Products products)
        {
            _cartitems.RemoveAll(l => l.Products.ProductId == products.ProductId);
        }

        public decimal TotalValue()
        {
           return _cartitems.Sum(p => p.Products.Price*p.Quantity);
        }

        public void CleanCart()
        {
            _cartitems.Clear();
        }

        public IEnumerable<CartItems> CartItems
        {
            get { return _cartitems; }
        } 
    }


    public class CartItems
    {
        public Products Products { get; set; }

        public int Quantity { get; set; }
    }
}
