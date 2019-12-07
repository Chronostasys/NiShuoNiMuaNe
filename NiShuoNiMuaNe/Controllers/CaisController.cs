using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NiShuoNiMuaNe.Data;
using NiShuoNiMuaNe.Models;

namespace NiShuoNiMuaNe.Controllers
{
    public class CaisController : Controller
    {
        private readonly NiShuoNiMuaNeContext _context;

        public CaisController(NiShuoNiMuaNeContext context)
        {
            _context = context;
        }

        // GET: Cais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cai.ToListAsync());
        }

        // GET: Cais/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cai = await _context.Cai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cai == null)
            {
                return NotFound();
            }

            return View(cai);
        }

        // GET: Cais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Name,BaoZhiQi,Weight,Seller")] Cai cai)
        {
            if (ModelState.IsValid)
            {
                cai.Id = Guid.NewGuid();
                _context.Add(cai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cai);
        }

        // GET: Cais/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cai = await _context.Cai.FindAsync(id);
            if (cai == null)
            {
                return NotFound();
            }
            return View(cai);
        }

        // POST: Cais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Price,Name,BaoZhiQi,Weight,Seller")] Cai cai)
        {
            if (id != cai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaiExists(cai.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cai);
        }

        // GET: Cais/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cai = await _context.Cai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cai == null)
            {
                return NotFound();
            }

            return View(cai);
        }

        // POST: Cais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cai = await _context.Cai.FindAsync(id);
            _context.Cai.Remove(cai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaiExists(Guid id)
        {
            return _context.Cai.Any(e => e.Id == id);
        }
    }
}
