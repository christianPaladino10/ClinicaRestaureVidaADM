using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.ViewModel
{
    public class ProfissionalSegmentoViewModel
    {
        public int ProfissionalId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<CheckBoxSegmento> ListaCheckBoxSegmento { get; set; }

        public class CheckBoxSegmento
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Checked { get; set; }
        }
    }
}