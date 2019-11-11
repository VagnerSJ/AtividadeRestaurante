using System;
using System.Threading.Tasks;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_PeDeFava.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("consumoClientes")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ConsumoClienteController : ControllerBase
    {
        private IConsumoClienteBusiness _consumoClienteBusiness;

        public ConsumoClienteController(IConsumoClienteBusiness consumoClienteBusiness)
        {
            _consumoClienteBusiness = consumoClienteBusiness;
        }

        [HttpPost(Name = "CreateConsumoCliente")]
        public async Task<IActionResult> Create([FromBody]ConsumoCliente consumoCliente)
        {
            try
            {
                if (!ModelState.IsValid || consumoCliente == null)
                    return BadRequest(ModelState);

                var newConsumoCliente = await _consumoClienteBusiness.Create(consumoCliente);
                return Ok(newConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut("update", Name = "UpdateConsumoCliente")]
        public async Task<IActionResult> Update(ConsumoCliente consumoCliente)
        {
            try
            {
                if (!ModelState.IsValid || consumoCliente == null)
                    return BadRequest(ModelState);

                var putConsumoCliente = await _consumoClienteBusiness.Update(consumoCliente);
                return Ok(putConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                await _consumoClienteBusiness.Delete(id);
                return Ok("Consumo do cliente removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("getByIdConsumoCliente/{id}", Name = "GetByIdConsumoCliente")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var newConsumoCliente = await _consumoClienteBusiness.FindById(id);
                if (newConsumoCliente == null)
                    return NotFound("Consumo do cliente removido ou nao existente na base de dados.");

                return Ok(newConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("getByIdCliente/{id}", Name = "GetConsumoClienteByIdCliente")]
        public async Task<IActionResult> FindByIdCliente(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var newConsumoClienteDoCliente = await _consumoClienteBusiness.FindByIdCliente(id);
                if (newConsumoClienteDoCliente == null)
                    return NotFound("Cliente nao possui registro de consumo ou nao existe no banco de dados.");

                return Ok(newConsumoClienteDoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet(Name = "GetAllConsumoCliente")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newListaConsumoCliente = await _consumoClienteBusiness.FindAll();
                return Ok(newListaConsumoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}