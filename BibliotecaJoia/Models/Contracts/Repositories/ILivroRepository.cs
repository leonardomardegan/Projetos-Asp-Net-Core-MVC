using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(LivroDto livro);

        List<LivroDto> Listar();
    }
}
