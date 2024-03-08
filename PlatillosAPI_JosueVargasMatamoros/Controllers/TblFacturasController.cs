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
    public class TblFacturasController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblFacturasController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFactura>>> GetTblFacturas()
        {
            return await _context.TblFacturas.ToListAsync();
        }

        // GET: api/TblFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFactura>> GetTblFactura(int id)
        {
            var tblFactura = await _context.TblFacturas.FindAsync(id);

            if (tblFactura == null)
            {
                return NotFound();
            }

            return tblFactura;
        }

        // PUT: api/TblFacturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFactura(int id, TblFactura tblFactura)
        {
            if (id != tblFactura.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(tblFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFacturaExists(id))
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

        // POST: api/TblFacturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFactura>> PostTblFactura(TblFactura tblFactura)
        {
            _context.TblFacturas.Add(tblFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFactura", new { id = tblFactura.IdFactura }, tblFactura);
        }

        // DELETE: api/TblFacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFactura(int id)
        {
            var tblFactura = await _context.TblFacturas.FindAsync(id);
            if (tblFactura == null)
            {
                return NotFound();
            }

            _context.TblFacturas.Remove(tblFactura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFacturaExists(int id)
        {
            return _context.TblFacturas.Any(e => e.IdFactura == id);
        }
    }
}
