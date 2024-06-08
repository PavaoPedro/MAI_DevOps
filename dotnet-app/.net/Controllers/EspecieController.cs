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
    public class EspecieController : Controller
    {
        private readonly MAIOCEANDbContext _context;

        public EspecieController(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especie.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .FirstOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecie,NomeEspecie,DescricaoEspecie,StatusEspecie")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            return View(especie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecie,NomeEspecie,DescricaoEspecie,StatusEspecie")] Especie especie)
        {
            if (id != especie.IdEspecie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.IdEspecie))
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
            return View(especie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .FirstOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.Especie.FindAsync(id);
            if (especie != null)
            {
                _context.Especie.Remove(especie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.IdEspecie == id);
        }
    }
}