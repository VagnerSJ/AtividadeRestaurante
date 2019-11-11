using System;
using System.Threading.Tasks;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_PeDeFava.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("tipoProduto")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TipoProdutoController : ControllerBase
    {
        private ITipoProdutoBusiness _tipoProdutoBusiness;

        public TipoProdutoController(ITipoProdutoBusiness tipoProdutoBusiness)
        {
            _tipoProdutoBusiness = tipoProdutoBusiness;
        }

        [HttpPost(Name = "CreateTipoProduto")]
        public async Task<IActionResult> Create([FromBody]TipoProduto tipoProduto)
        {
            try
            {
                if (!ModelState.IsValid || tipoProduto == null)
                    return BadRequest(ModelState);

                var newTipoProduto = await _tipoProdutoBusiness.Create(tipoProduto);
                return Ok(newTipoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut("update", Name = "UpdateTipoProduto")]
        public async Task<IActionResult> Update(TipoProduto tipoProduto)
        {
            try
            {
                if (!ModelState.IsValid || tipoProduto == null)
                    return BadRequest(ModelState);

                var newTipoProduto = await _tipoProdutoBusiness.Update(tipoProduto);
                return Ok(newTipoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete("delete/{id}", Name = "DeleteTipoProduto")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                await _tipoProdutoBusiness.Delete(id);
                return Ok("Tipo do produto removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("getById/{id}", Name = "GetByIdTipoProduto")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var tipoProduto = await _tipoProdutoBusiness.FindById(id);
                if (tipoProduto == null)
                    return NotFound("Tipo de produto removido ou nao existente na base de dados.");

                return Ok(tipoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet(Name = "GetAllTipoProduto")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newListaTipoProdutos = await _tipoProdutoBusiness.FindAll();
                return Ok(newListaTipoProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}