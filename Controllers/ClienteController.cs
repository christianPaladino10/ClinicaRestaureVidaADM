using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository _repository;

        // GET: Cliente
        [HttpGet]
        public ActionResult Index()
        {
            _repository = new ClienteRepository();

            var clientes = _repository.BuscarTodos();
            return View(clientes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //POST: Cliente
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            _repository = new ClienteRepository();

            _repository.Adicionar(cliente);
            return RedirectToAction("Index");
        }


        [HttpGet] //GET (pegar)
        public ActionResult Edit(int id)
        {
            _repository = new ClienteRepository();
            var clienteEscolhido = _repository.Buscar(id);

            if (clienteEscolhido.DataNascimento == DateTime.MinValue)
                clienteEscolhido.DataNascimento = null;

            if (clienteEscolhido.DataNascimentoMae == DateTime.MinValue)
                clienteEscolhido.DataNascimentoMae = null;

            if (clienteEscolhido.DataNascimentoPai == DateTime.MinValue)
                clienteEscolhido.DataNascimentoPai = null;

            return View(clienteEscolhido);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarCliente(Cliente cliente)
        {
            _repository = new ClienteRepository();
            _repository.Alterar(cliente);

            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Delete(int id)
        {
            _repository = new ClienteRepository();
            _repository.Deletar(id);
            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Details(int id)
        {
            _repository = new ClienteRepository();
            var clienteEscolhido = _repository.Buscar(id);
            return View(clienteEscolhido);
        }

    }
}