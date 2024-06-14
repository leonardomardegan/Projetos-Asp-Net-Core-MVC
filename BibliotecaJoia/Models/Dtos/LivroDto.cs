﻿using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Dtos
{
    public class LivroDto : EntidadeBase
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int StatusLivroId { get; set; }

        public LivroDto()
        {

        }

        public LivroDto(string id, string nome, string autor, string editora)
            : this(nome, autor, editora)
        {
            this.Id = id;
        }

        public LivroDto(string nome, string autor, string editora)
        {
            this.Nome = nome;
            this.Autor = autor;
            this.Editora = editora;
        }
    }
}
