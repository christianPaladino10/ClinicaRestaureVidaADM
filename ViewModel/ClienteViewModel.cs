using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public int? Idade { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }
        public int ClientePerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Clientes.Count() / (double)ClientePerPage));
        }
        public IEnumerable<Cliente> PaginatedClientes()
        {
            int start = (CurrentPage - 1) * ClientePerPage;
            return Clientes.OrderBy(b => b.Id).Skip(start).Take(ClientePerPage);
        }
    }
}