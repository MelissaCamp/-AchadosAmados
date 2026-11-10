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
    //[Authorize]
    [ApiController]
    public class AdotadoController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public AdotadoController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Adotado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdotadoDTO>>> GetAdotadoDTO()
        {
            return await _context.AdotadoDTO.ToListAsync();
        }

        // GET: api/Adotado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdotadoDTO>> GetAdotadoDTO(int id)
        {
            var adotadoDTO = await _context.AdotadoDTO.FindAsync(id);

            if (adotadoDTO == null)
            {
                return NotFound();
            }

            return adotadoDTO;
        }

        // PUT: api/Adotado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdotadoDTO(int id, AdotadoDTO adotadoDTO)
        {
            if (id != adotadoDTO.IdAdotado)
            {
                return BadRequest();
            }

            _context.Entry(adotadoDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdotadoDTOExists(id))
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

        // POST: api/Adotado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdotadoDTO>> PostAdotadoDTO(AdotadoDTO adotadoDTO)
        {
            _context.AdotadoDTO.Add(adotadoDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdotadoDTO", new { id = adotadoDTO.IdAdotado }, adotadoDTO);
        }

        // DELETE: api/Adotado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdotadoDTO(int id)
        {
            var adotadoDTO = await _context.AdotadoDTO.FindAsync(id);
            if (adotadoDTO == null)
            {
                return NotFound();
            }

            _context.AdotadoDTO.Remove(adotadoDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdotadoDTOExists(int id)
        {
            return _context.AdotadoDTO.Any(e => e.IdAdotado == id);
        }
    }
}
