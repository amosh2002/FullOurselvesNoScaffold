using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbionNoScaffoldFullMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AmbionNoScaffoldFullMVC.Controllers
{
    public class AmbionsController : Controller
    {
        private readonly AmbionNoScaffoldFullMVCContext _context;

        public AmbionsController(AmbionNoScaffoldFullMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Ambion.ToListAsync());
        }

        public IActionResult Create()
        {
            List<bool> Statuses = new List<bool>();
            Statuses.Add(true);
            Statuses.Add(false);

            ViewData["AllStatuses"] = new SelectList(Statuses);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmbionId,AmbionName,AmbionStatus")] Ambion Ambion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Ambion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            List<bool> Statuses = new List<bool>();
            Statuses.Add(true);
            Statuses.Add(false);

            ViewData["AllStatuses"] = new SelectList(Statuses);
            if (id == null)
            {
                return NotFound();
            }

            var ambion = await _context.Ambion.FindAsync(id);
            if (ambion == null)
            {
                return NotFound();
            }
            return View(ambion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmbionId,AmbionName,AmbionStatus")] Ambion ambion)
        {
            if (id != ambion.AmbionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ambion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbionExists(ambion.AmbionId))
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
            return View(ambion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambion = await _context.Ambion
                .FirstOrDefaultAsync(m => m.AmbionId == id);
            if (ambion == null)
            {
                return NotFound();
            }

            return View(ambion);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ambion = await _context.Ambion.FindAsync(id);
            _context.Ambion.Remove(ambion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbionExists(int id)
        {
            return _context.Ambion.Any(e => e.AmbionId == id);
        }

    }
}