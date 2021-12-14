using ImagineArte.Aplicacao.Organizacao;
using ImagineArte.Dominio.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Api.Controllers.Painel.Organizacao
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoAplicacao _departamentoAplicacao;

        public DepartamentoController(DepartamentoAplicacao departamentoAplicacao)
        {
            _departamentoAplicacao = departamentoAplicacao;
        }

        [HttpGet("obterDepartamento/{departamentoId}")]
        public ActionResult<DepartamentoDTO> ObterDepartamento(long departamentoId)
        {
            try
            {
                var departamento = _departamentoAplicacao.ObterDepartamento(departamentoId);
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("obterTodosDepartamentos/")]
        public ActionResult<List<DepartamentoDTO>> ObterTodosDepartamentos()
        {
            try
            {
                var departamento = _departamentoAplicacao.ObterTodosDepartamento();
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("adicionarDepartamento/")]
        public ActionResult<RespostaPadraoDTO> AdicionarDepartamento(DepartamentoDTO departamento)
        {
            try
            {
                var resposta = _departamentoAplicacao.Adicionar(departamento);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("atualizarDepartamento/")]
        public ActionResult<RespostaPadraoDTO> AtualizarDepartamento(DepartamentoDTO departamento)
        {
            try
            {
                var resposta = _departamentoAplicacao.Atualizar(departamento);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("removerDepartamento/{departamentoId}")]
        public ActionResult<RespostaPadraoDTO> RemoverDepartamento(long departamentoId)
        {
            try
            {
                var resposta = _departamentoAplicacao.Remover(departamentoId);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
