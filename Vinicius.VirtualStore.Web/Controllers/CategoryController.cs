using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vinicius.VirtualStore.Domain.Repository;

namespace Vinicius.VirtualStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private RepositoryProducts _repository;

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            _repository = new RepositoryProducts();

            IEnumerable<string> categories = _repository.Produto
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categories);
        }
    }
}