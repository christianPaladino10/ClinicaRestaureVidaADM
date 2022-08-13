using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Models
{
    public class ProcedimentoConsulta
    {
        public int IdProcedimento { get; set; }
        public int IdConsulta { get; set; }
        public int IdCliente { get; set; }
    }
}