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
    public class AnuncioController : ControllerBase
    {
        private readonly grdbContext _context;

        public AnuncioController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Anuncio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anuncio>>> GetAnuncio()
        {
            return await _context.Anuncio.ToListAsync();
        }

        // GET: api/Anuncio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> GetAnuncio(int id)
        {
            var anuncio = await _context.Anuncio.FindAsync(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return anuncio;
        }

        // PUT: api/Anuncio/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncio(int id, Anuncio anuncio)
        {
            if (id != anuncio.Anuncioid)
            {
                return BadRequest();
            }

            _context.Entry(anuncio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioExists(id))
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

        // POST: api/Anuncio
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Anuncio>> PostAnuncio(Anuncio anuncio)
        {
            _context.Anuncio.Add(anuncio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnuncio", new { id = anuncio.Anuncioid }, anuncio);
        }

        // DELETE: api/Anuncio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anuncio>> DeleteAnuncio(int id)
        {
            var anuncio = await _context.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            _context.Anuncio.Remove(anuncio);
            await _context.SaveChangesAsync();

            return anuncio;
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncio.Any(e => e.Anuncioid == id);
        }
    }
}
