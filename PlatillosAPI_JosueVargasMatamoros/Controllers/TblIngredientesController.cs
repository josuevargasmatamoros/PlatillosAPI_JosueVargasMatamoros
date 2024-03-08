using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatillosAPI_JosueVargasMatamoros.Models;

namespace PlatillosAPI_JosueVargasMatamoros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblIngredientesController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblIngredientesController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblIngredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblIngrediente>>> GetTblIngredientes()
        {
            return await _context.TblIngredientes.ToListAsync();
        }

        // GET: api/TblIngredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblIngrediente>> GetTblIngrediente(int id)
        {
            var tblIngrediente = await _context.TblIngredientes.FindAsync(id);

            if (tblIngrediente == null)
            {
                return NotFound();
            }

            return tblIngrediente;
        }

        // PUT: api/TblIngredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblIngrediente(int id, TblIngrediente tblIngrediente)
        {
            if (id != tblIngrediente.IdIngrediente)
            {
                return BadRequest();
            }

            _context.Entry(tblIngrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblIngredienteExists(id))
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

        // POST: api/TblIngredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblIngrediente>> PostTblIngrediente(TblIngrediente tblIngrediente)
        {
            _context.TblIngredientes.Add(tblIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblIngrediente", new { id = tblIngrediente.IdIngrediente }, tblIngrediente);
        }

        // DELETE: api/TblIngredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblIngrediente(int id)
        {
            var tblIngrediente = await _context.TblIngredientes.FindAsync(id);
            if (tblIngrediente == null)
            {
                return NotFound();
            }

            _context.TblIngredientes.Remove(tblIngrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblIngredienteExists(int id)
        {
            return _context.TblIngredientes.Any(e => e.IdIngrediente == id);
        }
    }
}
