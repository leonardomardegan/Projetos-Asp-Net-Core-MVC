using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        public void AtualizarLivro(LivroDto livro)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(LivroDto livro)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(string id)
        {
            throw new NotImplementedException();
        }

        public List<LivroDto> ListarLivro()
        {
            throw new NotImplementedException();
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
