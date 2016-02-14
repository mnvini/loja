using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Repository;

namespace Vinicius.VirtualStore.Web.Areas.Admin.Controllers
{
    public class ProdutoController : Controller
    {
        private RepositoryProducts _repositorio;

        // GET: Admin/Produto
        public ActionResult Index()
        {
            _repositorio = new RepositoryProducts();
            var produtos = _repositorio.Produto;
            return View(produtos);
        }

        public ViewResult Edit(int ProductId)
        {
            _repositorio = new RepositoryProducts();
            var produto = _repositorio.Produto.FirstOrDefault(p => p.ProductId == ProductId);
            return View(produto);
        }
    }
}