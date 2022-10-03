using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.ViewModel
{
    public class ConsultaHistoricoViewModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public IEnumerable<Consulta> Consultas { get; set; }
        public int ConsultaPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Consultas.Count() / (double)ConsultaPerPage));
        }
        public IEnumerable<Consulta> PaginatedConsultas()
        {
            int start = (CurrentPage - 1) * ConsultaPerPage;
            return Consultas.OrderBy(b => b.Id).Skip(start).Take(ConsultaPerPage);
        }
    }
}