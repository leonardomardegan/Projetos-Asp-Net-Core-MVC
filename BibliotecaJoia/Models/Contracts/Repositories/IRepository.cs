using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface IRepository<T, Y>
    {
        void Cadastrar(T entidade);
        List<T> Listar();
        T PesquisarPorId(Y id);
        void Atualizar(T entidade);
        void Excluir(Y id);
    }
}
