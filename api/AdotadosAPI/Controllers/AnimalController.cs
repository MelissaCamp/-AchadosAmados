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
    public class AnimalController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;

        public AnimalController(AdotadosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAnimalDTO()
        {
            return await _context.AnimalDTO.ToListAsync();
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDTO>> GetAnimalDTO(int id)
        {
            var animalDTO = await _context.AnimalDTO.FindAsync(id);

            if (animalDTO == null)
            {
                return NotFound();
            }

            return animalDTO;
        }

        // PUT: api/Animal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalDTO(int id, AnimalDTO animalDTO)
        {
            if (id != animalDTO.IdAnimal)
            {
                return BadRequest();
            }

            _context.Entry(animalDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalDTOExists(id))
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

        // POST: api/Animal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalDTO>> PostAnimalDTO(AnimalDTO animalDTO)
        {
            _context.AnimalDTO.Add(animalDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalDTO", new { id = animalDTO.IdAnimal }, animalDTO);
        }

        // DELETE: api/Animal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalDTO(int id)
        {
            var animalDTO = await _context.AnimalDTO.FindAsync(id);
            if (animalDTO == null)
            {
                return NotFound();
            }

            _context.AnimalDTO.Remove(animalDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalDTOExists(int id)
        {
            return _context.AnimalDTO.Any(e => e.IdAnimal == id);
        }
    }
}
