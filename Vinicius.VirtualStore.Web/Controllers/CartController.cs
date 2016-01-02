using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Entities;
using Vinicius.VirtualStore.Domain.Repository;
using Vinicius.VirtualStore.Web.Models;

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

        public ViewResult Index(string returnurl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resume()
        {
            Cart cart = GetCart();
            return PartialView(cart);
        }

        public ViewResult CloseOrder()
        {
            return View(new Order());
        }
        [HttpPost]
        public ViewResult CloseOrder(Order order)
        {
            Cart cart = GetCart();

            ConfigEmails email = new ConfigEmails
            {
                WriteFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteFile"] ?? "false")
            };
            
            EmailOrder emailOrder = new EmailOrder(email);

            if (!cart.CartItems.Any())
            {
                ModelState.AddModelError("","Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                emailOrder.ProcessOrder(cart, order);
                cart.CleanCart();
                return View("OrderCompleted");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult OrderCompleted()
        {
            return View();
        }
    }
}