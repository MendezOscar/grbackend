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
    public class HistorialTecnicoController : ControllerBase
    {
        private readonly grdbContext _context;

        public HistorialTecnicoController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialTecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historialtecnico>>> GetHistorialtecnico()
        {
            return await _context.Historialtecnico.ToListAsync();
        }

        // GET: api/HistorialTecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historialtecnico>> GetHistorialtecnico(int id)
        {
            var historialtecnico = await _context.Historialtecnico.FindAsync(id);

            if (historialtecnico == null)
            {
                return NotFound();
            }

            return historialtecnico;
        }

        // PUT: api/HistorialTecnico/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialtecnico(int id, Historialtecnico historialtecnico)
        {
            if (id != historialtecnico.Historialtecnicoid)
            {
                return BadRequest();
            }

            _context.Entry(historialtecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialtecnicoExists(id))
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

        // POST: api/HistorialTecnico
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Historialtecnico>> PostHistorialtecnico(Historialtecnico historialtecnico)
        {
            _context.Historialtecnico.Add(historialtecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialtecnico", new { id = historialtecnico.Historialtecnicoid }, historialtecnico);
        }

        // DELETE: api/HistorialTecnico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Historialtecnico>> DeleteHistorialtecnico(int id)
        {
            var historialtecnico = await _context.Historialtecnico.FindAsync(id);
            if (historialtecnico == null)
            {
                return NotFound();
            }

            _context.Historialtecnico.Remove(historialtecnico);
            await _context.SaveChangesAsync();

            return historialtecnico;
        }

        private bool HistorialtecnicoExists(int id)
        {
            return _context.Historialtecnico.Any(e => e.Historialtecnicoid == id);
        }
    }
}
