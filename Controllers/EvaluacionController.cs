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
    public class EvaluacionController : ControllerBase
    {
        private readonly grdbContext _context;

        public EvaluacionController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Evaluacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluacion>>> GetEvaluacion()
        {
            return await _context.Evaluacion.ToListAsync();
        }

        // GET: api/Evaluacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluacion>> GetEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return evaluacion;
        }

        // PUT: api/Evaluacion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacion(int id, Evaluacion evaluacion)
        {
            if (id != evaluacion.Evaluacionid)
            {
                return BadRequest();
            }

            _context.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(id))
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

        // POST: api/Evaluacion
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Evaluacion>> PostEvaluacion(Evaluacion evaluacion)
        {
            _context.Evaluacion.Add(evaluacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluacion", new { id = evaluacion.Evaluacionid }, evaluacion);
        }

        // DELETE: api/Evaluacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evaluacion>> DeleteEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            _context.Evaluacion.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return evaluacion;
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluacion.Any(e => e.Evaluacionid == id);
        }
    }
}
