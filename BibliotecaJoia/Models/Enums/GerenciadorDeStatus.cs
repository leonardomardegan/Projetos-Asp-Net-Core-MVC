using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Enums
{
    public class GerenciadorDeStatus
    {
        private static List<StatusLivro> statusLivroList = new List<StatusLivro>
        {
            StatusLivro.DISPONIVEL,
            StatusLivro.EMPRESTADO,
            StatusLivro.ATRASO_DEVOLUCAO,
            StatusLivro.USO_LOCAL
        };

        public static StatusLivro PesquisarStatusDoLivroPeloId(int id)
        {
            var status = statusLivroList.FirstOrDefault(p => p.GetHashCode().Equals(id));
            return status;
        }

        public static StatusLivro PesquisarStatusDoLivroPeloNome(string nome)
        {
            var nomePesquisa = nome.ToUpper().Replace(" ", "_");
            var status = statusLivroList.FirstOrDefault(p => p.ToString().Equals(nomePesquisa));
            return status;
        }
    }
}
