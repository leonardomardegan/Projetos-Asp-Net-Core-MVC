using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public void Cadastrar(LivroDto livro)
        {
            ContextDataFake.Livros.Add(livro);
        }

        public List<LivroDto> Listar()
        {
            var livros = ContextDataFake.Livros;
            return livros
                    .OrderBy(p => p.Nome)
                    .ToList();
        }
    }
}
