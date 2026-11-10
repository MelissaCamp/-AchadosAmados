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
    //[Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public FuncionarioController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetFuncionarioDTO()
        {
            return await _context.FuncionarioDTO.ToListAsync();
        }

        // GET: api/Tarefa/UsuarioLogado
        [HttpGet]
        [Route("FuncionarioLogado")]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetTarefaUsuarioLogado()
        {
            //pegando o id usuario do token do login
            int idFuncionario = Convert.ToInt32(User.FindFirst("IdFuncionario")?.Value);

            //filtra as tarefas por id de usuario
            return await _context.FuncionarioDTO.Where(x => x.IdFuncionario == idFuncionario).ToListAsync();
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionarioDTO(int id)
        {
            var funcionarioDTO = await _context.FuncionarioDTO.FindAsync(id);

            if (funcionarioDTO == null)
            {
                return NotFound();
            }

            return funcionarioDTO;
        }

        // PUT: api/Funcionario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionarioDTO(int id, FuncionarioDTO funcionarioDTO)
        {
            if (id != funcionarioDTO.IdFuncionario)
            {
                return BadRequest();
            }

            _context.Entry(funcionarioDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioDTOExists(id))
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

        // POST: api/Funcionario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuncionarioDTO>> PostFuncionarioDTO(FuncionarioDTO funcionarioDTO)
        {
            _context.FuncionarioDTO.Add(funcionarioDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionarioDTO", new { id = funcionarioDTO.IdFuncionario }, funcionarioDTO);
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarioDTO(int id)
        {
            var funcionarioDTO = await _context.FuncionarioDTO.FindAsync(id);
            if (funcionarioDTO == null)
            {
                return NotFound();
            }

            _context.FuncionarioDTO.Remove(funcionarioDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioDTOExists(int id)
        {
            return _context.FuncionarioDTO.Any(e => e.IdFuncionario == id);
        }
    }
}
