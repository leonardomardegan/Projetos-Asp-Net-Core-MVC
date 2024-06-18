using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public class ContextDataFake : IContextData
    {
        private static List<LivroDto> livros;

        public ContextDataFake()
        {
            livros = new List<LivroDto>();
            InitializeData();
        }

        public void AtualizarLivro(LivroDto livro)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(livro.Id);
                livros.Remove(objPesquisa);

                objPesquisa.Nome = livro.Nome;
                objPesquisa.Editora = livro.Editora;
                objPesquisa.Autor = livro.Autor;

                CadastrarLivro(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                livros.Add(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                livros.Remove(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> ListarLivro()
        {
            try
            {
                return livros
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeData()
        {
            var livro = new LivroDto { Nome = "Implementando Domain-Driven Design", Autor = "Vaugh Vernon", Editora = "Alta Books" };
            livros.Add(livro);

            livro = new LivroDto { Nome = "Domain-Driven Design", Autor = "Eric Evans", Editora = "Alta Books" };
            livros.Add(livro);

            livro = new LivroDto { Nome = "Redes Guia Prático", Autor = "Carlos E. Morimoto", Editora = "ASul Editores" };
            livros.Add(livro);

            livro = new LivroDto { Nome = "PHP Programando com Orientalção a Objetos", Autor = "Pablo Dall'Oglio", Editora = "Novatec" };
            livros.Add(livro);

            livro = new LivroDto { Nome = "Introdução a Programação com Python", Autor = "Nilo N. C. Menezes", Editora = "Novatec" };
            livros.Add(livro);
        }
    }
}
