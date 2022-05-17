using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        public int SegmentoId { get; set; }

    }
}