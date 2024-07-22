using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class EmprestimoLivroRepository : IEmprestimoLivroRepository
    {
        private readonly IContextData _contextData;

        public EmprestimoLivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public List<ConsultaEmprestimoDto> ConsultarEmprestimos()
        {
            return _contextData.ConsultarEmprestimos();
        }

        public void EfetuarDevolucao(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarDevolucaoLivro(emprestimoLivro);
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarEmprestimoLivro(emprestimoLivro);
        }
    }
}
