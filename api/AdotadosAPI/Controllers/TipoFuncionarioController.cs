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
    public class TipoFuncionarioController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public TipoFuncionarioController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/TipoFuncionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFuncionarioDTO>>> GetTipoFuncionarioDTO()
        {
            return await _context.TipoFuncionarioDTO.ToListAsync();
        }

        // GET: api/TipoFuncionario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFuncionarioDTO>> GetTipoFuncionarioDTO(int id)
        {
            var tipoFuncionarioDTO = await _context.TipoFuncionarioDTO.FindAsync(id);

            if (tipoFuncionarioDTO == null)
            {
                return NotFound();
            }

            return tipoFuncionarioDTO;
        }

        // PUT: api/TipoFuncionario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoFuncionarioDTO(int id, TipoFuncionarioDTO tipoFuncionarioDTO)
        {
            if (id != tipoFuncionarioDTO.IdTpFuncionario)
            {
                return BadRequest();
            }

            _context.Entry(tipoFuncionarioDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFuncionarioDTOExists(id))
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

        // POST: api/TipoFuncionario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoFuncionarioDTO>> PostTipoFuncionarioDTO(TipoFuncionarioDTO tipoFuncionarioDTO)
        {
            _context.TipoFuncionarioDTO.Add(tipoFuncionarioDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoFuncionarioDTO", new { id = tipoFuncionarioDTO.IdTpFuncionario }, tipoFuncionarioDTO);
        }

        // DELETE: api/TipoFuncionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoFuncionarioDTO(int id)
        {
            var tipoFuncionarioDTO = await _context.TipoFuncionarioDTO.FindAsync(id);
            if (tipoFuncionarioDTO == null)
            {
                return NotFound();
            }

            _context.TipoFuncionarioDTO.Remove(tipoFuncionarioDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoFuncionarioDTOExists(int id)
        {
            return _context.TipoFuncionarioDTO.Any(e => e.IdTpFuncionario == id);
        }
    }
}
