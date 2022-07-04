using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Observacao { get; set; }
        public int IdCliente { get; set; }
        public int ProfissionalId { get; set; }
    }
}