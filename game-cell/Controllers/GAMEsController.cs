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
    
    public class GAMEsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GAMEsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GAMEs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GAMEs.Include(g => g.Platforms);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GAMEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gAME = await _context.GAMEs
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(m => m.GAMEId == id);
            if (gAME == null)
            {
                return NotFound();
            }

            return View(gAME);
        }
        
        // GET: GAMEs/Create
        public IActionResult Create()
        {
            ViewData["PlatformsId"] = new SelectList(_context.Platformss, "PlatformsId", "PlatformsId");
            return View();
        }

        // POST: GAMEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GAMEId,GAMEName,PlatformsId")] GAME gAME)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gAME);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatformsId"] = new SelectList(_context.Platformss, "PlatformsId", "PlatformsId", gAME.PlatformsId);
            return View(gAME);
        }
        [Authorize]
        // GET: GAMEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gAME = await _context.GAMEs.FindAsync(id);
            if (gAME == null)
            {
                return NotFound();
            }
            ViewData["PlatformsId"] = new SelectList(_context.Platformss, "PlatformsId", "PlatformsId", gAME.PlatformsId);
            return View(gAME);
        }
        [Authorize]
        // POST: GAMEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GAMEId,GAMEName,PlatformsId")] GAME gAME)
        {
            if (id != gAME.GAMEId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gAME);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GAMEExists(gAME.GAMEId))
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
            ViewData["PlatformsId"] = new SelectList(_context.Platformss, "PlatformsId", "PlatformsId", gAME.PlatformsId);
            return View(gAME);
        }
        [Authorize]
        // GET: GAMEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var gAME = await _context.GAMEs
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(m => m.GAMEId == id);
            if (gAME == null)
            {
                return NotFound();
            }

            return View(gAME);
        }

        // POST: GAMEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gAME = await _context.GAMEs.FindAsync(id);
            _context.GAMEs.Remove(gAME);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GAMEExists(int id)
        {
            return _context.GAMEs.Any(e => e.GAMEId == id);
        }
    }
}
