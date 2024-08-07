﻿using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Dtos
{
    public class EmprestimoLivroDto
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
        public string LivroId { get; set; }
        public LivroDto Livro { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }

        public EmprestimoLivro ConverterParaEntidade()
        {
            return new EmprestimoLivro
            {
                ClienteId = this.ClienteId,
                Cliente = this.Cliente.ConverterParaEntidade(),
                LivroId = this.LivroId,
                Livro = this.Livro.ConverterParaEntidade(),
                UsuarioId = this.UsuarioId,
                Usuario = this.Usuario.ConverterParaEntidade(),
                DataEmprestimo = this.DataEmprestimo,
                DataDevolucao = this.DataDevolucao,
                DataDevolucaoEfetiva = this.DataDevolucaoEfetiva
            };
        }
    }
}
