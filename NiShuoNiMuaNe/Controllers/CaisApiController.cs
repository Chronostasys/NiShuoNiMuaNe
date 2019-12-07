using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiShuoNiMuaNe.Data;
using NiShuoNiMuaNe.Models;

namespace NiShuoNiMuaNe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaisApiController : ControllerBase
    {
        private readonly NiShuoNiMuaNeContext _context;

        public CaisApiController(NiShuoNiMuaNeContext context)
        {
            _context = context;
        }

        // GET: api/CaisApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cai>>> GetCai()
        {
            return await _context.Cai.ToListAsync();
        }

        // GET: api/CaisApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cai>> GetCai(Guid id)
        {
            var cai = await _context.Cai.FindAsync(id);

            if (cai == null)
            {
                return NotFound();
            }

            return cai;
        }

        // PUT: api/CaisApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCai(Guid id, Cai cai)
        {
            if (id != cai.Id)
            {
                return BadRequest();
            }

            _context.Entry(cai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaiExists(id))
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

        // POST: api/CaisApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cai>> PostCai(Cai cai)
        {
            _context.Cai.Add(cai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCai", new { id = cai.Id }, cai);
        }

        // DELETE: api/CaisApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cai>> DeleteCai(Guid id)
        {
            var cai = await _context.Cai.FindAsync(id);
            if (cai == null)
            {
                return NotFound();
            }

            _context.Cai.Remove(cai);
            await _context.SaveChangesAsync();

            return cai;
        }

        private bool CaiExists(Guid id)
        {
            return _context.Cai.Any(e => e.Id == id);
        }
    }
}
