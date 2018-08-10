using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbClientes
    {
        public TbClientes()
        {
            TbOrcamento = new HashSet<TbOrcamento>();
        }

        public int ICodClientes { get; set; }
        public string SNomeCliente { get; set; }
        public string Semail { get; set; }
        public string STelefone { get; set; }

        public ICollection<TbOrcamento> TbOrcamento { get; set; }
    }
}
