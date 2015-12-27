using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Repository;
using Vinicius.VirtualStore.Web.Models;

namespace Vinicius.VirtualStore.Web.Controllers
{
    public class ShowcaseController : Controller
    {

        private RepositoryProducts _repository;
        public int ProductsPerPage = 8;

        public ViewResult ProductsList(int page = 1)
        {
            _repository = new RepositoryProducts();
 
            ProductsViewModel model = new ProductsViewModel
            {
                Products = _repository.Produto
                .OrderBy(p => p.ProductDescription)
                .Skip((page - 1) * ProductsPerPage)
                .Take(ProductsPerPage),

                Pagination = new Pagination
                {
                    CurrentPage = page,
                    ItemsPerPage = ProductsPerPage,
                    TotalItems = _repository.Produto.Count()
                }
                
            };

            return View(model);
        }
    }
}