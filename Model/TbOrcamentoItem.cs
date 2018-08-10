using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbOrcamentoItem
    {
        public int ICodOrcamento { get; set; }
        public int ICodProduto { get; set; }
        public decimal? NQuantidade { get; set; }
        public decimal? NPreco { get; set; }
        public decimal? NPrecoTotal { get; set; }
    }
}
