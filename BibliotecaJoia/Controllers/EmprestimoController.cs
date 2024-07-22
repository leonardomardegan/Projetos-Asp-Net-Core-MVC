﻿using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoLivroService _emprestimoService;
        private readonly IClienteService _clienteService;
        private readonly ILivroService _livroService;

        public EmprestimoController(
            IEmprestimoLivroService emprestimoService, 
            IClienteService clienteService,
            ILivroService livroService)
        {
            _emprestimoService = emprestimoService;
            _clienteService = clienteService;
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            try
            {
                var emprestimos = _emprestimoService.ConsultarEmprestimos();
                return View(emprestimos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EfetuarEmprestimo([Bind("Cliente, Livro")] EmprestimoDto emprestimo)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.Session.GetString("_UserId"));
                string login = HttpContext.Session.GetString("_Login");

                EmprestimoLivroDto entidade = new EmprestimoLivroDto();

                entidade.Cliente = PesquisarCliente(emprestimo.Cliente);
                entidade.ClienteId = entidade.Cliente.Id;

                entidade.Livro = PesquisarLivro(emprestimo.Livro);
                entidade.LivroId = entidade.Livro.Id;

                entidade.UsuarioId = userId;
                entidade.Usuario = new UsuarioDto { Id = userId, Login = login };

                _emprestimoService.EfetuarEmprestimo(entidade);

                return RedirectToAction("Consulta");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ClienteDto PesquisarCliente(string nome)
        {
            var cliente = _clienteService.Listar()
                .Where(p => p.Nome.Equals(nome)).FirstOrDefault();
            return cliente;
        }

        public LivroDto PesquisarLivro(string nome)
        {
            var livro = _livroService.Listar()
                .Where(p => p.Nome.Equals(nome)).FirstOrDefault();
            return livro;
        }

        public IActionResult PesquisarClientes(string term)
        {
            var clientes = _clienteService.Listar();
            var clientesAtivos = clientes.Where(p => p.StatusClienteId.Equals("1")).ToList();
            var listaNomeClientes = clientesAtivos.Select(p => p.Nome).ToList();
            var filtro = listaNomeClientes.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Json(filtro);
        }

        public IActionResult PesquisarLivros(string term)
        {
            var livros = _livroService.Listar();
            var livrosDisponiveis = livros.Where(p => p.StatusLivroId == 1).ToList();
            var listaLivros = livrosDisponiveis.Select(p => p.Nome).ToList();
            var filtro = listaLivros.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Json(filtro);
        }
    }
}
