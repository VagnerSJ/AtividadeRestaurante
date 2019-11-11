using System;
using System.Linq;
using System.Threading.Tasks;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_PeDeFava.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("r_Refeicao_ConsumoCliente")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class R_Refeicao_ConsumoClienteController : ControllerBase
    {
        private IR_Refeicao_ConsumoClienteBusiness _r_Refeicao_ConsumoClienteBusiness;

        public R_Refeicao_ConsumoClienteController(IR_Refeicao_ConsumoClienteBusiness r_Refeicao_ConsumoClienteBusiness)
        {
            _r_Refeicao_ConsumoClienteBusiness = r_Refeicao_ConsumoClienteBusiness;
        }

        [HttpPost(Name = "CreateR_Refeicao_ConsumoCliente")]
        public async Task<IActionResult> Create([FromBody]R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente)
        {
            try
            {
                if (!ModelState.IsValid || r_Refeicao_ConsumoCliente == null)
                    return BadRequest(ModelState);

                var newR_Refeicao_ConsumoCliente = await _r_Refeicao_ConsumoClienteBusiness.Create(r_Refeicao_ConsumoCliente);
                return Ok(newR_Refeicao_ConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut("update", Name = "UpdateR_Refeicao_ConsumoCliente")]
        public async Task<IActionResult> Update(R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente)
        {
            try
            {
                if (!ModelState.IsValid || r_Refeicao_ConsumoCliente == null)
                    return BadRequest(ModelState);

                var newR_Refeicao_ConsumoCliente = await _r_Refeicao_ConsumoClienteBusiness.Update(r_Refeicao_ConsumoCliente);
                return Ok(newR_Refeicao_ConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete("delete/{id}", Name = "DeleteR_Refeicao_ConsumoCliente")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                await _r_Refeicao_ConsumoClienteBusiness.Delete(id);
                return Ok("Relacao removida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("getById/{id}", Name = "GetByIdR_Refeicao_ConsumoCliente")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var R_Refeicao_ConsumoCliente = await _r_Refeicao_ConsumoClienteBusiness.FindById(id);
                if (R_Refeicao_ConsumoCliente == null)
                    return NotFound("Relacao removida ou nao existente no banco de dados.");

                return Ok(R_Refeicao_ConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet(Name = "GetAllR_Refeicao_ConsumoCliente")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newListaR_Refeicao_ConsumoClientes = await _r_Refeicao_ConsumoClienteBusiness.FindAll();
                return Ok(newListaR_Refeicao_ConsumoClientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        /*[HttpGet("getConta/{id}", Name = "GetConta")]
        public void GetConta(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    BadRequest(ModelState);

                _r_Refeicao_ConsumoClienteBusiness.GetConta(id);
                //if (conta == null)
                //   NotFound("Relacao removida ou nao existente no banco de dados.");

                //return Ok(R_Refeicao_ConsumoCliente);
            }
            catch (Exception ex)
            {
                BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }*/
    }
}