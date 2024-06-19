using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Contexts
{
    public interface IContextData
    {
        void CadastrarLivro(Livro livro);
        List<Livro> ListarLivro();
        Livro PesquisarLivroPorId(string id);
        void AtualizarLivro(Livro livro);
        void ExcluirLivro(string id);
    }
}
