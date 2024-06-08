using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAIOCEAN.Models;
using MAIOCEAN.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MAIOCEAN.Controllers
{
    public class TemperaturasController : Controller
    {
        private readonly MAIOCEANDbContext _context;

        public TemperaturasController(MAIOCEANDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Temperatura.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatura = await _context.Temperatura.Include(x => x.Regiao)
                .FirstOrDefaultAsync(m => m.IdTemperatura == id);
            if (temperatura == null)
            {
                return NotFound();
            }

            return View(temperatura);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTemperatura,ValorTemperatura,DataColeta.ProfundTemperatura.LatitudeTemp.LongitudeTemp")] Temperatura temperatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatura);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(temperatura);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatura = await _context.Temperatura.FindAsync(id);
            if (temperatura == null)
            {
                return NotFound();
            }
            return View(temperatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTemperatura,ValorTemperatura,DataColeta.ProfundTemperatura.LatitudeTemp.LongitudeTemp")] Temperatura temperatura)
        {
            if (id != temperatura.IdTemperatura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperaturaExists(temperatura.IdTemperatura))
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
            return View(temperatura);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatura = await _context.Temperatura
                .FirstOrDefaultAsync(m => m.IdTemperatura == id);
            if (temperatura == null)
            {
                return NotFound();
            }

            return View(temperatura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperatura = await _context.Temperatura.FindAsync(id);
            if (temperatura != null)
            {
                _context.Temperatura.Remove(temperatura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperaturaExists(int id)
        {
            return _context.Temperatura.Any(e => e.IdTemperatura == id);
        }
    }
}
