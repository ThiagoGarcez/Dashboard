using ImagineArte.Dominio.DTO;
using ImagineArte.Dominio.Entidades;
using ImagineArte.Repositorio.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Aplicacao.Produtos
{
    public class MarcaAplicacao
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaAplicacao(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public RespostaPadraoDTO Adicionar(MarcaDTO entidade)
        {
            var marca = new Marca()
            {
                Nome = entidade.Nome,
                UrlLogoMarca = entidade.UrlLogomarca
            };

            _marcaRepositorio.Adicionar(marca);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Marca adicionada com sucesso!"
            };
        }

        public RespostaPadraoDTO Atualizar(MarcaDTO entidade)
        {
            var marca = _marcaRepositorio.ObterPorId(entidade.Id);
            if (marca == null)
                return new RespostaPadraoDTO(false, "Marca não encontrada");

            marca.Nome = entidade.Nome;
            marca.UrlLogoMarca = entidade.UrlLogomarca;
            _marcaRepositorio.Atualizar(marca);

            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Marca atualizada com sucesso!"
            };
        }

        public RespostaPadraoDTO Remover(long marcaId)
        {
            var marca = _marcaRepositorio.ObterPorId(marcaId);
            if (marca == null)
                return new RespostaPadraoDTO(false, "Marca não encontrada");

            _marcaRepositorio.Remover(marca);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Marca removida com sucesso!"
            };
        }

        public MarcaDTO ObterMarca(long marcaId)
        {
            var marca = _marcaRepositorio.ObterPorId(marcaId);
            if (marca == null)
                throw new Exception("Marca nao encontrada");

            return ToDTO(marca);
        }

        public IEnumerable<MarcaDTO> ObterTodasMarcas()
        {
            var marcas = _marcaRepositorio.ObterTodas();
            if (marcas == null || !marcas.Any())
                return new List<MarcaDTO>();

            return marcas.Select(marca => ToDTO(marca))
                           .ToList();
        }

        private static MarcaDTO ToDTO(Marca produto)
        {
            return new MarcaDTO()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                UrlLogomarca = produto.UrlLogoMarca
            };
        }
    }
}
