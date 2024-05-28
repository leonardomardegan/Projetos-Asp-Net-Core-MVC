using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Contexts
{
    public interface IContextData
    {
        void CadastrarLivro(LivroDto livro);
        List<LivroDto> ListarLivro();
        LivroDto PesquisarLivroPorId(string id);
        void AtualizarLivro(LivroDto livro);
        void ExcluirLivro(string id);
    }
}
