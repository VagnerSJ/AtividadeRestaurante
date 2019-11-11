using System;
using System.Threading.Tasks;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_PeDeFava.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("clientes")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ClienteController : ControllerBase
    {
        private IClienteBusiness _clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Create([FromBody]Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid || cliente == null)
                    return BadRequest(ModelState);

                var newCliente = await _clienteBusiness.Create(cliente);
                return Ok(newCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut(Name = "UpdateCliente")]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid || cliente == null)
                    return BadRequest(ModelState);

                var newCliente = await _clienteBusiness.Update(cliente);
                return Ok(newCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteCliente")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                await _clienteBusiness.Delete(id);
                return Ok("Cliente removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdCliente")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return BadRequest(ModelState);

                var cliente = await _clienteBusiness.FindById(id);
                if (cliente == null)
                    return NotFound("Cliente removido ou nao existente na base de dados.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet(Name = "GetAllCliente")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newListaClientes = await _clienteBusiness.FindAll();
                return Ok(newListaClientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}