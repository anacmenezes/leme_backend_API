using lemeC.API.Models;
using lemeC.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lemeC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteIntRepository _clienteRepository;

        public ClienteController(ClienteIntRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet(Name = "buscarTodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.BuscarTodos());
        }
    }
}