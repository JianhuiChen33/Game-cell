using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using game_cell.Data;
using game_cell.Models;
using Microsoft.AspNetCore.Authorization;

namespace game_cell.Controllers
{
    
    public class PlatformsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatformsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Platforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platformss.ToListAsync());
        }

        // GET: Platforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platforms = await _context.Platformss
                .FirstOrDefaultAsync(m => m.PlatformsId == id);
            if (platforms == null)
            {
                return NotFound();
            }

            return View(platforms);
        }

        // GET: Platforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlatformsId,Name")] Platforms platforms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platforms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platforms);
        }
        [Authorize]
        // GET: Platforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platforms = await _context.Platformss.FindAsync(id);
            if (platforms == null)
            {
                return NotFound();
            }
            return View(platforms);
        }
        [Authorize]
        // POST: Platforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlatformsId,Name")] Platforms platforms)
        {
            if (id != platforms.PlatformsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platforms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatformsExists(platforms.PlatformsId))
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
            return View(platforms);
        }
        [Authorize]
        // GET: Platforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platforms = await _context.Platformss
                .FirstOrDefaultAsync(m => m.PlatformsId == id);
            if (platforms == null)
            {
                return NotFound();
            }

            return View(platforms);
        }

        // POST: Platforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platforms = await _context.Platformss.FindAsync(id);
            _context.Platformss.Remove(platforms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatformsExists(int id)
        {
            return _context.Platformss.Any(e => e.PlatformsId == id);
        }
    }
}
