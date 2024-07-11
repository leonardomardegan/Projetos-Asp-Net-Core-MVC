using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Dtos
{
    public class EmprestimoLivroDto
    {
        public string ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
        public string LivroId { get; set; }
        public LivroDto Livro { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }
    }
}
