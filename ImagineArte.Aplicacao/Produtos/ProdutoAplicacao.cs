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
    public class ProdutoAplicacao
    {
        private readonly IProdutoRepositorio _repositorioProduto;

        public ProdutoAplicacao(IProdutoRepositorio repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public RespostaPadraoDTO Adicionar(ProdutoDTO entidade)
        {
            var produto = new Produto()
            {
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Ativo = entidade.Ativo,
                Altura = entidade.Altura,
                Comprimento = entidade.Comprimento,
                Largura = entidade.Largura,
                MarcaId = entidade.MarcaId,
                Peso = entidade.Peso,
                SubcategoriaId = entidade.SubcategoriaId
            };

            _repositorioProduto.Adicionar(produto);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Produto adicionado com sucesso!"
            };
        }

        public RespostaPadraoDTO Atualizar(ProdutoDTO entidade)
        {
            var produto = _repositorioProduto.ObterPorId(entidade.Id);
            if (produto == null)
                return new RespostaPadraoDTO(false, "Produto não encontrado");

            produto.Nome = entidade.Nome;
            produto.Descricao = entidade.Descricao;
            produto.Ativo = entidade.Ativo;
            produto.Altura = entidade.Altura;
            produto.Comprimento = entidade.Comprimento;
            produto.Largura = entidade.Largura;
            produto.MarcaId = entidade.MarcaId;
            produto.Peso = entidade.Peso;
            produto.SubcategoriaId = entidade.SubcategoriaId;

            _repositorioProduto.Atualizar(produto);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Produto atualizado com sucesso!"
            };
        }

        public RespostaPadraoDTO Remover(long produtoId)
        {
            var produto = _repositorioProduto.ObterPorId(produtoId);
            if (produto == null)
                return new RespostaPadraoDTO(false, "Produto não encontrado");

            _repositorioProduto.Remover(produto);
            return new RespostaPadraoDTO()
            {
                Sucesso = true,
                Mensagem = "Produto removido com sucesso!"
            };
        }

        public ProdutoDTO ObterProduto(long produtoId)
        {
            var produto = _repositorioProduto.ObterPorId(produtoId);
            if (produto == null)
                throw new Exception("Produto nao encontrado");

            return ToDTO(produto);
        }

        public IEnumerable<ProdutoDTO> ObterTodosProdutos()
        {
            var produtos = _repositorioProduto.ObterTodos();
            if (produtos == null || !produtos.Any())
                return new List<ProdutoDTO>();

            return produtos.Select(produto => ToDTO(produto))
                           .ToList();
        }

        private static ProdutoDTO ToDTO(Produto produto)
        {
            return new ProdutoDTO()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Altura = produto.Altura,
                Comprimento = produto.Comprimento,
                Largura = produto.Largura,
                MarcaId = produto.MarcaId,
                Peso = produto.Peso,
                SubcategoriaId = produto.SubcategoriaId
            };
        }
    }
}
