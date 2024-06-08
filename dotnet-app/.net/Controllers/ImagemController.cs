using MAIOCEAN.Models;
using MAIOCEAN.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAIOCEAN.Controllers
{
    public class ImagemController : Controller
    {
        private readonly MAIOCEANDbContext _context;

        public ImagemController(MAIOCEANDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Imagem.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem.Include(x => x.Regiao)
                .FirstOrDefaultAsync(m => m.IdImagem == id);
            await _context.Imagem.Include(x => x.Robo)
                .FirstOrDefaultAsync(m => m.IdImagem == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImagem,CaminhoImagem,DataHora,Profundidade,Latitude,Longitude")] Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            return View(imagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImagem,CaminhoImagem,DataHora,Profundidade,Latitude,Longitude")] Imagem imagem)
        {
            if (id != imagem.IdImagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagemExists(imagem.IdImagem))
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
            return View(imagem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem
                .FirstOrDefaultAsync(m => m.IdImagem == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem != null)
            {
                _context.Imagem.Remove(imagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemExists(int id)
        {
            return _context.Imagem.Any(e => e.IdImagem == id);
        }
    }
}
