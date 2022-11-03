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
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllEntity()
        {
            return Ok(await _clienteRepository.BuscarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> PostEntity(Cliente user)
        {
            _ = _clienteRepository.Adicionar(user);
            if(await _clienteRepository.SaveAll())
            {
                return Ok("Cadastro efetuado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao salvar!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEntity([FromBody]  Cliente user, int id)
        {
            user.Id = id;
            _ = _clienteRepository.Atualizar(user, id);
            if (await _clienteRepository.SaveAll())
            {
                return Ok("Atualização efetuada com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao atualizar!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntity(int id)
        {
            var usuario = await _clienteRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound("Não encontrado!");
            }

            _ = _clienteRepository.Apagar(id);

            if(await _clienteRepository.SaveAll())
            {
                return Ok("Exclusão efetuada com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao excluir!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntity(int id)
        {
            var usuario = await _clienteRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound("Não encontrado!");
            }

            return Ok(usuario);
        }
    }
}