using System.Collections.Generic;
using System.Linq;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartItems> _cartitems = new List<CartItems>(); 

        public void AddItem(Products products, int quantity)
        {
            CartItems cart = _cartitems.FirstOrDefault(p => p.Procuts.ProductId == products.ProductId);

            if (cart == null)
            {
                _cartitems.Add(new CartItems
                {
                    Procuts = products,
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
            _cartitems.RemoveAll(l => l.Procuts.ProductId == products.ProductId);
        }

        public decimal TotalValue()
        {
           return _cartitems.Sum(p => p.Procuts.Price*p.Quantity);
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
        public Products Procuts { get; set; }

        public int Quantity { get; set; }
    }
}
