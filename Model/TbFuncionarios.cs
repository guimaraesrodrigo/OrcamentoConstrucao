using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbFuncionarios
    {
        public TbFuncionarios()
        {
            TbOrcamento = new HashSet<TbOrcamento>();
        }

        public int ICodFuncionario { get; set; }
        public string SNomeFuncionario { get; set; }
        public int? ICodSetor { get; set; }

        public TbSetor ICodSetorNavigation { get; set; }
        public ICollection<TbOrcamento> TbOrcamento { get; set; }
    }
}
