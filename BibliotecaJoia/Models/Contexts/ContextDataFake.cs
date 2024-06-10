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
            var livro = new LivroDto("Implementando Domain-Driven Design", "Vaugh Vernon", "Alta Books");
            livros.Add(livro);

            livro = new LivroDto("Domain-Driven Design", "Eric Evans", "Alta Books");
            livros.Add(livro);

            livro = new LivroDto("Redes Guia Prático", "Carlos E. Morimoto", "ASul Editores");
            livros.Add(livro);

            livro = new LivroDto("PHP Programando com Orientalção a Objetos", "Pablo Dall'Oglio", "Novatec");
            livros.Add(livro);

            livro = new LivroDto("Introdução a Programação com Python", "Nilo N. C. Menezes", "Novatec");
            livros.Add(livro);
        }
    }
}
