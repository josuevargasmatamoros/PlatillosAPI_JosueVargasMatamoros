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
    public class TblPlatilloIngredientesController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblPlatilloIngredientesController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblPlatilloIngredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPlatilloIngrediente>>> GetTblPlatilloIngredientes()
        {
            return await _context.TblPlatilloIngredientes.ToListAsync();
        }

        // GET: api/TblPlatilloIngredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPlatilloIngrediente>> GetTblPlatilloIngrediente(int id)
        {
            var tblPlatilloIngrediente = await _context.TblPlatilloIngredientes.FindAsync(id);

            if (tblPlatilloIngrediente == null)
            {
                return NotFound();
            }

            return tblPlatilloIngrediente;
        }

        // PUT: api/TblPlatilloIngredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPlatilloIngrediente(int id, TblPlatilloIngrediente tblPlatilloIngrediente)
        {
            if (id != tblPlatilloIngrediente.IdPlatilloIngrediente)
            {
                return BadRequest();
            }

            _context.Entry(tblPlatilloIngrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlatilloIngredienteExists(id))
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

        // POST: api/TblPlatilloIngredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPlatilloIngrediente>> PostTblPlatilloIngrediente(TblPlatilloIngrediente tblPlatilloIngrediente)
        {
            _context.TblPlatilloIngredientes.Add(tblPlatilloIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlatilloIngrediente", new { id = tblPlatilloIngrediente.IdPlatilloIngrediente }, tblPlatilloIngrediente);
        }

        // DELETE: api/TblPlatilloIngredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPlatilloIngrediente(int id)
        {
            var tblPlatilloIngrediente = await _context.TblPlatilloIngredientes.FindAsync(id);
            if (tblPlatilloIngrediente == null)
            {
                return NotFound();
            }

            _context.TblPlatilloIngredientes.Remove(tblPlatilloIngrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPlatilloIngredienteExists(int id)
        {
            return _context.TblPlatilloIngredientes.Any(e => e.IdPlatilloIngrediente == id);
        }
    }
}
