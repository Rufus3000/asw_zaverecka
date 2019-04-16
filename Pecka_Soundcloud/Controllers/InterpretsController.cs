using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pecka_Soundcloud.Data;
using Pecka_Soundcloud.Entities;

namespace Pecka_Soundcloud.Controllers
{
    public class InterpretsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterpretsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interprets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interprets.ToListAsync());
        }

        // GET: Interprets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interpret = await _context.Interprets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interpret == null)
            {
                return NotFound();
            }

            return View(interpret);
        }

        // GET: Interprets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interprets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country")] Interpret interpret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interpret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interpret);
        }

        // GET: Interprets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interpret = await _context.Interprets.FindAsync(id);
            if (interpret == null)
            {
                return NotFound();
            }
            return View(interpret);
        }

        // POST: Interprets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country")] Interpret interpret)
        {
            if (id != interpret.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interpret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterpretExists(interpret.Id))
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
            return View(interpret);
        }

        // GET: Interprets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interpret = await _context.Interprets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interpret == null)
            {
                return NotFound();
            }

            return View(interpret);
        }

        // POST: Interprets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interpret = await _context.Interprets.FindAsync(id);
            _context.Interprets.Remove(interpret);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterpretExists(int id)
        {
            return _context.Interprets.Any(e => e.Id == id);
        }
    }
}
