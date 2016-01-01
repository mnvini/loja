using System.Linq;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Entities;
using Vinicius.VirtualStore.Domain.Repository;

namespace Vinicius.VirtualStore.Web.Controllers
{

    public class CartController : Controller
    {
        private RepositoryProducts _repository;
        public RedirectToRouteResult Add(int productId, string returnUrl)
        {
           _repository = new RepositoryProducts();

            Products products = _repository.Produto.FirstOrDefault(p => p.ProductId == productId);

            if (products != null)
            {
                GetCart().AddItem(products,1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }


        public RedirectToRouteResult Remove(int productId, string returnUrl)
        {
            _repository = new RepositoryProducts();
            Products products = _repository.Produto.FirstOrDefault(p => p.ProductId == productId);

            if (products != null)
            {
                GetCart().RemoveItem(products);
            }

            return RedirectToAction("Index", new {returnUrl});

        }
    }
}