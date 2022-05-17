using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public string RG { get; set; }
        public int? Idade { get; set; }
        public string CPF { get; set; }
        public string Altura { get; set; }
        public int Peso { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }

        [DisplayName("Nome Conjuge")]
        public string NomeConjuge { get; set; }

        [DisplayName("Nome Pai")]
        public string NomePai { get; set; }

        [DisplayName("Nome Mãe")]
        public string NomeMae { get; set; }

        [DisplayName("Data Nascimento Mãe")]
        public DateTime? DataNascimentoMae { get; set; }

        [DisplayName("Data Nascimento Pai")]
        public DateTime? DataNascimentoPai { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
    }

    public enum TipoEstadoCivil
    {
        Male,
        Female
    }
}