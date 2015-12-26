using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Repository;

namespace Vinicius.VirtualStore.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto

        private RepositoryProducts _repository;
        public ActionResult Index()
        {
            _repository = new RepositoryProducts();

            var products = _repository.Produto.OrderBy(p => p.Name);

            return View(products);
        }
    }
}