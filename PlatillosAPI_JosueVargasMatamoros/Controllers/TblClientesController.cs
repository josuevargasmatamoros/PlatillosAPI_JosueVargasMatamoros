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
    public class TblClientesController : ControllerBase
    {
        private readonly PlatillosDbContext _context;

        public TblClientesController(PlatillosDbContext context)
        {
            _context = context;
        }

        // GET: api/TblClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCliente>>> GetTblClientes()
        {
            return await _context.TblClientes.ToListAsync();
        }

        // GET: api/TblClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCliente>> GetTblCliente(int id)
        {
            var tblCliente = await _context.TblClientes.FindAsync(id);

            if (tblCliente == null)
            {
                return NotFound();
            }

            return tblCliente;
        }

        // PUT: api/TblClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCliente(int id, TblCliente tblCliente)
        {
            if (id != tblCliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(tblCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblClienteExists(id))
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

        // POST: api/TblClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCliente>> PostTblCliente(TblCliente tblCliente)
        {
            _context.TblClientes.Add(tblCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCliente", new { id = tblCliente.IdCliente }, tblCliente);
        }

        // DELETE: api/TblClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCliente(int id)
        {
            var tblCliente = await _context.TblClientes.FindAsync(id);
            if (tblCliente == null)
            {
                return NotFound();
            }

            _context.TblClientes.Remove(tblCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblClienteExists(int id)
        {
            return _context.TblClientes.Any(e => e.IdCliente == id);
        }
    }
}
