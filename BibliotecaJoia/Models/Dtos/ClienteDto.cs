﻿using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Dtos
{
    public class ClienteDto : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string StatusClienteId { get; set; }
        public string Status { get; set; }

        public Cliente ConverterParaEntidade()
        {
            return new Cliente
            {
                Id = this.Id,
                Nome = this.Nome,
                Email = this.Email,
                Fone = this.Fone,
                CPF = this.CPF,
                StatusClienteId = !string.IsNullOrEmpty(StatusClienteId) ? Int32.Parse(StatusClienteId) : StatusCliente.ATIVO.GetHashCode(),
                StatusCliente = !string.IsNullOrEmpty(StatusClienteId) ? GerenciadorDeStatus.PesquisarStatusDoClientePeloId(Int32.Parse(StatusClienteId)) : StatusCliente.ATIVO
            };
        }
    }
}
