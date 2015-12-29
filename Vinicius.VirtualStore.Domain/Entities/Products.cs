using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Vinicius.VirtualStore.Domain.Entities
{
    [Table("Produtos")]
    public class Products
    {
        [Key]
        [Column("ProdutoId")]
        public int ProductId{ get; set; }

        [Column("Nome")]
        public string Name { get; set; }

        [Column("Descricao")]
        public string ProductDescription { get; set; }

        [Column("Preco")]
        public decimal Price { get; set; }

        [Column("Categoria")]
        public string Category { get; set; }


    }
}
