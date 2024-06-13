using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public enum StatusLivro
    {
        DISPONIVEL = 1,
        EMPRESTIMO = 2,
        ATRASO_DEVOLUCAO = 3,
        USO_LOCAL = 4
    }
}
