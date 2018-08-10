using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbOrcamento
    {
        public int ICodOrcamento { get; set; }
        public int? ICodOrcamentista { get; set; }
        public int? ICodCliente { get; set; }
        public DateTime? DDataValidade { get; set; }
        public DateTime? DDataCadastro { get; set; }

        public TbClientes ICodClienteNavigation { get; set; }
        public TbFuncionarios ICodOrcamentistaNavigation { get; set; }
    }
}
