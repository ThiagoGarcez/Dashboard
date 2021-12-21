using ImagineArte.Dominio.DTO;
using ImagineArte.Dominio.Entidades;
using ImagineArte.Repositorio.Organizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Aplicacao.Organizacao
{
    public class DepartamentoAplicacao
    {
        private readonly IDepartamentoRepositorio _departamentoRepositorio;

        public DepartamentoAplicacao(IDepartamentoRepositorio departamentoRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
        }

        public RespostaPadraoDTO Adicionar(DepartamentoDTO entidade)
        {
            var departamento = new Departamento()
            {
                Nome = entidade.Nome,
            };

            _departamentoRepositorio.Adicionar(departamento);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Departamento adicionado com sucesso!"
            };
        }

        public RespostaPadraoDTO Atualizar(DepartamentoDTO entidade)
        {
            var departamento = ObterPorId(entidade.Id);
            departamento.Nome = entidade.Nome;
            _departamentoRepositorio.Atualizar(departamento);

            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Departamento atualizado com sucesso!"
            };
        }

        public RespostaPadraoDTO Remover(long departamentoId)
        {
            var departamento = ObterPorId(departamentoId);

            _departamentoRepositorio.Remover(departamento);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Departamento removido com sucesso!"
            };
        }

        public DepartamentoDTO ObterDepartamento(long departamentoId)
        {
            var departamento = ObterPorId(departamentoId);
            return ToDTO(departamento);
        }

        public IEnumerable<DepartamentoDTO> ObterTodosDepartamento()
        {
            var departamentos = _departamentoRepositorio.ObterTodos();
            if (departamentos == null || !departamentos.Any())
                return new List<DepartamentoDTO>();

            return departamentos.Select(departamento => ToDTO(departamento))
                                .ToList();
        }

        private static DepartamentoDTO ToDTO(Departamento departamento)
        {
            return new DepartamentoDTO()
            {
                Id = departamento.Id,
                Nome = departamento.Nome,
            };
        }

        private Departamento ObterPorId(long departamentoId)
        {
            var departamento = _departamentoRepositorio.ObterPorId(departamentoId);
            if (departamento == null)
                throw new Exception("Departamento não encontrado");

            return departamento;
        }
    }
}
