using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIOrcamento.Model
{
    [Table("TbProdutos")]
    public partial class TbProdutos
    {
        public int ICodProduto { get; set; }
        public string SDscProduto { get; set; }
        public string SDscCor { get; set; }
        public string SDscTamanho { get; set; }
        public decimal? NPrecoProduto { get; set; }
    }
}
