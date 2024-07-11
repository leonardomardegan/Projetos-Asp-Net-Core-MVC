﻿using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface IEmprestimoLivroRepository
    {
        void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro);

        void EfetuarDevolucao(EmprestimoLivro emprestimoLivro);
    }
}
