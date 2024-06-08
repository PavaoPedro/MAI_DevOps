using MAIOCEAN.Models;
using MAIOCEAN.Persistencia.Interfaces;

namespace MAIOCEAN.Persistencia.Repositorios
{
    public class ImagemRepositorio : IImagemRepositorio
    {
        private readonly MAIOCEANDbContext _context;

        public ImagemRepositorio(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public void Add(Imagem imagem)
        {
            _context.Add(imagem);

            _context.SaveChanges();
        }

        public void Delete(Imagem imagem)
        {
            _context.Remove(imagem);

            _context.SaveChanges();
        }

        public IEnumerable<Imagem> GetAll()
        {
            return _context.Imagem.ToList();
        }

        public Imagem GetById(int? id)
        {
            return _context.Imagem.Find(id);
        }

        public void Update(Imagem imagem)
        {
            _context.Update(imagem);

            _context.SaveChangesAsync();
        }
    }
}

