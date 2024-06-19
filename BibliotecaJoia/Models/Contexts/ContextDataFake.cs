using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public class ContextDataFake : IContextData
    {
        private static List<Livro> livros = new List<Livro>();

        public ContextDataFake()
        {
            //livros = new List<LivroDto>();
            InitializeData();
        }

        public void AtualizarLivro(Livro livro)
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

        public void CadastrarLivro(Livro livro)
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

        public List<Livro> ListarLivro()
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

        public Livro PesquisarLivroPorId(string id)
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
            var livro = new Livro { Nome = "Implementando Domain-Driven Design", Autor = "Vaugh Vernon", Editora = "Alta Books" };
            livros.Add(livro);

            livro = new Livro { Nome = "Domain-Driven Design", Autor = "Eric Evans", Editora = "Alta Books" };
            livros.Add(livro);

            livro = new Livro { Nome = "Redes Guia Prático", Autor = "Carlos E. Morimoto", Editora = "ASul Editores" };
            livros.Add(livro);

            livro = new Livro { Nome = "PHP Programando com Orientalção a Objetos", Autor = "Pablo Dall'Oglio", Editora = "Novatec" };
            livros.Add(livro);

            livro = new Livro { Nome = "Introdução a Programação com Python", Autor = "Nilo N. C. Menezes", Editora = "Novatec" };
            livros.Add(livro);
        }
    }
}
