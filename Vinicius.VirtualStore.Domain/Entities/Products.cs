using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;

namespace Vinicius.VirtualStore.Domain.Entities
{
    [Table("Produtos")]
    public class Products
    {
        [Key]
        [Column("ProdutoId")]
        [HiddenInput(DisplayValue = false)]
        public int ProductId{ get; set; }

        [Column("Nome")]
        public string Name { get; set; }

        [Column("Descricao")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [Column("Preco")]
        public decimal Price { get; set; }

        [Column("Categoria")]
        public string Category { get; set; }


    }
}
