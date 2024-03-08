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
    public class TblBebidumsController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblBebidumsController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblBebidums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBebidum>>> GetTblBebida()
        {
            return await _context.TblBebida.ToListAsync();
        }

        // GET: api/TblBebidums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBebidum>> GetTblBebidum(int id)
        {
            var tblBebidum = await _context.TblBebida.FindAsync(id);

            if (tblBebidum == null)
            {
                return NotFound();
            }

            return tblBebidum;
        }

        // PUT: api/TblBebidums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBebidum(int id, TblBebidum tblBebidum)
        {
            if (id != tblBebidum.IdBebida)
            {
                return BadRequest();
            }

            _context.Entry(tblBebidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBebidumExists(id))
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

        // POST: api/TblBebidums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblBebidum>> PostTblBebidum(TblBebidum tblBebidum)
        {
            _context.TblBebida.Add(tblBebidum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBebidum", new { id = tblBebidum.IdBebida }, tblBebidum);
        }

        // DELETE: api/TblBebidums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblBebidum(int id)
        {
            var tblBebidum = await _context.TblBebida.FindAsync(id);
            if (tblBebidum == null)
            {
                return NotFound();
            }

            _context.TblBebida.Remove(tblBebidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblBebidumExists(int id)
        {
            return _context.TblBebida.Any(e => e.IdBebida == id);
        }
    }
}
