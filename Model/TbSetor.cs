using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbSetor
    {
        public TbSetor()
        {
            TbFuncionarios = new HashSet<TbFuncionarios>();
        }

        public int ICodSetor { get; set; }
        public string SDscSetor { get; set; }
        public string SFlgAlmoxarifado { get; set; }

        public ICollection<TbFuncionarios> TbFuncionarios { get; set; }
    }
}
