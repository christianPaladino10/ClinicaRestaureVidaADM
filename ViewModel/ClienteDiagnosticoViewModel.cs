using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.ViewModel
{
    public class ClienteDiagnosticoViewModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public bool TemDiagnostico { get; set; }
    }
}