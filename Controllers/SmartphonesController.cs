using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PranavSmartphones.Data;
using PranavSmartphones.Models;

namespace PranavSmartphones.Controllers
{
    public class SmartphonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmartphonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Smartphones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Smartphones.ToListAsync());
        }

        // GET: Smartphones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphones = await _context.Smartphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartphones == null)
            {
                return NotFound();
            }

            return View(smartphones);
        }

        // GET: Smartphones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Model,Stroge,Price")] Smartphones smartphones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smartphones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smartphones);
        }

        // GET: Smartphones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphones = await _context.Smartphones.FindAsync(id);
            if (smartphones == null)
            {
                return NotFound();
            }
            return View(smartphones);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Model,Stroge,Price")] Smartphones smartphones)
        {
            if (id != smartphones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smartphones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmartphonesExists(smartphones.Id))
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
            return View(smartphones);
        }

        // GET: Smartphones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphones = await _context.Smartphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartphones == null)
            {
                return NotFound();
            }

            return View(smartphones);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smartphones = await _context.Smartphones.FindAsync(id);
            _context.Smartphones.Remove(smartphones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmartphonesExists(int id)
        {
            return _context.Smartphones.Any(e => e.Id == id);
        }
    }
}
