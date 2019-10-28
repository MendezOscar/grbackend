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
    public class ContratoController : ControllerBase
    {
        private readonly grdbContext _context;

        public ContratoController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContrato()
        {
            return await _context.Contrato.ToListAsync();
        }

        // GET: api/Contrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }

        // PUT: api/Contrato/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.Contratoid)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contrato
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            _context.Contrato.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContrato", new { id = contrato.Contratoid }, contrato);
        }

        // DELETE: api/Contrato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contrato>> DeleteContrato(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();

            return contrato;
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.Contratoid == id);
        }
    }
}
