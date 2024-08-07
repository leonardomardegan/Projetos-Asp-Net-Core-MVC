﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Enums
{
    public enum TSql
    {
        CADASTRAR_LIVRO,
        LISTAR_LIVRO,
        PESQUISAR_LIVRO,
        ATUALIZAR_LIVRO,
        EXCLUIR_LIVRO,

        CADASTRAR_CLIENTE,
        LISTAR_CLIENTE,
        PESQUISAR_CLIENTE,
        ATUALIZAR_CLIENTE,
        EXCLUIR_CLIENTE,

        CADASTRAR_USUARIO,
        LISTAR_USUARIO,
        PESQUISAR_USUARIO,
        ATUALIZAR_USUARIO,
        EXCLUIR_USUARIO,
        EFETUAR_LOGIN,

        EFETUAR_EMPRESTIMO_LIVRO,
        ATUALIZAR_STATUS_LIVRO,
        EFETUAR_DEVOLUCAO_LIVRO,
        CONSULTAR_EMPRESTIMOS_LIVROS,
        PESQUISAR_EMPRESTIMO_LIVROS,
        ATUALIZAR_STATUS_EMPRESTIMOS_LIVROS
    }
}
