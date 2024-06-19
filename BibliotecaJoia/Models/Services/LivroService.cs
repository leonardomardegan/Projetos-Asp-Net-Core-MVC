using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Atualizar(LivroDto livro)
        {
            try
            {
                var objLivro = livro.ConverterParaEntidade();
                _livroRepository.Atualizar(objLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(LivroDto livro)
        {
            try
            {
                var objLivro = livro.ConverterParaEntidade();
                objLivro.Cadastrar();
                _livroRepository.Cadastrar(objLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(string id)
        {
            try
            {
                _livroRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> Listar()
        {
            try
            {
                var livrosDto = new List<LivroDto>();
                var livros = _livroRepository.Listar();
                foreach(var item in livros)
                {
                    livrosDto.Add(item.ConverterParaDto());
                }

                return livrosDto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto PesquisarPorId(string id)
        {
            try
            {
                var livro = _livroRepository.PesquisarPorId(id);
                return livro.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
