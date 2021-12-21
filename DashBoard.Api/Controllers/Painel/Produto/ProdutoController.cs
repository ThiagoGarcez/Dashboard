using ImagineArte.Aplicacao.Produtos;
using ImagineArte.Dominio.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Api.Controllers.Painel.Produto
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoAplicacao _produtoAplicacao;

        public ProdutoController(ProdutoAplicacao produtoAplicacao)
        {
            _produtoAplicacao = produtoAplicacao;
        }

        [HttpGet("obterPrdouto/{produtoId}")]
        public ActionResult<ProdutoDTO> ObterProduto(long produtoId)
        {
            try
            {
                var produto = _produtoAplicacao.ObterProduto(produtoId);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("obterTodosProdutos/")]
        public ActionResult<List<ProdutoDTO>> ObterTodosProdutos()
        {
            try
            {
                var produto = _produtoAplicacao.ObterTodosProdutos();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("adicionarProduto/")]
        public ActionResult<RespostaPadraoDTO> AdicionarProduto(ProdutoDTO produto)
        {
            try
            {
                var resposta = _produtoAplicacao.Adicionar(produto);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("atualizarProduto/")]
        public ActionResult<RespostaPadraoDTO> AtualizarProduto(ProdutoDTO produto)
        {
            try
            {
                var resposta = _produtoAplicacao.Atualizar(produto);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
