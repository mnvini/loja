using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinicius.VirtualStore.Domain.Entities;

namespace Vinicius.VirtualStore.Web.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Products> Products { get; set; }

        public Pagination Pagination { get; set; }

        public String CurrentCategory { get; set; }  
    }
}