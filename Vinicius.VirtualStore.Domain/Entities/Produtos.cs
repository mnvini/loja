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
    
    public class Produtos
    {
        [Key]
        [Column("ProdutoId")]
        public int ProductId{ get; set; }

        [Column("ProdutoDescricaoResumida")]
        public string Name { get; set; }

        [Column("ProdutoDescricao")]
        public string ProductDescription { get; set; }

        [Column("Preco")]
        public decimal Price { get; set; }


    }
}
