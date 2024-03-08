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
    public class TblPlatilloesController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblPlatilloesController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblPlatilloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPlatillo>>> GetTblPlatillos()
        {
            return await _context.TblPlatillos.ToListAsync();
        }

        // GET: api/TblPlatilloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPlatillo>> GetTblPlatillo(int id)
        {
            var tblPlatillo = await _context.TblPlatillos.FindAsync(id);

            if (tblPlatillo == null)
            {
                return NotFound();
            }

            return tblPlatillo;
        }

        // PUT: api/TblPlatilloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPlatillo(int id, TblPlatillo tblPlatillo)
        {
            if (id != tblPlatillo.IdPlatillo)
            {
                return BadRequest();
            }

            _context.Entry(tblPlatillo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlatilloExists(id))
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

        // POST: api/TblPlatilloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPlatillo>> PostTblPlatillo(TblPlatillo tblPlatillo)
        {
            _context.TblPlatillos.Add(tblPlatillo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlatillo", new { id = tblPlatillo.IdPlatillo }, tblPlatillo);
        }

        // DELETE: api/TblPlatilloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPlatillo(int id)
        {
            var tblPlatillo = await _context.TblPlatillos.FindAsync(id);
            if (tblPlatillo == null)
            {
                return NotFound();
            }

            _context.TblPlatillos.Remove(tblPlatillo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPlatilloExists(int id)
        {
            return _context.TblPlatillos.Any(e => e.IdPlatillo == id);
        }
    }
}
