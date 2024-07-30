using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class EmprestimoLivroService : IEmprestimoLivroService
    {
        private readonly IEmprestimoLivroRepository _emprestimoLivroRepository;

        public EmprestimoLivroService(IEmprestimoLivroRepository emprestimoLivroRepository)
        {
            _emprestimoLivroRepository = emprestimoLivroRepository;
        }

        public void EfetuarDevolucao(int emprestimoId, string livroId)
        {
            try
            {
                _emprestimoLivroRepository.EfetuarDevolucao(emprestimoId, livroId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EfetuarEmprestimo(EmprestimoLivroDto emprestimoLivro)
        {
            try
            {
                var entidade = emprestimoLivro.ConverterParaEntidade();
                entidade.RealizarEmprestimo();
                _emprestimoLivroRepository.EfetuarEmprestimo(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ConsultaEmprestimoDto> ConsultarEmprestimos()
        {
            return _emprestimoLivroRepository.ConsultarEmprestimos();
        }

        public ConsultaEmprestimoDto PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
            return _emprestimoLivroRepository.PesquisarEmprestimo(nomeLivro, nomeCliente, dataEmprestimo);
        }

        public void AtualizarStatusEmprestimoLivros()
        {
            _emprestimoLivroRepository.AtualizarStatusEmprestimoLivros();
        }
    }
}
