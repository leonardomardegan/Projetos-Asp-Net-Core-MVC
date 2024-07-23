using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using BibliotecaJoia.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public class ContextDataSqlServer : IContextData
    {
        #region Atributos

        private readonly SqlConnection _connection = null;
        
        #endregion

        #region Construtores

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }
        
        #endregion

        #region Contexto de Clientes

        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.CPF;
                command.Parameters.Add("@statusClienteId", SqlDbType.Int).Value = cliente.StatusCliente.GetHashCode();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirCliente(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Cliente> ListarClientes()
        {
            var clientes = new List<Cliente>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_CLIENTE);

                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();

                    var cliente = new Cliente { Id = id, Nome = nome, CPF = cpf, Email = email, Fone = fone, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(cliente.StatusClienteId);
                    clientes.Add(cliente);
                }
                adapter = null;
                dataset = null;

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente PesquisarClientePorId(string id)
        {
            try
            {
                Cliente cliente = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();

                    cliente = new Cliente { Id = codigo, Nome = nome, CPF = cpf, Email = email, Fone = fone, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(cliente.StatusClienteId);
                }
                adapter = null;
                dataset = null;

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Contexto de Livros

        public void AtualizarLivro(Livro livro)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarLivro(Livro livro)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
                command.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = livro.StatusLivro.GetHashCode();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirLivro(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Livro> ListarLivro()
        {
            var livros = new List<Livro>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);

                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();
                    var statusLivroId = colunas[4].ToString();

                    var livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora, StatusLivroId = Int32.Parse(statusLivroId) };
                    livro.StatusLivro = GerenciadorDeStatus.PesquisarStatusDoLivroPeloId(livro.StatusLivroId);
                    livros.Add(livro);
                }
                adapter = null;
                dataset = null;

                return livros;
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
                Livro livro = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    livro = new Livro { Id = codigo, Nome = nome, Autor = autor, Editora = editora };
                }
                adapter = null;
                dataset = null;

                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Contexto de Usuarios

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_USUARIO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_USUARIO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirUsuario(int id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_USUARIO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Usuario> ListarUsuarios()
        {
            var usuarios = new List<Usuario>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_USUARIO);

                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    var usuario = new Usuario { Id = id, Login = login, Senha = senha };
                    usuarios.Add(usuario);
                }
                adapter = null;
                dataset = null;

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario PesquisarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuario = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_USUARIO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    usuario = new Usuario { Id = codigo, Login = login, Senha = senha };
                }
                adapter = null;
                dataset = null;

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            try
            {
                UsuarioDto result = null;
                var query = SqlManager.GetSql(TSql.EFETUAR_LOGIN);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();

                    result = new UsuarioDto { Id = codigo, Login = login };
                }
                adapter = null;
                dataset = null;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Contexto de Emprestimo de Livros

        public void EfetuarEmprestimoLivro(EmprestimoLivro emprestimoLivro)
        {
            SqlTransaction transaction = null;

            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();

                var query = SqlManager.GetSql(TSql.EFETUAR_EMPRESTIMO_LIVRO);
                var command = new SqlCommand(query, _connection, transaction);

                command.Parameters.Add("@clienteId", SqlDbType.VarChar).Value = emprestimoLivro.ClienteId;
                command.Parameters.Add("@usuarioId", SqlDbType.Int).Value = emprestimoLivro.UsuarioId;
                command.Parameters.Add("@livroId", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                command.Parameters.Add("@dataEmprestimo", SqlDbType.DateTime).Value = emprestimoLivro.DataEmprestimo;
                command.Parameters.Add("@dataDevolucao", SqlDbType.DateTime).Value = emprestimoLivro.DataDevolucao;

                command.ExecuteNonQuery();

                var query2 = SqlManager.GetSql(TSql.ATUALIZAR_STATUS_LIVRO);
                var command2 = new SqlCommand(query2, _connection, transaction);

                command2.Parameters.Add("@id", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                command2.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = StatusLivro.EMPRESTADO.GetHashCode();

                command2.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void EfetuarDevolucaoLivro(EmprestimoLivro emprestimoLivro)
        {
            SqlTransaction transaction = null;

            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();

                var query = SqlManager.GetSql(TSql.EFETUAR_EMPRESTIMO_LIVRO);
                var command = new SqlCommand(query, _connection, transaction);

                command.Parameters.Add("@clienteId", SqlDbType.VarChar).Value = emprestimoLivro.ClienteId;
                command.Parameters.Add("@livroId", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                command.Parameters.Add("@dataDevolucaoEfetiva", SqlDbType.DateTime).Value = emprestimoLivro.DataDevolucaoEfetiva;

                command.ExecuteNonQuery();

                var query2 = SqlManager.GetSql(TSql.ATUALIZAR_STATUS_LIVRO);
                var command2 = new SqlCommand(query, _connection, transaction);

                command2.Parameters.Add("@id", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                command2.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = StatusLivro.DISPONIVEL.GetHashCode();

                command2.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public List<ConsultaEmprestimoDto> ConsultarEmprestimos()
        {
            var emprestimos = new List<ConsultaEmprestimoDto>();

            try
            {
                var query = SqlManager.GetSql(TSql.CONSULTAR_EMPRESTIMOS_LIVROS);

                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var emprestimo = new ConsultaEmprestimoDto
                    {
                        Livro = colunas[0].ToString(),
                        Autor = colunas[1].ToString(),
                        Editora = colunas[2].ToString(),
                        Cliente = colunas[3].ToString(),
                        CPF = colunas[4].ToString(),
                        DataEmprestimo = DateTime.Parse(colunas[5].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucao = DateTime.Parse(colunas[6].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucaoEfetiva = colunas[7].ToString(),
                        StatusLivro = colunas[8].ToString(),
                        LoginBibliotecario = colunas[9].ToString()
                    };

                    emprestimos.Add(emprestimo);
                }
                adapter = null;
                dataset = null;

                return emprestimos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ConsultaEmprestimoDto PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
            ConsultaEmprestimoDto emprestimo = null;

            try
            {
                var query = SqlManager.GetSql(TSql.PESQUISAR_EMPRESTIMO_LIVROS);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@nomeLivro", SqlDbType.VarChar).Value = nomeLivro;
                command.Parameters.Add("@nomeCliente", SqlDbType.VarChar).Value = nomeCliente;
                command.Parameters.Add("@dataEmprestimo", SqlDbType.DateTime).Value = dataEmprestimo;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    emprestimo = new ConsultaEmprestimoDto
                    {
                        Livro = colunas[0].ToString(),
                        Autor = colunas[1].ToString(),
                        Editora = colunas[2].ToString(),
                        Cliente = colunas[3].ToString(),
                        CPF = colunas[4].ToString(),
                        DataEmprestimo = DateTime.Parse(colunas[5].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucao = DateTime.Parse(colunas[6].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucaoEfetiva = colunas[7].ToString(),
                        StatusLivro = colunas[8].ToString(),
                        LoginBibliotecario = colunas[9].ToString()
                    };
                }
                adapter = null;
                dataset = null;

                return emprestimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
