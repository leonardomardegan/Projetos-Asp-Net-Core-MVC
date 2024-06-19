using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro livro);
        List<Livro> Listar();
        Livro PesquisarPorId(string id);
        void Atualizar(Livro livro);
        void Excluir(string id);
    }
}
