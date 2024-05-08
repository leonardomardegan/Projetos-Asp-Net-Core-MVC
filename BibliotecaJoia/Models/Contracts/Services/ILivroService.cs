﻿using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface ILivroService
    {
        void Cadastrar(LivroDto livro);

        List<LivroDto> Listar();
    }
}
