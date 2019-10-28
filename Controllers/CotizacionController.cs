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
    public class CotizacionController : ControllerBase
    {
        private readonly grdbContext _context;

        public CotizacionController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Cotizacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotizacion>>> GetCotizacion()
        {
            return await _context.Cotizacion.ToListAsync();
        }

        // GET: api/Cotizacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizacion>> GetCotizacion(int id)
        {
            var cotizacion = await _context.Cotizacion.FindAsync(id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return cotizacion;
        }

        // PUT: api/Cotizacion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(int id, Cotizacion cotizacion)
        {
            if (id != cotizacion.Cotizacionid)
            {
                return BadRequest();
            }

            _context.Entry(cotizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionExists(id))
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

        // POST: api/Cotizacion
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cotizacion>> PostCotizacion(Cotizacion cotizacion)
        {
            _context.Cotizacion.Add(cotizacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotizacion", new { id = cotizacion.Cotizacionid }, cotizacion);
        }

        // DELETE: api/Cotizacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotizacion>> DeleteCotizacion(int id)
        {
            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            _context.Cotizacion.Remove(cotizacion);
            await _context.SaveChangesAsync();

            return cotizacion;
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizacion.Any(e => e.Cotizacionid == id);
        }
    }
}
