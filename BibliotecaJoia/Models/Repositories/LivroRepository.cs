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
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Livro livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Cadastrar(Livro livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public void Excluir(string id)
        {
            _contextData.ExcluirLivro(id);
        }

        public List<Livro> Listar()
        {
            return _contextData.ListarLivro();
        }

        public Livro PesquisarPorId(string id)
        {
            return _contextData.PesquisarLivroPorId(id);
        }
    }
}
