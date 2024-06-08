using MAIOCEAN.Models;
using MAIOCEAN.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAIOCEAN.Controllers
{
    public class RoboController : Controller
    {
        private readonly MAIOCEANDbContext _context;

        public RoboController(MAIOCEANDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Robo.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robo = await _context.Robo
                .FirstOrDefaultAsync(m => m.IdRobo == id);
            if (robo == null)
            {
                return NotFound();
            }

            return View(robo);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRobo,StatusRobo,NmrSerie")] Robo robo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(robo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(robo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robo = await _context.Robo.FindAsync(id);
            if (robo == null)
            {
                return NotFound();
            }
            return View(robo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRobo,StatusRobo,NmrSerie")] Robo robo)
        {
            if (id != robo.IdRobo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboExists(robo.IdRobo))
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
            return View(robo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robo = await _context.Robo
                .FirstOrDefaultAsync(m => m.IdRobo == id);
            if (robo == null)
            {
                return NotFound();
            }

            return View(robo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var robo = await _context.Robo.FindAsync(id);
            if (robo != null)
            {
                _context.Robo.Remove(robo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoboExists(int id)
        {
            return _context.Robo.Any(e => e.IdRobo == id);
        }
    }
}
