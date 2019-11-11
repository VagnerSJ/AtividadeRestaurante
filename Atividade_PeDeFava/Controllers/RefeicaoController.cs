using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_PeDeFava.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("refeicoes")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class RefeicaoController : ControllerBase
    {
        private IRefeicaoBusiness _refeicaoBusiness;

        public RefeicaoController(IRefeicaoBusiness refeicaoBusiness)
        {
            _refeicaoBusiness = refeicaoBusiness;
        }

        [HttpPost(Name = "CreateRefeicao")]
        public async Task<IActionResult> Create([FromBody]Refeicao refeicao)
        {
            try
            {
                if (!ModelState.IsValid || refeicao == null)
                    return BadRequest(ModelState);

                var newCadastroRefeicao = await _refeicaoBusiness.Create(refeicao);
                return Ok(newCadastroRefeicao);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut("update", Name = "UpdateRefeicao")]
        public async Task<IActionResult> Update(Refeicao refeicao)
        {
            try
            {
                if (!ModelState.IsValid || refeicao == null)
                    return BadRequest(ModelState);

                var putCadastroRefeicao = await _refeicaoBusiness.Update(refeicao);
                return Ok(putCadastroRefeicao);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete("delete/{id}", Name = "DeleteRefeicao")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                await _refeicaoBusiness.Delete(id);
                return Ok("Refeicao removida da base de dados com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("refeicao/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var refeicao = await _refeicaoBusiness.FindById(id);
                if (refeicao == null)
                    return NotFound("Refeicao removida ou nao existente na base de dados.");

                return new OkObjectResult(refeicao);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("refeicoes")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newListaRefeicoes = await _refeicaoBusiness.FindAll();
                return Ok(newListaRefeicoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}