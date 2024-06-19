using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface IClienteService
    {
        void Cadastrar(ClienteDto cliente);
        List<ClienteDto> Listar();
        ClienteDto PesquisarPorId(string id);
        void Atualizar(ClienteDto cliente);
        void Excluir(string id);
    }
}
