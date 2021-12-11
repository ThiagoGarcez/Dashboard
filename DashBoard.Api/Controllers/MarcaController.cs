using ImagineArte.Aplicacao.Produtos;
using ImagineArte.Dominio.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaAplicacao _marcaAplicacao;

        public MarcaController(MarcaAplicacao marcaAplicacao)
        {
            _marcaAplicacao = marcaAplicacao;
        }

        [HttpGet("obterMarca/{marcaId}")]
        public ActionResult<MarcaDTO> ObterMarca(long marcaId)
        {
            try
            {
                var marca = _marcaAplicacao.ObterMarca(marcaId);
                return Ok(marca);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("obterTodasMarcas/")]
        public ActionResult<List<ProdutoDTO>> ObterTodasMarcas()
        {
            try
            {
                var marcas = _marcaAplicacao.ObterTodasMarcas();
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("adcionrMarca/")]
        public ActionResult<RespostaPadraoDTO> AdicionarMarca(MarcaDTO marca)
        {
            try
            {
                var resposta = _marcaAplicacao.Adicionar(marca);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("atualizarMarca/")]
        public ActionResult<RespostaPadraoDTO> AtualizarMarca(MarcaDTO marca)
        {
            try
            {
                var resposta = _marcaAplicacao.Atualizar(marca);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
