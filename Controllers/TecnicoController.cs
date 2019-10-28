using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using grbackend.Models;

namespace grbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly grdbContext _context;

        public TecnicoController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Tecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnico()
        {
            return await _context.Tecnico.ToListAsync();
        }

        // GET: api/Tecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnico>> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnico.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return tecnico;
        }

        // PUT: api/Tecnico/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (id != tecnico.Tecnicoid)
            {
                return BadRequest();
            }

            _context.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnico
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
        {
            _context.Tecnico.Add(tecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTecnico", new { id = tecnico.Tecnicoid }, tecnico);
        }

        // DELETE: api/Tecnico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tecnico>> DeleteTecnico(int id)
        {
            var tecnico = await _context.Tecnico.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            _context.Tecnico.Remove(tecnico);
            await _context.SaveChangesAsync();

            return tecnico;
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnico.Any(e => e.Tecnicoid == id);
        }
    }
}
