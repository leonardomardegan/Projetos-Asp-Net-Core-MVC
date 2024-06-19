using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> Listar();
        Cliente PesquisarPorId(string id);
        void Atualizar(Cliente cliente);
        void Excluir(string id);
    }
}
