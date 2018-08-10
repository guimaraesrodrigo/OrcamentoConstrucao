using System;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public partial class TbConfiguracao
    {
        public int ICodConfiguracao { get; set; }
        public string SEnderecoEmail { get; set; }
        public string SSenhaEmail { get; set; }
        public string SServidorSmtp { get; set; }
        public int? IPortaSmtp { get; set; }
        public string SFlgUsaSsl { get; set; }
        public string SFlgUsaTls { get; set; }
    }
}
