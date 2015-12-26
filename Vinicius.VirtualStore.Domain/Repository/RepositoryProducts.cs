using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinicius.VirtualStore.Domain.Entities;

namespace Vinicius.VirtualStore.Domain.Repository
{
    public class RepositoryProducts
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Products> Produto
        {
            get { return _context.Produtos; }
        } 
    }
}
