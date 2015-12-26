﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class Produtos
    {
        public int ProdutoId{ get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }

    }
}
