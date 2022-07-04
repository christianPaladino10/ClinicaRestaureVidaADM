using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.ViewModel
{
    public class ConsultaViewModel
    {
        public List<CheckBoxProcedimento> ListaCheckBoxProcedimento { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }
        public int IdCliente { get; set; }
        public int IdProfissional { get; set; }

        [DisplayName("Data Consulta")]
        public DateTime DataCriacaoConsulta { get; set; }

        [DisplayName("Profissional")]
        public string NomeProfissional { get; set; }

        [DisplayName("Cliente")]
        public string NomeCliente { get; set; }
        public int IdConsulta { get; set; }


    }

    public class CheckBoxProcedimento
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }
}