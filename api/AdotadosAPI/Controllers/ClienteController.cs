using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdotadosAPI.Data;
using AdotadosDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace AdotadosAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public ClienteController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClienteDTO()
        {
            return await _context.ClienteDTO.ToListAsync();
        }

        // GET: api/Tarefa/UsuarioLogado
        [HttpGet]
        [Route("ClienteLogado")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetTarefaUsuarioLogado()
        {
            //pegando o id usuario do token do login
            int idCliente = Convert.ToInt32(User.FindFirst("IdCliente")?.Value);

            //filtra as tarefas por id de usuario
            return await _context.ClienteDTO.Where(x => x.IdCliente == idCliente).ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetClienteDTO(int id)
        {
            var clienteDTO = await _context.ClienteDTO.FindAsync(id);

            if (clienteDTO == null)
            {
                return NotFound();
            }

            return clienteDTO;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteDTO(int id, ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(clienteDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostClienteDTO(ClienteDTO clienteDTO)
        {
            _context.ClienteDTO.Add(clienteDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteDTO", new { id = clienteDTO.IdCliente }, clienteDTO);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteDTO(int id)
        {
            var clienteDTO = await _context.ClienteDTO.FindAsync(id);
            if (clienteDTO == null)
            {
                return NotFound();
            }

            _context.ClienteDTO.Remove(clienteDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteDTOExists(int id)
        {
            return _context.ClienteDTO.Any(e => e.IdCliente == id);
        }
    }
}
