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
    public class TipoAnimalController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public TipoAnimalController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/TipoAnimal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAnimalDTO>>> GetTipoAnimalDTO()
        {
            return await _context.TipoAnimalDTO.ToListAsync();
        }

        // GET: api/TipoAnimal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAnimalDTO>> GetTipoAnimalDTO(int id)
        {
            var tipoAnimalDTO = await _context.TipoAnimalDTO.FindAsync(id);

            if (tipoAnimalDTO == null)
            {
                return NotFound();
            }

            return tipoAnimalDTO;
        }

        // PUT: api/TipoAnimal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAnimalDTO(int id, TipoAnimalDTO tipoAnimalDTO)
        {
            if (id != tipoAnimalDTO.IdTpAnimal)
            {
                return BadRequest();
            }

            _context.Entry(tipoAnimalDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAnimalDTOExists(id))
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

        // POST: api/TipoAnimal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAnimalDTO>> PostTipoAnimalDTO(TipoAnimalDTO tipoAnimalDTO)
        {
            _context.TipoAnimalDTO.Add(tipoAnimalDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoAnimalDTO", new { id = tipoAnimalDTO.IdTpAnimal }, tipoAnimalDTO);
        }

        // DELETE: api/TipoAnimal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAnimalDTO(int id)
        {
            var tipoAnimalDTO = await _context.TipoAnimalDTO.FindAsync(id);
            if (tipoAnimalDTO == null)
            {
                return NotFound();
            }

            _context.TipoAnimalDTO.Remove(tipoAnimalDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAnimalDTOExists(int id)
        {
            return _context.TipoAnimalDTO.Any(e => e.IdTpAnimal == id);
        }
    }
}
