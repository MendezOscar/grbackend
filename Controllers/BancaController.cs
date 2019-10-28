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
    public class BancaController : ControllerBase
    {
        private readonly grdbContext _context;

        public BancaController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Banca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banca>>> GetBanca()
        {
            return await _context.Banca.ToListAsync();
        }

        // GET: api/Banca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banca>> GetBanca(int id)
        {
            var banca = await _context.Banca.FindAsync(id);

            if (banca == null)
            {
                return NotFound();
            }

            return banca;
        }

        // PUT: api/Banca/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanca(int id, Banca banca)
        {
            if (id != banca.Bancaid)
            {
                return BadRequest();
            }

            _context.Entry(banca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancaExists(id))
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

        // POST: api/Banca
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Banca>> PostBanca(Banca banca)
        {
            _context.Banca.Add(banca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanca", new { id = banca.Bancaid }, banca);
        }

        // DELETE: api/Banca/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banca>> DeleteBanca(int id)
        {
            var banca = await _context.Banca.FindAsync(id);
            if (banca == null)
            {
                return NotFound();
            }

            _context.Banca.Remove(banca);
            await _context.SaveChangesAsync();

            return banca;
        }

        private bool BancaExists(int id)
        {
            return _context.Banca.Any(e => e.Bancaid == id);
        }
    }
}
